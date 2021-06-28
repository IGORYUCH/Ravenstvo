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
    public class ComputersController : ControllerBase
    {
        private readonly WorkplaceDbContext _context;

        public ComputersController()
        {
            _context = new WorkplaceDbContext();
        }

        // GET: api/Computers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Object>>> GetComputers()
        {
            IEnumerable<Computer> computers = _context.Computers.Include(c => c.SystemUnit).Include(c => c.Monitors);
           /* return await _context.Computers
             .Include(c => c.SystemUnit.Disk)
             .Include(c => c.SystemUnit.Motherboard)
             .Include(c => c.SystemUnit.Processor)
             .Include(c => c.SystemUnit.Memory)
             .Include(c => c.Monitors)
             .ToListAsync();*/

            //ругается на циклическую зависимость
            return await _context.Computers.Select(c => new 
            {
                Id = c.Id,
                SystemUnit = new {
                    Id = c.SystemUnit.Id,
                    Motherboard = c.SystemUnit.Motherboard,
                    Processor = c.SystemUnit.Processor,
                    Disk = c.SystemUnit.Disk,
                    Memory = c.SystemUnit.Memory
                },
                Keyboard = c.Keyboard,
                Mouse = c.Mouse,
                Monitors = c.Monitors.Select(m => new 
                {
                    Id = m.Id,
                    Frequency = m.Frequency,
                    ResolutionX = m.ResolutionX,
                    ResolutionY = m.ResolutionY
                }
                    ).ToList()
            }).ToListAsync();

        }

        // GET: api/Computers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Object>> GetComputer(int id)
        {
            var computer = await _context.Computers.Select(
                c => new 
                {
                    Id = c.Id,
                    SystemUnit = new
                    {
                        Id = c.SystemUnit.Id,
                        Motherboard = c.SystemUnit.Motherboard,
                        Processor = c.SystemUnit.Processor,
                        Disk = c.SystemUnit.Disk,
                        Memory = c.SystemUnit.Memory
                    },
                    Keyboard = c.Keyboard,
                    Mouse = c.Mouse,
                    Monitors = c.Monitors.Select(m => new
                    {
                        Id = m.Id,
                        Frequency = m.Frequency,
                        ResolutionX = m.ResolutionX,
                        ResolutionY = m.ResolutionY
                    }
                    ).ToList()
                }
                )
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
        public async Task<IActionResult> PutComputer(int id, Computer computer)
        {
            if (id != computer.Id)
            {
                return BadRequest();
            }

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
        public async Task<ActionResult<Computer>> PostComputer(Computer computer)
        {
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
