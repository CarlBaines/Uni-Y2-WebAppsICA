using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Apex.Events.Data;
using Apex.Events.Services;

namespace Apex.Events.Pages.Events
{
    public class CancelEventModel : PageModel
    {
        private readonly Apex.Events.Data.EventsDbContext _context;
        private readonly VenuesService _venuesService;

        public CancelEventModel(Apex.Events.Data.EventsDbContext context, VenuesService venuesService)
        {
            _context = context;
            _venuesService = venuesService;
        }

        // BindProperty for the Event entity.
        [BindProperty]
        public Event Event { get; set; } = default!;

        // Display property for venue name.
        public string? VenueName { get; set; }

        // Display property for assigned staff count.
        public int AssignedStaffCount { get; set; }

        // OnGetAsync method to retrieve event details.
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Retrieve the event including its staffings.
            var evt = await _context.Events
                .Include(e => e.Staffings)
                .FirstOrDefaultAsync(m => m.EventId == id);

            if (evt == null)
            {
                return NotFound(new ProblemDetails
                {
                    Title = "Event Not Found",
                    Detail = $"No event found with the ID: {id}.",
                    Status = 404,
                });
            }

            if (evt.IsCancelled)
            {
                // Return to index if the event is already cancelled.
                return RedirectToPage("./Index");
            }

            // Populate the Event property and related display properties.
            Event = evt;
            VenueName = await _venuesService.GetVenueNameAsync(evt.VenueCode);
            AssignedStaffCount = evt.Staffings?.Count ?? 0;

            return Page();
        }

        // OnPostAsync method to handle event cancellation.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound(new ProblemDetails
                {
                    Title = "Invalid Event ID",
                    Detail = "The event ID provided is null.",
                    Status = 404
                });
            }

            // Retrieve the event including its staffings.
            var evt = await _context.Events
                .Include(e => e.Staffings)
                .FirstOrDefaultAsync(e => e.EventId == id);

            if (evt == null)
            {
                return NotFound();
            }

            // try, catch block to handle cancellation.
            try
            {
                // Mark event as cancelled
                evt.IsCancelled = true;

                // Free staff by removing all staff assignments
                if(evt.Staffings != null && evt.Staffings.Count > 0)
                {
                    _context.Staffings.RemoveRange(evt.Staffings);
                }

                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                // Add model state error and repopulate properties for redisplay
                ModelState.AddModelError(string.Empty, $"A database error occurred during event cancellation: {e.Message}. Please try again!");
                Event = evt;
                VenueName = await _venuesService.GetVenueNameAsync(evt.VenueCode);
                AssignedStaffCount = evt.Staffings?.Count ?? 0;
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
