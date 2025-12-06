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
    public class DetailsModel : PageModel
    {
        private readonly Apex.Events.Data.EventsDbContext _context;

        public DetailsModel(Apex.Events.Data.EventsDbContext context)
        {
            _context = context;
        }

        public Event Event { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Retrieve GuestBookings and associated Guests
            var evt = await _context.Events
                .Include(e => e.GuestBookings!)
                .ThenInclude(gb => gb.Guest)
                .FirstOrDefaultAsync(m => m.EventId == id);

            if (evt == null)
            {
                return NotFound(new ProblemDetails
                {
                    Title = "Event Not Found",
                    Detail = $"No event found with ID {id}.",
                    Status = 404
                });
            }
            Event = evt;
            return Page();
        }
    }
}
