using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Apex.Events.Data;
using Apex.Events.Services;

namespace Apex.Events.Pages.Events
{
    public class IndexModel : PageModel
    {
        private readonly Apex.Events.Data.EventsDbContext _context;
        private readonly FoodBookingsService _foodBookingsService;

        public IndexModel(Apex.Events.Data.EventsDbContext context, FoodBookingsService foodBookingsService)
        {
            _context = context;
            _foodBookingsService = foodBookingsService;
        }

        public IList<Event> Event { get; set; } = default!;

        // Dictionary for checking if an event has a food booking
        public Dictionary<int, bool> EventFoodBookingCheck { get; set; } = new();

        public async Task OnGetAsync()
        {
            Event = await _context.Events.ToListAsync();
            // Check for food bookings for each event
            foreach (var evt in Event)
            {
                // Asynchronously get food bookings for the event
                var bookings = await _foodBookingsService.GetFoodBookingsForEventAsync(evt.EventId);
                // Update the dictionary with the result
                EventFoodBookingCheck[evt.EventId] = bookings.Count > 0;
            }
        }
    }
}
