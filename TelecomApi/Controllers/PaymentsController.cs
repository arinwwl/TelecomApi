using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TelecomApi.Data;
using TelecomApi.Models;

namespace TelecomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly TelecomContext _context;

        public PaymentsController(TelecomContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
        {
            return await _context.Payments.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPayment(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null) return NotFound();
            return payment;
        }

        [HttpPost]
        public async Task<ActionResult<Payment>> PostPayment(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPayment), new { id = payment.Id }, payment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(int id, Payment payment)
        {
            if (id != payment.Id) return BadRequest();
            _context.Entry(payment).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null) return NotFound();
            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("debtors")]
        public async Task<ActionResult<IEnumerable<object>>> GetDebtors()
        {
            return await _context.Payments
                .Where(p => p.Balance < 0)
                .Select(p => new
                {
                    p.LastName,
                    p.PhoneNumber,
                    Debt = -p.Balance
                })
                .ToListAsync();
        }

      
        [HttpGet("search/by-name/{lastName}")]
        public async Task<ActionResult<IEnumerable<Payment>>> SearchByName(string lastName)
        {
            return await _context.Payments.Where(p => p.LastName == lastName).ToListAsync();
        }

       
        [HttpGet("search/by-phone/{phone}")]
        public async Task<ActionResult<IEnumerable<Payment>>> SearchByPhone(string phone)
        {
            return await _context.Payments.Where(p => p.PhoneNumber == phone).ToListAsync();
        }
    }
}
