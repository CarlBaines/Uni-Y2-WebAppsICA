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
    public class IndexModel : PageModel
    {
        private readonly Apex.Events.Data.EventsDbContext _context;

        public IndexModel(Apex.Events.Data.EventsDbContext context)
        {
            _context = context;
        }

        // IList of Staff to hold the list of staff members
        public IList<Staff> Staff { get;set; } = default!;

        // OnGetAsync method to retrieve the list of staff members asynchronously
        public async Task OnGetAsync()
        {
            Staff = await _context.Staff.ToListAsync();
        }
    }
}
