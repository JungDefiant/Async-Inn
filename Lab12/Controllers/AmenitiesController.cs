﻿using System;
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
    [Route("api/Amenities")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmenity _amenity;

        public AmenitiesController(IAmenity amenity)
        {
            _amenity = amenity;
        }

        // GET: api/Amenities
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AmenityDTO>>> GetAmenities()
        {
            return await _amenity.GetAmenities();
        }

        // GET: api/Amenities/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<AmenityDTO>> GetAmenity(int id)
        {
            var amenity = await _amenity.GetAmenity(id);
            return amenity;
        }

        // PUT: api/Amenities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> PutAmenity(int id, AmenityDTO amenity)
        {
            if (id != amenity.ID)
            {
                return BadRequest();
            }

            var updateHotel = await _amenity.Update(amenity);
            return Ok(updateHotel);
        }

        // POST: api/Amenities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<AmenityDTO>> PostAmenity(AmenityDTO amenity)
        {
            await _amenity.Create(amenity);

            return CreatedAtAction("GetAmenity", new { id = amenity.ID }, amenity);
        }

        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<AmenityDTO>> DeleteAmenity(int id)
        {
            await _amenity.Delete(id);
            return NoContent();
        }
    }
}
