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
    public class MonitorsController : ControllerBase
    {
        private readonly WorkplaceDbContext _context;

        public MonitorsController()
        {
            _context = new WorkplaceDbContext();
        }

        // GET: api/Monitors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Object>>> GetMonitors()
        {
            return await _context.Monitors.Select(
                m => new 
                { 
                    Id = m.Id,
                    Frequency = m.Frequency,
                    ResolutionX = m.ResolutionX,
                    ResolutionY = m.ResolutionY,
                }
                ).ToListAsync();
        }

        // GET: api/Monitors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Object>> GetMonitor(int id)
        {
            var monitor = await _context.Monitors.Select(
                 m => new
                 {
                     Id = m.Id,
                     Frequency = m.Frequency,
                     ResolutionX = m.ResolutionX,
                     ResolutionY = m.ResolutionY,
                 }
                ).FirstOrDefaultAsync(m => m.Id == id);

            if (monitor == null)
            {
                return NotFound();
            }

            return monitor;
        }

        // PUT: api/Monitors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonitor(int id, Monitor monitor)
        {
            if (id != monitor.Id)
            {
                return BadRequest();
            }

            _context.Entry(monitor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonitorExists(id))
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

        // POST: api/Monitors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Monitor>> PostMonitor(Monitor monitor)
        {
            _context.Monitors.Add(monitor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonitor", new { id = monitor.Id }, monitor);
        }

        // DELETE: api/Monitors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Monitor>> DeleteMonitor(int id)
        {
            var monitor = await _context.Monitors.FindAsync(id);
            if (monitor == null)
            {
                return NotFound();
            }

            _context.Monitors.Remove(monitor);
            await _context.SaveChangesAsync();

            return monitor;
        }

        private bool MonitorExists(int id)
        {
            return _context.Monitors.Any(e => e.Id == id);
        }
    }
}
