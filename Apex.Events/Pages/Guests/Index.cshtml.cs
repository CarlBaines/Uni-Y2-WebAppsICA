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
    public class IndexModel : PageModel
    {
        private readonly Apex.Events.Data.EventsDbContext _context;

        public IndexModel(Apex.Events.Data.EventsDbContext context)
        {
            _context = context;
        }

        // IList is used here to represent a collection of Guest entities.
        public IList<Guest> Guest { get;set; } = default!;

        // OnGet async method to fetch the list of guests including their bookings.
        public async Task OnGetAsync()
        {
            Guest = await _context.Guests
                .Include(g => g.GuestBookings)
                .ToListAsync();
        }
    }
}
