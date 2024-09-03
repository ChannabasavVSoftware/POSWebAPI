using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POSWebAPI.Repo;
using POSWebAPI.Repo.Models;

namespace POSWebAPI.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly POSContext _context;

        public ProductsController(POSContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        //{
        //    var products = await _context.Products.ToListAsync();
        //    return Ok(products);
        //}

        [HttpGet]
        public async Task<ActionResult<Dictionary<string, List<Product>>>> GetProducts()
        {
            var products = await _context.Products
                .Include(p => p.ProductCategory)
                .Select(p => new
                {
                    p.Id,
                    p.ProductName,
                    p.Price,
                    p.ImageUrl,
                    CategoryName = p.ProductCategory.CategoryName
                })
                .ToListAsync();

            var groupedProducts = products
                .GroupBy(p => p.CategoryName)
                .ToDictionary(
                    g => g.Key, // CategoryName
                    g => g.Select(p => new
                    {
                        p.Id,
                        p.ProductName,
                        p.Price,
                        p.ImageUrl
                    }).ToList()
                );

            return Ok(groupedProducts);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Product Data is required.");
            }
            //var category = await _context.ProductCategories.FirstOrDefaultAsync(c => c.CategoryName == product.ProductCategory.CategoryName);
            //if (category == null)
            //{
            //    return NotFound("The CategoryName You are searching is not found");
            //}

            //var Newproduct = new Product
            //{
            //    Id = Guid.NewGuid(), // Generate a new ID
            //    ProductName = product.ProductName,
            //    Price = product.Price,
            //    ImageUrl = product.ImageUrl,
            //    ProductCategory = product.ProductCategory, // Associate with the found category
            //    CreatedAt = DateTime.Now // Set creation time

            //};


            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest("Product ID mismatch.");
            }

            var existingProduct = await _context.Products.FindAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(Guid id)
        {

            var isDeleted = await _context.Products.FindAsync(id);
            if (isDeleted == null)
            {
                return NotFound();
            }
            _context.Products.Remove(isDeleted);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }


}

