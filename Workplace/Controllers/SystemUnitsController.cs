using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Workplace.Models;

namespace Workplace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemUnitsController : ControllerBase
    {
        private readonly WorkplaceDbContext _context;

        public SystemUnitsController()
        {
            _context = new WorkplaceDbContext();
        }

        // GET: api/SystemUnits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SystemUnit>>> GetSystemUnits()
        {
            return await _context.SystemUnits
                .Include("Motherboard")
                .Include("Processor")
                .Include("Disk")
                .Include("Memory")
                .ToListAsync();
        }

        // GET: api/SystemUnits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SystemUnit>> GetSystemUnit(int id)
        {
            var systemUnit = await _context.SystemUnits
                .Include("Motherboard")
                .Include("Processor")
                .Include("Disk")
                .Include("Memory")
                .FirstOrDefaultAsync(su => su.Id == id);

            if (systemUnit == null)
            {
                return NotFound();
            }

            return systemUnit;
        }

        // PUT: api/SystemUnits/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSystemUnit(int id, SystemUnit systemUnit)
        {
            if (id != systemUnit.Id)
            {
                return BadRequest();
            }

            _context.Entry(systemUnit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemUnitExists(id))
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

        // POST: api/SystemUnits
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SystemUnit>> PostSystemUnit(SystemUnit systemUnit)
        {
            _context.SystemUnits.Add(systemUnit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSystemUnit", new { id = systemUnit.Id }, systemUnit);
        }

        // DELETE: api/SystemUnits/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SystemUnit>> DeleteSystemUnit(int id)
        {
            var systemUnit = await _context.SystemUnits.FindAsync(id);
            if (systemUnit == null)
            {
                return NotFound();
            }

            _context.SystemUnits.Remove(systemUnit);
            await _context.SaveChangesAsync();

            return systemUnit;
        }

        private bool SystemUnitExists(int id)
        {
            return _context.SystemUnits.Any(e => e.Id == id);
        }
    }
}
