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
        private readonly IHttpClientFactory _httpClientFactory;

        public FoodBookingsController(CateringDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        // GET: api/FoodBookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodBookingDTO>>> GetFoodBookings()
        {
            // Retrieve all food bookings and map them to DTOs.
            var foodBookings = await _context.FoodBookings
                .Select(fb => new FoodBookingDTO
                {
                    FoodBookingId = fb.FoodBookingId,
                    EventId = fb.EventId,
                    ClientReferenceId = fb.ClientReferenceId,
                    NumberOfGuests = fb.NumberOfGuests,
                    MenuId = fb.MenuId
                }).ToListAsync();
            // Check if there are no food bookings.
            if (foodBookings.Count == 0)
            {
                // Return NoContent status code 204.
                return NoContent();
            }

            return foodBookings;
        }

        [HttpGet("ForEvent/{eventId:int}")]
        public async Task<ActionResult<IEnumerable<FoodBookingDTO>>> GetFoodBookingForEvent(int eventId)
        {
            var foodBookings = await _context.FoodBookings
                .Where(fb => fb.EventId == eventId)
                .Select(fb => new FoodBookingDTO
                {
                    FoodBookingId = fb.FoodBookingId,
                    EventId = fb.EventId,
                    ClientReferenceId = fb.ClientReferenceId,
                    NumberOfGuests = fb.NumberOfGuests,
                    MenuId = fb.MenuId
                }).ToListAsync();
            
            if (foodBookings.Count == 0)
            {
                return NoContent();
            }

            return foodBookings;
        }

        // GET: api/FoodBookings/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<FoodBookingDTO>> GetFoodBooking(int id)
        {
            var foodBooking = await _context.FoodBookings.FindAsync(id);

            // Check if the food booking exists.
            if (foodBooking == null)
            {
                return NotFound(new ProblemDetails
                {
                    Title = "Food Booking Not Found",
                    Detail = $"No food booking was found with the id: {id}",
                    Status = StatusCodes.Status404NotFound
                });
            }

            // Map the food booking to a DTO and return it.
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
                return BadRequest(new ProblemDetails
                {
                    Title = "Invalid Request",
                    Detail = $"Route id {id} does not match the body FoodBookingId {foodBookingDto.FoodBookingId}",
                    Status = StatusCodes.Status400BadRequest
                });
            }

            // Check if the food booking exists
            var existing = await _context.FoodBookings.FindAsync(id);
            if (existing == null)
            {
                return NotFound(new ProblemDetails
                {
                    Title = "Food booking not found",
                    Detail = $"No food booking exists with the id: {id}",
                    Status = StatusCodes.Status404NotFound
                });
            }
            
            if (existing.MenuId != foodBookingDto.MenuId)
            {
                var menu = await _context.Menus.FindAsync(foodBookingDto.MenuId);
                if(menu == null)
                {
                    return BadRequest(new ProblemDetails
                    {
                        Title = "Invalid Menu",
                        Detail = $"Menu does not exist with the id: {foodBookingDto.MenuId}",
                        Status = StatusCodes.Status400BadRequest
                    });
                }
            }

            if(existing.EventId != foodBookingDto.EventId)
            {
                // Store Events named http client.
                var client = _httpClientFactory.CreateClient("Events");
                HttpResponseMessage? eventApiResponse = null;
                // Check if the event id exists via Events API.
                try
                {
                    eventApiResponse = await client.GetAsync($"api/Events/{foodBookingDto.EventId}");
                }
                catch (HttpRequestException e)
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable, new ProblemDetails
                    {
                        Title = "Events Service Unavailable",
                        Detail = $"Failed to reach the Events service: {e.Message}",
                        Status = StatusCodes.Status503ServiceUnavailable
                    });
                }

                if (!eventApiResponse.IsSuccessStatusCode)
                {
                    return NotFound(new ProblemDetails
                    {
                        Title = "Event not found",
                        Detail = $"Event with the id {foodBookingDto.EventId} does not exist.",
                        Status = StatusCodes.Status404NotFound
                    });
                }
            }

            // Update the existing food booking with the new values.
            existing.EventId = foodBookingDto.EventId;
            existing.ClientReferenceId = foodBookingDto.ClientReferenceId;
            existing.NumberOfGuests = foodBookingDto.NumberOfGuests;
            existing.MenuId = foodBookingDto.MenuId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                throw;
            }

            // Return confirmation with the FoodBookingId.
            return Ok(new { existing.FoodBookingId });
        }

        // POST: api/FoodBookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FoodBookingDTO>> PostFoodBooking(FoodBookingDTO foodBooking)
        {
            // Check if the food booking menu id exists in the menus database context.
            var menuExists = await _context.Menus.FindAsync(foodBooking.MenuId);

            // Validate events via Events service API.
            var client = _httpClientFactory.CreateClient("Events");
            HttpResponseMessage? eventApiResponse = null;

            try
            {
                eventApiResponse = await client.GetAsync($"api/Events/{foodBooking.EventId}");
            }
            catch (HttpRequestException e)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, new ProblemDetails
                {
                    Title = "Events Service Unavailable",
                    Detail = $"Failed to reach Events service: {e.Message}",
                    Status = StatusCodes.Status503ServiceUnavailable
                });
            }

            if (!eventApiResponse.IsSuccessStatusCode)
            {
                return NotFound(new ProblemDetails
                {
                    Title = "Event not found",
                    Detail = $"Event with the id {foodBooking.EventId} does not exist.",
                    Status = StatusCodes.Status404NotFound
                });
            }

            // Check if the food booking menu id exists as well as checking if there is a valid number of guests input.
            if (menuExists != null && foodBooking.NumberOfGuests > 0)
            {
                // Check if the client has an existing booking for the same menu.
                if (_context.FoodBookings.Any(fb => fb.ClientReferenceId == foodBooking.ClientReferenceId && fb.MenuId == foodBooking.MenuId)){
                    return Conflict(new { message = $"The client with {foodBooking.ClientReferenceId} has an existing booking for the menu {foodBooking.MenuId}" });
                }

                // Creates a new food booking object.
                FoodBooking newBooking = new FoodBooking()
                {
                    EventId = foodBooking.EventId,
                    ClientReferenceId = foodBooking.ClientReferenceId,
                    MenuId = foodBooking.MenuId,
                    NumberOfGuests = foodBooking.NumberOfGuests
                };

                // Adds the new booking to the database context and saves changes.
                try
                {
                    _context.FoodBookings.Add(newBooking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new ProblemDetails
                    {
                        Title = "Database Update Failed",
                        Detail = $"Could not save the new food booking: {e.Message}",
                        Status = StatusCodes.Status500InternalServerError
                    });
                }

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
                return BadRequest(new ProblemDetails
                {
                    Title = "Food Booking POST Request Failure",
                    Detail = $"Failed to POST a new food booking: {foodBooking}",
                    Status = StatusCodes.Status400BadRequest
                });
            }
        }

        // DELETE: api/FoodBookings/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteFoodBooking(int id)
        {
            var foodBooking = await _context.FoodBookings.FindAsync(id);
            if (foodBooking == null)
            {
                // return NotFound($"A food booking with the id: {id} could not be found for deletion!");
                return NotFound(new ProblemDetails
                {
                    Title = "Food Booking Deletion Error!",
                    Detail = $"A food booking with the id: {id} could not be found for deletion!",
                    Status = StatusCodes.Status404NotFound
                });
            }

            try
            {
                _context.FoodBookings.Remove(foodBooking);
                await _context.SaveChangesAsync();
            }
            // Catches concurrency exceptions during deletion.
            catch (DbUpdateConcurrencyException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ProblemDetails
                {
                    Title = "Food Booking Deletion Error!",
                    Detail = $"Could not delete the food booking: {e.Message}",
                    Status = StatusCodes.Status500InternalServerError
                });
            }

            // Confirm deletion with the FoodBookingId.
            return Ok(new { FoodBookingId = id });
        }
    }
}
