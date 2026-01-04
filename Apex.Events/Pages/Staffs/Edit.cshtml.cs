using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Apex.Events.Data;

namespace Apex.Events.Pages.Staffs
{
    public class EditModel : PageModel
    {
        private readonly Apex.Events.Data.EventsDbContext _context;

        public EditModel(Apex.Events.Data.EventsDbContext context)
        {
            _context = context;
        }

        // Bind the staff model to the page.
        [BindProperty]
        public Staff Staff { get; set; } = default!;

        // OnGetAsync method to retrieve the staff record for editing.
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Retrieve the staff record from the database context.
            var staff =  await _context.Staff.FirstOrDefaultAsync(m => m.EventStaffId == id);
            if (staff == null)
            {
                return NotFound();
            }
            Staff = staff;
            return Page();
        }

        // OnPostAsync method to handle the form submission for editing the staff record.
        public async Task<IActionResult> OnPostAsync()
        {
            // Validate the model state.
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Mark the staff entity as modified.
            _context.Attach(Staff).State = EntityState.Modified;

            // try, catch block to handle concurrency exceptions when saving an edited staff record.
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Check if the staff record still exists in the database.
                if (!StaffExists(Staff.EventStaffId))
                {
                    return NotFound();
                }
                ModelState.AddModelError(string.Empty, "Unable to save changes. The staff record was already modified.");
                return Page();
            }

            // Redirect to the index page after successful edit.
            return RedirectToPage("./Index");
        }

        // Helper method to check if a staff record exists by ID.
        private bool StaffExists(int id)
        {
            return _context.Staff.Any(e => e.EventStaffId == id);
        }
    }
}
