using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Apex.Events.Data;

namespace Apex.Events.Pages.Guests
{
    public class EditModel : PageModel
    {
        private readonly Apex.Events.Data.EventsDbContext _context;

        public EditModel(Apex.Events.Data.EventsDbContext context)
        {
            _context = context;
        }

        // Bind property to hold the Guest entity
        [BindProperty]
        public Guest Guest { get; set; } = default!;

        // On get method to retrieve the guest by id for editing.
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Retrieve the guest from the database
            var guest =  await _context.Guests.FirstOrDefaultAsync(m => m.GuestId == id);
            if (guest == null)
            {
                return NotFound();
            }
            Guest = guest;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // Validate the model state
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Mark the guest entity as modified
            _context.Attach(Guest).State = EntityState.Modified;

            // try, catch block to handle concurrency exceptions when saving the edited guest.
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Check if the guest still exists in the database
                if (!GuestExists(Guest.GuestId))
                {
                    return NotFound();
                }
                ModelState.AddModelError(string.Empty, "Unable to save changes. The guest was already modified. Please reload the page and try again.");
                return Page();
            }

            // Redirect to the index page after successful edit
            return RedirectToPage("./Index");
        }

        // Helper method to check if a guest exists by id
        private bool GuestExists(int id)
        {
            return _context.Guests.Any(e => e.GuestId == id);
        }
    }
}
