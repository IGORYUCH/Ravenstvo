﻿using System;
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
    public class MiceController : ControllerBase
    {
        private readonly WorkplaceDbContext _context;

        public MiceController()
        {
            _context = new WorkplaceDbContext();
        }

        // GET: api/Mice
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mouse>>> GetMice()
        {
            return await _context.Mice.ToListAsync();
        }

        // GET: api/Mice/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mouse>> GetMouse(int id)
        {
            var mouse = await _context.Mice.FindAsync(id);

            if (mouse == null)
            {
                return NotFound();
            }

            return mouse;
        }

        // PUT: api/Mice/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMouse(int id, Mouse mouse)
        {
            if (id != mouse.Id)
            {
                return BadRequest();
            }

            _context.Entry(mouse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MouseExists(id))
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

        // POST: api/Mice
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Mouse>> PostMouse(Mouse mouse)
        {
            _context.Mice.Add(mouse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMouse", new { id = mouse.Id }, mouse);
        }

        // DELETE: api/Mice/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mouse>> DeleteMouse(int id)
        {
            var mouse = await _context.Mice.FindAsync(id);
            if (mouse == null)
            {
                return NotFound();
            }

            _context.Mice.Remove(mouse);
            await _context.SaveChangesAsync();

            return mouse;
        }

        private bool MouseExists(int id)
        {
            return _context.Mice.Any(e => e.Id == id);
        }
    }
}
