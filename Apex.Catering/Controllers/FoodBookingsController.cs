using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Apex.Catering.Data;
using Apex.Catering.Data.DTOs;
using System.Diagnostics;

namespace Apex.Catering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodBookingsController : ControllerBase
    {
        private readonly CateringDbContext _context;

        public FoodBookingsController(CateringDbContext context)
        {
            _context = context;
        }

        // GET: api/FoodBookings
        [HttpGet("/api/GetFoodBooking")]
        public async Task<ActionResult<IEnumerable<FoodBooking>>> GetFoodBookings()
        {
            return await _context.FoodBookings.ToListAsync();
        }

        // GET: api/FoodBookings/5
        [HttpGet("/api/GetFoodBooking/{id}")]
        public async Task<ActionResult<FoodBooking>> GetFoodBooking(int id)
        {
            var foodBooking = await _context.FoodBookings.FindAsync(id);

            if (foodBooking == null)
            {
                return NotFound();
            }

            return foodBooking;
        }

        // PUT: api/FoodBookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("/api/PutFoodBooking/{id}")]
        public async Task<IActionResult> PutFoodBooking(int id, FoodBooking foodBooking)
        {
            if (id != foodBooking.FoodBookingId)
            {
                return BadRequest();
            }

            _context.Entry(foodBooking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodBookingExists(id))
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

        // POST: api/FoodBookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/api/PostFoodBooking")]
        public async Task<ActionResult<FoodBooking>> PostFoodBooking(FoodBookingDTO foodBooking)
        {
            // Check if the food booking menu id exists in the menus database context.
            var menuExists = await _context.Menus.FindAsync(foodBooking.MenuId);
            // Check if the food booking menu id; client reference id exist as well as checking if there is a valid number of guests input.
            if (menuExists != null && foodBooking.ClientReferenceId != null && foodBooking.NumberOfGuests > 0)
            {
                // Check if the client has an existing booking for the same menu.
                if (_context.FoodBookings.Any(fb => fb.ClientReferenceId == foodBooking.ClientReferenceId && fb.MenuId == foodBooking.MenuId)){
                    return Conflict(new { message = $"The client with {foodBooking.ClientReferenceId} has an existing booking for the menu {foodBooking.MenuId}" });
                }
                // Creates a new food booking object.
                FoodBooking newBooking = new FoodBooking()
                {
                    ClientReferenceId = (int)foodBooking.ClientReferenceId,
                    MenuId = foodBooking.MenuId,
                    NumberOfGuests = foodBooking.NumberOfGuests
                };
                // Adds the new booking to the database context and saves changes.
                _context.FoodBookings.Add(newBooking);
                await _context.SaveChangesAsync();
                // Returns the newly created food booking. Status code 201.
                return CreatedAtAction(nameof(GetFoodBooking), new { id = newBooking.FoodBookingId },
                    // Return the food booking data transfer object.
                    new FoodBookingDTO
                    {
                        FoodBookingId = newBooking.FoodBookingId,
                        ClientReferenceId = newBooking.ClientReferenceId,
                        NumberOfGuests = newBooking.NumberOfGuests,
                        MenuId = newBooking.MenuId
                    }
                );
            }
            else {
                // else return bad request status code 400.
                return BadRequest();
            }
        }

        // DELETE: api/FoodBookings/5
        [HttpDelete("/api/DeleteFoodBooking/{id}")]
        public async Task<IActionResult> DeleteFoodBooking(int id)
        {
            var foodBooking = await _context.FoodBookings.FindAsync(id);
            if (foodBooking == null)
            {
                return NotFound();
            }

            _context.FoodBookings.Remove(foodBooking);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FoodBookingExists(int id)
        {
            return _context.FoodBookings.Any(e => e.FoodBookingId == id);
        }
    }
}
