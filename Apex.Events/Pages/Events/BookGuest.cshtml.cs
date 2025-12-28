using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Apex.Events.Data;
using Microsoft.EntityFrameworkCore;

namespace Apex.Events.Pages.Events
{
    public class BookGuestModel : PageModel
    {
        private readonly Apex.Events.Data.EventsDbContext _context;

        public BookGuestModel(Apex.Events.Data.EventsDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Guest Guest { get; set; } = new Guest();

        // Bind the target Event id.
        [BindProperty]
        public int EventId { get; set; } = default!;

        public IActionResult OnGet(int id)
        {
            if (id <= 0)
            {
                return NotFound(new ProblemDetails
                {
                    Title = "Invalid Event Id",
                    Detail = "The provided Event Id is invalid.",
                    Status = 404
                });
            }

            var eventExists = _context.Events.Any(e => e.EventId == id);
            if (!eventExists)
            {
                return NotFound(new ProblemDetails
                {
                    Title = "Event Not Found",
                    Detail = "The specified event does not exist.",
                    Status = 404
                });
            }
            // Set the EventId for use in the form.
            EventId = id;
            return Page();
        }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(EventId <= 0)
            {
                ModelState.AddModelError(string.Empty, "Invalid event id");
                return Page();
            }

            // Check if the event exists.
            var eventExists = await _context.Events.AnyAsync(e => e.EventId == EventId);
            if(!eventExists)
            {
                ModelState.AddModelError(string.Empty, $"The selected event with the id: {EventId} was not found.");
                return Page();
            }

            // Add the guest to the database context.
            try
            {
                _context.Guests.Add(Guest);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                ModelState.AddModelError(string.Empty, $"A database error occurred during guest creation: {e.Message}. Please try again.");
                return Page();
            }

            // Prevent duplicate bookings of the same guest to the same event.
            var existingBooking = await _context.GuestBookings
                .AnyAsync(gb => gb.GuestId == Guest.GuestId && gb.EventId == EventId);

            if (existingBooking)
            {
                ModelState.AddModelError(string.Empty, $"The guest is already booked for the selected event.");
                return Page();
            }

            // Create the booking.
            var booking = new GuestBooking
            {
                GuestId = Guest.GuestId,
                EventId = EventId
            };

            try
            {
                _context.GuestBookings.Add(booking);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                ModelState.AddModelError(string.Empty, $"A database error occurred during guest booking creation: {e.Message}. Please try again.");
                return Page();
            }

            return RedirectToPage("./Details", new { id = EventId });
        }
    }
}
