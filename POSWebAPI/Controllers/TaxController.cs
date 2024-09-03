using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POSWebAPI.Repo;
using POSWebAPI.Repo.Models;

namespace POSWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        private readonly POSContext _context;

        public TaxController(POSContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tax>>> GetTax()
        {
            return await _context.Taxes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tax>> GetTaxById(Guid id)
        {
            var tax = await _context.Taxes.FindAsync(id);
            if (tax == null)
            {
                return NotFound();
            }

            return tax;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Tax>> UpdateTax(Guid id, Tax tax)
        {
            // var taxes = await _context.Taxes.FindAsync(Id);

            if (id != tax.Id)
            {
                return BadRequest();
            }

            _context.Entry(tax).State = EntityState.Modified;

            try
            {
                _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Taxes.Any(t => t.Id == id))
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

        [HttpPost]
        public async Task<ActionResult<Tax>> PostTax(Tax tax)
        {
            tax.Id = Guid.NewGuid();
            _context.Taxes.Add(tax);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTax), new { id = tax.Id }, tax);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTax(Guid id)
        {
            var tax = await _context.Taxes.FindAsync(id);
            if (tax == null)
            {
                return NotFound();
            }

            _context.Taxes.Remove(tax);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}
