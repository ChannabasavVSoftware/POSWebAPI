using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POSWebAPI.Repo;
using POSWebAPI.Repo.Models;


[Route("api/[controller]")]
[ApiController]
public class ProductCategoriesController : ControllerBase
{
    private readonly POSContext _context;

    public ProductCategoriesController(POSContext context)
    {
        _context = context;
    }

    [HttpGet("Categories")]
    public async Task<ActionResult<IEnumerable<ProductCategory>>> GetProductCategories()
    {
        return await _context.ProductCategories.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductCategory>> GetProductCategory(Guid id)
    {
        var productCategory = await _context.ProductCategories.FindAsync(id);

        if (productCategory == null)
        {
            return NotFound();
        }

        return productCategory;
    }

    [HttpPost("Product")]
    public async Task<ActionResult<ProductCategory>> PostProductCategory(ProductCategory productCategory)
    {
        if (productCategory == null)
        {
            return BadRequest("ProductCategory cannot be null.");
        }

        // Ensure that CreatedAt is set correctly
        if (productCategory.CreatedAt == default)
        {
            productCategory.CreatedAt = DateTime.UtcNow;
        }

        // Do not include the ID in the creation request
        _context.ProductCategories.Add(productCategory);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProductCategory), new { id = productCategory.Id }, productCategory);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutProductCategory(Guid id, ProductCategory productCategory)
    {
        if (id != productCategory.Id)
        {
            return BadRequest("ID Mismatch.");
        }

        var existingCategory = await _context.ProductCategories.FindAsync(id);
        if (existingCategory == null)
        {
            return NotFound();
        }

        // Update the existing record with the new values
        existingCategory.CategoryName = productCategory.CategoryName;
        existingCategory.CategoryDescription = productCategory.CategoryDescription;
        existingCategory.IsActive = productCategory.IsActive;
        // Do not modify CreatedAt unless explicitly intended

        _context.Entry(existingCategory).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }
    //[HttpPut("{id}")]
    //public async Task<IActionResult> PutsProductCategory(Guid id, ProductCategory productCategory)
    //{
    //    if (id != productCategory.Id)
    //    {
    //        return BadRequest();
    //    }

    //    _context.Entry(productCategory).State = EntityState.Modified;
    //    await _context.SaveChangesAsync();

    //    return NoContent();
    //}

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductCategory(Guid id)
    {
        var productCategory = await _context.ProductCategories.FindAsync(id);
        if (productCategory == null)
        {
            return NotFound();
        }

        _context.ProductCategories.Remove(productCategory);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

