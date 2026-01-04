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
    public class DeleteModel : PageModel
    {
        private readonly Apex.Events.Data.EventsDbContext _context;

        public DeleteModel(Apex.Events.Data.EventsDbContext context)
        {
            _context = context;
        }

        // Bind property to hold the Guest entity
        [BindProperty]
        public Guest Guest { get; set; } = default!;

        // On get method to retrieve the guest details for confirmation
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Retrieve the guest entity based on the provided id
            var guest = await _context.Guests.FirstOrDefaultAsync(m => m.GuestId == id);

            if (guest == null)
            {
                return NotFound();
            }
            Guest = guest;

            return Page();
        }

        // On post method to handle the deletion of the guest
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Find the guest entity to delete
            var guest = await _context.Guests.FindAsync(id);
            if (guest != null)
            {
                Guest = guest;
                // try, catch block to handle potential concurrency issues during deletion
                try
                {
                    _context.Guests.Remove(Guest);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException e)
                {
                    ModelState.AddModelError(string.Empty, $"Database Error occurred during guest deletion: {e.Message}. Please try again!");
                    return Page();
                }
            }

            // Redirect to the index page after successful deletion
            return RedirectToPage("./Index");
        }
    }
}
