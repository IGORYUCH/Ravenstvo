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
    public class GraphicsCardsController : ControllerBase
    {
        private readonly WorkplaceDbContext _context;

        public GraphicsCardsController()
        {
            _context = new WorkplaceDbContext();
        }

        // GET: api/GraphicsCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GraphicsCard>>> GetGraphicsCards()
        {
            return await _context.GraphicsCards.ToListAsync();
        }

        // GET: api/GraphicsCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GraphicsCard>> GetGraphicsCard(int id)
        {
            var graphicsCard = await _context.GraphicsCards.FindAsync(id);

            if (graphicsCard == null)
            {
                return NotFound();
            }

            return graphicsCard;
        }

        // PUT: api/GraphicsCards/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGraphicsCard(int id, GraphicsCard graphicsCard)
        {
            if (id != graphicsCard.Id)
            {
                return BadRequest();
            }

            _context.Entry(graphicsCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GraphicsCardExists(id))
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

        // POST: api/GraphicsCards
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GraphicsCard>> PostGraphicsCard(GraphicsCard graphicsCard)
        {
            _context.GraphicsCards.Add(graphicsCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGraphicsCard", new { id = graphicsCard.Id }, graphicsCard);
        }

        // DELETE: api/GraphicsCards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GraphicsCard>> DeleteGraphicsCard(int id)
        {
            var graphicsCard = await _context.GraphicsCards.FindAsync(id);
            if (graphicsCard == null)
            {
                return NotFound();
            }

            _context.GraphicsCards.Remove(graphicsCard);
            await _context.SaveChangesAsync();

            return graphicsCard;
        }

        private bool GraphicsCardExists(int id)
        {
            return _context.GraphicsCards.Any(e => e.Id == id);
        }
    }
}
