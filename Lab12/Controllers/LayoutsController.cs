using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace AsyncInn.Controllers
{
    [Route("api/RoomLayouts")]
    [ApiController]
    public class LayoutsController : ControllerBase
    {
        private readonly ILayout _layout;

        public LayoutsController(ILayout layout)
        {
            _layout = layout;
        }

        // GET: api/RoomLayouts
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<LayoutDTO>>> GetLayouts()
        {
            return await _layout.GetLayouts();
        }

        // GET: api/RoomLayouts/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<LayoutDTO>> GetLayout(int id)
        {
            var layout = await _layout.GetLayout(id);
            return layout;
        }

        // PUT: api/RoomLayouts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> PutLayout(int id, LayoutDTO layout)
        {
            if (id != layout.ID)
            {
                return BadRequest();
            }

            var updateLayout = await _layout.Update(layout);
            return Ok(updateLayout);
        }

        // POST: api/RoomLayouts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<LayoutDTO>> PostLayout(LayoutDTO layout)
        {
            await _layout.Create(layout);
            return CreatedAtAction("GetLayout", new { id = layout.ID }, layout);
        }

        [HttpPost("{layoutID}/Amenity/{amenityID}")]
        [AllowAnonymous]
        public async Task<IActionResult> AddAmenityToLayout(int layoutID, int amenityID)
        {
            await _layout.AddAmenityToRoom(layoutID, amenityID);
            return Ok();
        }

        [HttpDelete("{layoutID}/Amenity/{amenityID}")]
        [AllowAnonymous]
        public async Task<IActionResult> RemoveAmenityFromLayout(int layoutID, int amenityID)
        {
            await _layout.RemoveAmenityFromRoom(layoutID, amenityID);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<LayoutDTO>> DeleteLayout(int id)
        {
            await _layout.Delete(id);
            return NoContent();
        }
    }
}
