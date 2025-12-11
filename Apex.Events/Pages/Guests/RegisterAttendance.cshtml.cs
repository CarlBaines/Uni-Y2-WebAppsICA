using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Apex.Events.Data;

namespace Apex.Events.Pages.Guests
{
    public class RegisterAttendanceModel : PageModel
    {
        private readonly Apex.Events.Data.EventsDbContext _context;

        public RegisterAttendanceModel(Apex.Events.Data.EventsDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventId");
        ViewData["GuestId"] = new SelectList(_context.Guests, "GuestId", "GuestId");
            return Page();
        }

        [BindProperty]
        public GuestBooking GuestBooking { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.GuestBookings.Add(GuestBooking);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Details", new { id = GuestBooking.GuestId });
        }
    }
}
