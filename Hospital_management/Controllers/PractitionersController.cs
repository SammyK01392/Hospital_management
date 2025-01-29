using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hospital_management.Models;

namespace Hospital_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PractitionersController : ControllerBase
    {
        private readonly HealthcareDbContext _context;

        public PractitionersController(HealthcareDbContext context)
        {
            _context = context;
        }

        // GET: api/Practitioners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Practitioner>>> GetPractitioners()
        {
            return await _context.Practitioners.ToListAsync();
        }

        // GET: api/Practitioners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Practitioner>> GetPractitioner(int id)
        {
            var practitioner = await _context.Practitioners.FindAsync(id);

            if (practitioner == null)
            {
                return NotFound();
            }

            return practitioner;
        }

        // PUT: api/Practitioners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPractitioner(int id, Practitioner practitioner)
        {
            if (id != practitioner.PractitionerId)
            {
                return BadRequest();
            }

            _context.Entry(practitioner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PractitionerExists(id))
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

        // POST: api/Practitioners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Practitioner>> PostPractitioner(Practitioner practitioner)
        {
            _context.Practitioners.Add(practitioner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPractitioner", new { id = practitioner.PractitionerId }, practitioner);
        }

        // DELETE: api/Practitioners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePractitioner(int id)
        {
            var practitioner = await _context.Practitioners.FindAsync(id);
            if (practitioner == null)
            {
                return NotFound();
            }

            _context.Practitioners.Remove(practitioner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PractitionerExists(int id)
        {
            return _context.Practitioners.Any(e => e.PractitionerId == id);
        }
    }
}
