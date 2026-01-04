using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Apex.Events.Data;

namespace Apex.Events.Pages.Events
{
    public class DeleteModel : PageModel
    {
        private readonly Apex.Events.Data.EventsDbContext _context;

        public DeleteModel(Apex.Events.Data.EventsDbContext context)
        {
            _context = context;
        }

        // Bind the Event model to the page.
        [BindProperty]
        public Event Event { get; set; } = default!;

        // On get method to retrieve the event details for deletion confirmation.
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Retrieve the event from the database.
            var evt = await _context.Events.FirstOrDefaultAsync(m => m.EventId == id);

            if (evt == null)
            {
                return NotFound(new ProblemDetails
                {
                    Title = "Event Not Found",
                    Detail = $"No event found with the ID: {id}.",
                    Status = 404,
                });
            }
            Event = evt;
            return Page();
        }

        // On post method to handle the deletion of the event.
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

            // Retrieve the event to be deleted.
            var evt = await _context.Events.FindAsync(id);
            if (evt != null)
            {
                Event = evt;
                // try catch block to handle potential database update exceptions when deleting the event.
                try
                {
                    _context.Events.Remove(Event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException e)
                {
                    ModelState.AddModelError(string.Empty, $"A Database Error occurred during event deletion: {e.Message}. Please try again!");
                    return Page();
                }
            }

            // Redirect to the index page after successful deletion.
            return RedirectToPage("./Index");
        }
    }
}
