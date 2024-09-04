using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POSWebAPI.Repo;
using POSWebAPI.Repo.Models;

namespace POSWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly POSContext _context;

        public OrderDetailsController(POSContext context)
        {
            _context = context;
        }

        // GET: api/OrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetails()
        {
            // Retrieve all OrderDetails without related entities 
            var orderDetails = await _context.OrderDetails.ToListAsync();
            return Ok(orderDetails);
        }

        // GET: api/OrderDetails/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetail>> GetOrderDetail(Guid id)
        {
            // Retrieve a single OrderDetail by its ID
            var orderDetail = await _context.OrderDetails.FindAsync(id);

            if (orderDetail == null)
            {
                return NotFound();
            }

            return Ok(orderDetail);
        }

        // POST: api/OrderDetails
        [HttpPost]
        public async Task<ActionResult<OrderDetail>> PostOrderDetail(OrderDetail orderDetail)
        {
            if (orderDetail == null)
            {
                return BadRequest("OrderDetail cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.OrderDetails.Add(orderDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrderDetail), new { id = orderDetail.Id }, orderDetail);
        }

        // PUT: api/OrderDetails/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderDetail(Guid id, OrderDetail orderDetail)
        {
            if (id != orderDetail.Id)
            {
                return BadRequest("OrderDetail ID mismatch.");
            }

            _context.Entry(orderDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/OrderDetails/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(Guid id)
        {
            var orderDetail = await _context.OrderDetails.FindAsync(id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            _context.OrderDetails.Remove(orderDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderDetailExists(Guid id)
        {
            return _context.OrderDetails.Any(e => e.Id == id);
        }
    }
}
