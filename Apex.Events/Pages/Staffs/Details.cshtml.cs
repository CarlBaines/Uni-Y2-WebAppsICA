using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Apex.Events.Data;

namespace Apex.Events.Pages.Staffs
{
    public class DetailsModel : PageModel
    {
        private readonly Apex.Events.Data.EventsDbContext _context;

        public DetailsModel(Apex.Events.Data.EventsDbContext context)
        {
            _context = context;
        }

        // Bind property to hold the Staff entity
        [BindProperty]
        public Staff Staff { get; set; } = default!;

        // Display property for upcoming assignments where staff is assigned.
        public List<Staffing> UpcomingAssignments { get; set; } = [];

        // On get async method to retrieve staff details
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Retrieve the staff entity based on the provided id
            var staff = await _context.Staff.FirstOrDefaultAsync(m => m.EventStaffId == id);
            if (staff == null)
            {
                return NotFound();
            }
            Staff = staff;

            // Retrieve upcoming assignments for the staff member
            var today = DateOnly.FromDateTime(DateTime.Today);
            UpcomingAssignments = await _context.Staffings
                .Include(s => s.Event)
                .Where(s => s.EventStaffId == id && s.Event != null && s.Event.EventDate >= today)
                .OrderBy(s => s.Event!.EventDate)
                .ToListAsync();

            return Page();
        }
    }
}
