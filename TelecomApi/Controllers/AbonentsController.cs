using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TelecomApi.Data;
using TelecomApi.Models;

namespace TelecomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbonentsController : ControllerBase
    {
        private readonly TelecomContext _context;

        public AbonentsController(TelecomContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Abonent>>> GetAbonents()
        {
            return await _context.Abonents.ToListAsync();
        }

        [HttpGet("{lastName}")]
        public async Task<ActionResult<Abonent>> GetAbonent(string lastName)
        {
            var abonent = await _context.Abonents.FindAsync(lastName);
            if (abonent == null) return NotFound();
            return abonent;
        }

        [HttpPost]
        public async Task<ActionResult<Abonent>> PostAbonent(Abonent abonent)
        {
            _context.Abonents.Add(abonent);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAbonent), new { lastName = abonent.LastName }, abonent);
        }

        [HttpPut("{lastName}")]
        public async Task<IActionResult> PutAbonent(string lastName, Abonent abonent)
        {
            if (lastName != abonent.LastName) return BadRequest();
            _context.Entry(abonent).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{lastName}")]
        public async Task<IActionResult> DeleteAbonent(string lastName)
        {
            var abonent = await _context.Abonents.FindAsync(lastName);
            if (abonent == null) return NotFound();

            _context.Abonents.Remove(abonent);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
