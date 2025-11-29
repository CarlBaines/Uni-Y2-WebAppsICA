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
        private readonly HttpClient _httpClient;

        public FoodBookingsController(CateringDbContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }

        // GET: api/FoodBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodBookingDTO>>> GetFoodBookings()
        {
            //return await _context.FoodBookings.ToListAsync();
            var foodBookings = await _context.FoodBookings
                .Select(fb => new FoodBookingDTO
                {
                    FoodBookingId = fb.FoodBookingId,
                    EventId = fb.EventId,
                    ClientReferenceId = fb.ClientReferenceId,
                    NumberOfGuests = fb.NumberOfGuests,
                    MenuId = fb.MenuId
                }).ToListAsync();
            return foodBookings;
        }

        // GET: api/FoodBookings/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<FoodBookingDTO>> GetFoodBooking(int id)
        {
            var foodBooking = await _context.FoodBookings.FindAsync(id);

            if (foodBooking == null)
            {
                return NotFound();
            }

            return new FoodBookingDTO
            {
                FoodBookingId = foodBooking.FoodBookingId,
                EventId = foodBooking.EventId,
                ClientReferenceId = foodBooking.ClientReferenceId,
                NumberOfGuests = foodBooking.NumberOfGuests,
                MenuId = foodBooking.MenuId
            };
        }

        // PUT: api/FoodBookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutFoodBooking(int id, FoodBookingDTO foodBookingDto)
        {
            if (id != foodBookingDto.FoodBookingId)
            {
                return BadRequest();
            }

            // Check if the food booking exists
            var existing = await _context.FoodBookings.FindAsync(id);
            if (existing == null)
            {
                return NotFound();
            }
            // Checks if the menu id exists in the menus database context.
            if (existing.MenuId != foodBookingDto.MenuId)
            {
                var menu = await _context.Menus.FindAsync(foodBookingDto.MenuId);
                if(menu == null)
                {
                    return BadRequest();
                }
            }

            if(existing.EventId != foodBookingDto.EventId)
            {
                var eventApiResponse = await _httpClient.GetAsync($"api/Events/{foodBookingDto.EventId}");
                if (!eventApiResponse.IsSuccessStatusCode)
                {
                    return NotFound(new { message = $"Event {foodBookingDto.EventId} not found in Apex.Events." });
                }
            }

            existing.EventId = foodBookingDto.EventId;
            existing.ClientReferenceId = foodBookingDto.ClientReferenceId;
            existing.NumberOfGuests = foodBookingDto.NumberOfGuests;
            existing.MenuId = foodBookingDto.MenuId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/FoodBookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FoodBookingDTO>> PostFoodBooking(FoodBookingDTO foodBooking)
        {
            // Check if the food booking menu id exists in the menus database context.
            var menuExists = await _context.Menus.FindAsync(foodBooking.MenuId);

            // Validate events via Events service API.
            var eventApiResponse = await _httpClient.GetAsync($"api/Events/{foodBooking.EventId}");
            if (!eventApiResponse.IsSuccessStatusCode)
            {
                return NotFound();
            }

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
                    EventId = foodBooking.EventId,
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
                        EventId = newBooking.EventId,
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
        [HttpDelete("{id:int}")]
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
    }
}
