using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab12.Data;
using Lab12.Models;

namespace Lab12.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomLayoutsController : ControllerBase
    {
        private readonly AsyncInnDbContext _context;

        public RoomLayoutsController(AsyncInnDbContext context)
        {
            _context = context;
        }

        // GET: api/RoomLayouts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomLayout>>> GetRoomLayouts()
        {
            return await _context.RoomLayouts.ToListAsync();
        }

        // GET: api/RoomLayouts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomLayout>> GetRoomLayout(int id)
        {
            var roomLayout = await _context.RoomLayouts.FindAsync(id);

            if (roomLayout == null)
            {
                return NotFound();
            }

            return roomLayout;
        }

        // PUT: api/RoomLayouts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomLayout(int id, RoomLayout roomLayout)
        {
            if (id != roomLayout.ID)
            {
                return BadRequest();
            }

            _context.Entry(roomLayout).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomLayoutExists(id))
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

        // POST: api/RoomLayouts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RoomLayout>> PostRoomLayout(RoomLayout roomLayout)
        {
            _context.RoomLayouts.Add(roomLayout);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomLayout", new { id = roomLayout.ID }, roomLayout);
        }

        // DELETE: api/RoomLayouts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RoomLayout>> DeleteRoomLayout(int id)
        {
            var roomLayout = await _context.RoomLayouts.FindAsync(id);
            if (roomLayout == null)
            {
                return NotFound();
            }

            _context.RoomLayouts.Remove(roomLayout);
            await _context.SaveChangesAsync();

            return roomLayout;
        }

        private bool RoomLayoutExists(int id)
        {
            return _context.RoomLayouts.Any(e => e.ID == id);
        }
    }
}
