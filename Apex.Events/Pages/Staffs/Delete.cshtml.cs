using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Apex.Events.Data;
using System.Data;

namespace Apex.Events.Pages.Staffs
{
    public class DeleteModel : PageModel
    {
        private readonly Apex.Events.Data.EventsDbContext _context;

        public DeleteModel(Apex.Events.Data.EventsDbContext context)
        {
            _context = context;
        }

        // Bind property to staff entity
        [BindProperty]
        public Staff Staff { get; set; } = default!;

        // On get async method to retrieve staff details for deletion.
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Retrieve the staff record based on the provided id.
            var staff = await _context.Staff.FirstOrDefaultAsync(m => m.EventStaffId == id);

            if (staff == null)
            {
                return NotFound();
            }
            Staff = staff;
            return Page();
        }

        // On post async method to handle the deletion of the staff record.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Find the staff record to delete.
            var staff = await _context.Staff.FindAsync(id);
            if (staff != null)
            {
                Staff = staff;
                // try, catch block to handle potential concurrency exceptions during deletion.
                try
                {
                    _context.Staff.Remove(Staff);
                    await _context.SaveChangesAsync();
                }
                catch(DBConcurrencyException e)
                {
                    ModelState.AddModelError(string.Empty, $"Database Error occurred during staff record deletion: {e.Message}. Please try again!");
                    return Page();
                }
            }

            // Redirect to index page after successful deletion.
            return RedirectToPage("./Index");
        }
    }
}
