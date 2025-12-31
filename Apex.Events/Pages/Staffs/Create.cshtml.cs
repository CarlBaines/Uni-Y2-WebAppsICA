using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Apex.Events.Data;
using Microsoft.EntityFrameworkCore;

namespace Apex.Events.Pages.Staffs
{
    public class CreateModel : PageModel
    {
        private readonly Apex.Events.Data.EventsDbContext _context;

        public CreateModel(Apex.Events.Data.EventsDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Staff Staff { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Check for duplicate staff input by first name, last name and role.
            var existingStaff = await _context.Staff
                .FirstOrDefaultAsync(s => s.FirstName == Staff.FirstName &&
                                           s.LastName == Staff.LastName &&
                                           s.Role == Staff.Role);
            
            if(existingStaff != null)
            {
                ModelState.AddModelError(string.Empty, "A staff member with this name and role already exists.");
                return Page();
            }

            try
            {
                _context.Staff.Add(Staff);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e)
            {
                ModelState.AddModelError(string.Empty, $"Database Error occurred during staff creation: {e.Message}. Please try again!");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
