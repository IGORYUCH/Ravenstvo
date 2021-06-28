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
    public class DisksController : ControllerBase
    {
        private readonly WorkplaceDbContext _context;

        public DisksController()
        {
            _context = new WorkplaceDbContext();
        }

        // GET: api/Disks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Disk>>> GetDisks()
        {
            return await _context.Disks.ToListAsync();
        }

        // GET: api/Disks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Disk>> GetDisk(int id)
        {
            var disk = await _context.Disks.FindAsync(id);

            if (disk == null)
            {
                return NotFound();
            }

            return disk;
        }

        // PUT: api/Disks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDisk(int id, Disk disk)
        {
            if (id != disk.Id)
            {
                return BadRequest();
            }

            _context.Entry(disk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiskExists(id))
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

        // POST: api/Disks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Disk>> PostDisk(Disk disk)
        {
            _context.Disks.Add(disk);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDisk", new { id = disk.Id }, disk);
        }

        // DELETE: api/Disks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Disk>> DeleteDisk(int id)
        {
            var disk = await _context.Disks.FindAsync(id);
            if (disk == null)
            {
                return NotFound();
            }

            _context.Disks.Remove(disk);
            await _context.SaveChangesAsync();

            return disk;
        }

        private bool DiskExists(int id)
        {
            return _context.Disks.Any(e => e.Id == id);
        }
    }
}
