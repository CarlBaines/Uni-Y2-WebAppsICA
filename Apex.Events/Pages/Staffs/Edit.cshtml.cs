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

        [BindProperty]
        public Staff Staff { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff =  await _context.Staff.FirstOrDefaultAsync(m => m.EventStaffId == id);
            if (staff == null)
            {
                return NotFound();
            }
            Staff = staff;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Staff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(Staff.EventStaffId))
                {
                    return NotFound();
                }
                ModelState.AddModelError(string.Empty, "Unable to save changes. The staff record was already modified.");
                return Page();
            }

            return RedirectToPage("./Index");
        }

        private bool StaffExists(int id)
        {
            return _context.Staff.Any(e => e.EventStaffId == id);
        }
    }
}
