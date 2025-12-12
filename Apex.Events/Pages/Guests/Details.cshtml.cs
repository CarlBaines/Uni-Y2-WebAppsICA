using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Apex.Events.Data;

namespace Apex.Events.Pages.Guests
{
    public class DetailsModel : PageModel
    {
        private readonly Apex.Events.Data.EventsDbContext _context;

        public DetailsModel(Apex.Events.Data.EventsDbContext context)
        {
            _context = context;
        }

        public Guest Guest { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Lazy load related GuestBookings
            var guest = await _context.Guests
                .Include(g => g.GuestBookings!)
                .ThenInclude(g => g.Event)
                .FirstOrDefaultAsync(m => m.GuestId == id);

            if (guest == null)
            {
                return NotFound();
            }

            Guest = guest;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int guestId)
        {
            // Load guest and guest bookings again
            var guest = await _context.Guests
                .Include(g => g.GuestBookings!)
                .ThenInclude(gb => gb.Event)
                .FirstOrDefaultAsync(g => g.GuestId == guestId);

            if(guest == null)
            {
                return NotFound();
            }

            foreach(var booking in guest.GuestBookings)
            {
                // Name of form field for the IsAttending checkbox
                var key = $"IsAttending_{booking.EventId}";

                // Check if the checkbox was checked in the form submission
                var isChecked = Request.Form.ContainsKey(key);

                // Update the IsAttending property
                booking.IsAttending = isChecked;
            }

            try
            {
                await _context.SaveChangesAsync();
                // Redirect back to the Details page for the same guest
                return RedirectToPage("./Details", new { id = guestId });

            }
            catch (DbUpdateException e)
            {
                ModelState.AddModelError(string.Empty, $"A database error occurred while updating attendance: {e.Message}. Please try again!");
                return Page();
            }
        }
    }
}
