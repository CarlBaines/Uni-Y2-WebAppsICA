using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Apex.Events.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Apex.Events.Pages.Guests
{
    public class RemoveGuestBookingModel : PageModel
    {
        private readonly Apex.Events.Data.EventsDbContext _context;

        public RemoveGuestBookingModel(Apex.Events.Data.EventsDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Guest Guest { get; set; } = default!;
        // Bind property to hold the list of GuestBookings
        public IList<GuestBooking> GuestBookings { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Include GuestBookings when retrieving the Guest
            var guest = await _context.Guests
                .Include(g => g.GuestBookings!)
                .ThenInclude(gb => gb.Event)
                .FirstOrDefaultAsync(m => m.GuestId == id);

            if (guest == null)
            {
                return NotFound();
            }
            Guest = guest;
            // Populate the GuestBookings property
            GuestBookings = guest.GuestBookings!.ToList();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var guestbooking = await _context.GuestBookings.FindAsync(id);
            if (guestbooking != null)
            {
                try
                {
                    _context.GuestBookings.Remove(guestbooking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException e)
                {
                    ModelState.AddModelError(string.Empty, $"A Database Error occurred during guest bookings deletion: {e.Message}");
                    return Page();
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
