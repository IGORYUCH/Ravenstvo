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
    public class WorkplacesController : ControllerBase
    {
        private readonly WorkplaceDbContext _context;

        public WorkplacesController()
        {
            _context = new WorkplaceDbContext();
        }

        // GET: api/Workplaces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workplace_>>> GetWorkplaces()
        {
            return await _context.Workplaces
                .Include(w => w.Computer).ThenInclude(c => c.SystemUnit).ThenInclude(su => su.GraphicsCard)
                .Include(w => w.Computer).ThenInclude(c => c.SystemUnit).ThenInclude(su => su.Processor)
                .Include(w => w.Computer).ThenInclude(c => c.SystemUnit).ThenInclude(su => su.Memory)
                .Include(w => w.Computer).ThenInclude(c => c.SystemUnit).ThenInclude(su => su.Disk)
                .Include(w => w.Computer).ThenInclude(c => c.Keyboard)
                .Include(w => w.Computer).ThenInclude(c => c.Mouse)
                .Include(w => w.Computer).ThenInclude(c => c.Monitors)
                .ToListAsync();
        }

        // GET: api/Workplaces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Workplace_>> GetWorkplace(int id)
        {
            Workplace_ workplace = await _context.Workplaces
                .Include(w => w.Computer).ThenInclude(c => c.SystemUnit).ThenInclude(su => su.GraphicsCard)
                .Include(w => w.Computer).ThenInclude(c => c.SystemUnit).ThenInclude(su => su.Processor)
                .Include(w => w.Computer).ThenInclude(c => c.SystemUnit).ThenInclude(su => su.Memory)
                .Include(w => w.Computer).ThenInclude(c => c.SystemUnit).ThenInclude(su => su.Disk)
                .Include(w => w.Computer).ThenInclude(c => c.Keyboard)
                .Include(w => w.Computer).ThenInclude(c => c.Mouse)
                .Include(w => w.Computer).ThenInclude(c => c.Monitors)
                .FirstOrDefaultAsync(w => w.Id == id);

            if (workplace == null)
            {
                return NotFound();
            }

            return workplace;
        }

        // PUT: api/Workplaces/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkplace(int id, Workplace_ workplace)
        {
            if (id != workplace.Id)
            {
                return BadRequest();
            }

            _context.Entry(workplace).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkplaceExists(id))
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

        // POST: api/Workplaces
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Workplace_>> PostWorkplace(Workplace_ workplace)
        {
            _context.Workplaces.Add(workplace);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWorkplace", new { id = workplace.Id }, workplace);
        }

        // DELETE: api/Workplaces/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Workplace_>> DeleteWorkplace(int id)
        {
            var workplace = await _context.Workplaces.FindAsync(id);
            if (workplace == null)
            {
                return NotFound();
            }

            _context.Workplaces.Remove(workplace);
            await _context.SaveChangesAsync();

            return workplace;
        }

        private bool WorkplaceExists(int id)
        {
            return _context.Workplaces.Any(e => e.Id == id);
        }
    }
}
