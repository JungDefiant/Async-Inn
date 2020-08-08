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

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRoom _context;

        public HotelRoomsController(IHotelRoom context)
        {
            _context = context;
        }

        // GET: api/HotelRooms
        [HttpGet("/api/Hotels/{hotelId}/HotelRooms")]
        public async Task<ActionResult<IEnumerable<HotelRoomDTO>>> GetRooms(int hotelID)
        {
            return await _context.GetRooms(hotelID);
        }

        // GET: api/HotelRooms/5
        [HttpGet("/api/Hotels/{hotelId}/HotelRooms/{roomNumber}")]
        public async Task<ActionResult<HotelRoomDTO>> GetHotelRoom(int roomNumber, int hotelID)
        {
            var hotelRoom = await _context.GetRoom(roomNumber, hotelID);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            return hotelRoom;
        }

        // PUT: api/HotelRooms/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("/api/Hotels/{hotelId}/HotelRooms/{roomNumber}")]
        public async Task<IActionResult> PutHotelRoom(int hotelID, int roomNumber, HotelRoomDTO hotelRoom)
        {
            if (hotelID != hotelRoom.HotelID || roomNumber != hotelRoom.RoomNumber)
            {
                return BadRequest();
            }

            await _context.Update(hotelRoom);

            return NoContent();
        }

        // POST: api/HotelRooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("/api/Hotels/{hotelId}/HotelRooms")]
        public async Task<ActionResult<HotelRoomDTO>> PostHotelRoom(HotelRoomDTO hotelRoom, int hotelID)
        {
            await _context.Create(hotelRoom, hotelID);

            return CreatedAtAction("GetHotelRoom", new { id = hotelRoom.HotelID }, hotelRoom);
        }

        // DELETE: api/HotelRooms/5
        [HttpDelete("/api/Hotels/{hotelId}/HotelRooms/{roomNumber}")]
        public async Task<ActionResult<HotelRoomDTO>> DeleteHotelRoom(int roomNumber, int hotelID)
        {
            await _context.Delete(roomNumber, hotelID);

            return NoContent();
        }
    }
}
