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
    public class EncountersController : ControllerBase
    {
        private readonly HealthcareDbContext _context;

        public EncountersController(HealthcareDbContext context)
        {
            _context = context;
        }

        // GET: api/Encounters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Encounter>>> GetEncounters()
        {
            return await _context.Encounters.ToListAsync();
        }

        // GET: api/Encounters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Encounter>> GetEncounter(int id)
        {
            var encounter = await _context.Encounters.FindAsync(id);

            if (encounter == null)
            {
                return NotFound();
            }

            return encounter;
        }

        // PUT: api/Encounters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEncounter(int id, Encounter encounter)
        {
            if (id != encounter.EncounterId)
            {
                return BadRequest();
            }

            _context.Entry(encounter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EncounterExists(id))
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

        // POST: api/Encounters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Encounter>> PostEncounter(Encounter encounter)
        {
            _context.Encounters.Add(encounter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEncounter", new { id = encounter.EncounterId }, encounter);
        }

        // DELETE: api/Encounters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEncounter(int id)
        {
            var encounter = await _context.Encounters.FindAsync(id);
            if (encounter == null)
            {
                return NotFound();
            }

            _context.Encounters.Remove(encounter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EncounterExists(int id)
        {
            return _context.Encounters.Any(e => e.EncounterId == id);
        }
    }
}
