using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Workplace.Models;
using Workplace.DTOs;

namespace Workplace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputersController : ControllerBase
    {
        private readonly WorkplaceDbContext _context;

        public ComputersController()
        {
            _context = new WorkplaceDbContext();
        }

        // GET: api/Computers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Computer>>> GetComputers()
        {
            return await _context.Computers
                .Include(c => c.SystemUnit).ThenInclude(su => su.Disk)
                .Include(c => c.SystemUnit).ThenInclude(su => su.Processor)
                .Include(c => c.SystemUnit).ThenInclude(su => su.GraphicsCard)
                .Include(c => c.SystemUnit).ThenInclude(su => su.Memory)
                .Include(c => c.Mouse)
                .Include(c => c.Keyboard)
                .Include(c => c.Monitors)
                .ToListAsync();
        }

        // GET: api/Computers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Computer>> GetComputer(int id)
        {
            var computer = await _context.Computers
                .Include(c => c.SystemUnit).ThenInclude(su => su.Disk)
                .Include(c => c.SystemUnit).ThenInclude(su => su.Processor)
                .Include(c => c.SystemUnit).ThenInclude(su => su.GraphicsCard)
                .Include(c => c.SystemUnit).ThenInclude(su => su.Memory)
                .Include(c => c.Mouse)
                .Include(c => c.Keyboard)
                .Include(c => c.Monitors)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (computer == null)
            {
                return NotFound();
            }

            return computer;
        }

        // PUT: api/Computers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComputer(int id, IncomingComputer incomingComputer)
        {
            if (id != incomingComputer.Id)
            {
                return BadRequest();
            }

            Computer computer = await _context.Computers.Include(c=>c.Monitors).FirstOrDefaultAsync(c=> c.Id==id);
            if (computer == null)
            {
                return NotFound($"Computer with id {id} not found");
            }

            List<Monitor> monitors = new List<Monitor>();
            foreach (int monitorId in incomingComputer.MonitorIds)
            {
                Monitor monitor = _context.Monitors.Find(monitorId);
                if (monitor != null)
                {
                    monitors.Add(monitor);
                }
                else
                {
                    return NotFound($"Monitor with id {monitorId} not found");
                }
            }

            computer.SystemUnitId = incomingComputer.SystemUnitId;
            computer.KeyboardId = incomingComputer.KeyboardId;
            computer.MouseId = incomingComputer.MouseId;
            computer.Monitors = monitors;

            _context.Entry(computer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComputerExists(id))
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

        // POST: api/Computers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Computer>> PostComputer(IncomingComputer incomingComputer)
        {
            List<Monitor> monitors = new List<Monitor>();
            foreach (int monitorId in incomingComputer.MonitorIds)
            {
                Monitor monitor = _context.Monitors.Find(monitorId);
                if (monitor != null)
                {
                    monitors.Add(monitor);
                }
                else
                {
                    return NotFound($"Monitor with id {monitorId} not found");
                }
            }

            Computer computer = new Computer
            {
                SystemUnitId = incomingComputer.SystemUnitId,
                MouseId = incomingComputer.MouseId,
                KeyboardId = incomingComputer.KeyboardId,
                Monitors = monitors
            };

            _context.Computers.Add(computer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComputer", new { id = computer.Id }, computer);
        }

        // DELETE: api/Computers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Computer>> DeleteComputer(int id)
        {
            var computer = await _context.Computers.FindAsync(id);
            if (computer == null)
            {
                return NotFound();
            }

            _context.Computers.Remove(computer);
            await _context.SaveChangesAsync();

            return computer;
        }

        private bool ComputerExists(int id)
        {
            return _context.Computers.Any(e => e.Id == id);
        }
    }
}
