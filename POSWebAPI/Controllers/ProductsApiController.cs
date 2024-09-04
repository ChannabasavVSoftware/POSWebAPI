using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POSWebAPI.Repo;
using POSWebAPI.Repo.Models;

namespace POSWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsApiController : ControllerBase
    {
        private readonly POSContext _context;

        public ProductsApiController(POSContext context)
        {
            _context = context;
        }



        [HttpGet("categories")]
        public async Task<IActionResult> GetProductCategoriesWithProducts()
        {
            var categories = await _context.ProductCategories
                .Include(pc => pc.Products)
                .ToListAsync();

            var result = categories.ToDictionary(
                pc => pc.CategoryName,
                pc => pc.Products.Select(p => new
                {
                    p.Id,
                    p.ProductName,
                    p.Price,
                    p.ImageUrl
                }).ToList()
        );

            return Ok(result);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(Guid id)
        {
            var product = await _context.Products
                .Include(p => p.Tax)
                .Include(p => p.ProductCategory)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }



        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _context.Products.ToListAsync();
        }



        [HttpPost("products")]
        public async Task<ActionResult<Product>> PostProduct([FromBody] Product product)
        {
            if (!_context.Taxes.Any(t => t.Id == product.TaxId))
            {
                return BadRequest("Invalid TaxId.");
            }

            if (!_context.ProductCategories.Any(pc => pc.Id == product.ProductCategoryId))
            {
                return BadRequest("Invalid ProductCategoryId.");
            }

            if (_context.Products.Any(p => p.ProductName == product.ProductName))
            {
                return BadRequest("Product Already Exists");
            }

            product.Id = Guid.NewGuid();  // Assign a new GUID for the product
            product.CreatedAt = DateTime.UtcNow;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }



        [HttpGet("ProductCatagory")]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetProductCategory()
        {
            return await _context.ProductCategories.ToListAsync();
        }



        [HttpPost("productcategories")]
        public async Task<ActionResult<ProductCategory>> PostProductCategory([FromBody] ProductCategory productCategory)
        {
            if (_context.ProductCategories.Any(p => p.CategoryName == productCategory.CategoryName))
            {
                return BadRequest("Catergory Name Alread Exists");
            }
            productCategory.Id = Guid.NewGuid();  // Assign a new GUID for the product
            productCategory.CreatedAt = DateTime.UtcNow;

            _context.ProductCategories.Add(productCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }




        //[HttpPost]
        //public async Task<ActionResult<Product>> PostProduct(Product product)
        //{
        //    if (product == null)
        //    {
        //        return BadRequest();
        //    }

        //    product.Id = Guid.NewGuid();

        //    _context.Products.Add(product);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}


        // POST: api/Products
        //[HttpPost]
        //public async Task<ActionResult<Product>> PostProduct(Product product)
        //{
        //    if (_context.Taxes.Any(t => t.Id == product.TaxId) &&
        //        _context.ProductCategories.Any(pc => pc.Id == product.ProductCategoryId))
        //    {
        //        product.Id = Guid.NewGuid();  // Assign a new GUID for the product
        //        product.CreatedAt = DateTime.UtcNow;

        //        _context.Products.Add(product);
        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction(nameof(GetProductCategoriesWithProducts), new { id = product.Id }, product);
        //    }
        //    else
        //    {
        //        return BadRequest("Invalid TaxId or ProductCategoryId");
        //    }
        //}

        //[HttpGet]
        //public IActionResult GetProductsByCategory()
        //{
        //    var result = _context.ProductCategories
        //        .Where(pc => pc.IsActive)
        //        .Select(pc => new
        //        {
        //            CategoryName = pc.CategoryName,
        //            Products = pc.Products.Select(p => new
        //            {
        //                p.Id,
        //                p.ProductName,
        //                p.ProductDescription,
        //                p.Price,
        //                p.ImageUrl,
        //                p.IsActive,
        //                p.CreatedAt
        //            }).ToList()
        //        })
        //        .ToDictionary(x => x.CategoryName, x => x.Products);

        //    return Ok(result);
        //}

    }
}



