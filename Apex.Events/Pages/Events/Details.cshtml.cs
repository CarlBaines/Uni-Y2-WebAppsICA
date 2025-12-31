using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Apex.Events.Data;
using Apex.Events.Services;
using Apex.Events.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Apex.Events.Pages.Events
{
    public class DetailsModel : PageModel
    {
        private readonly Apex.Events.Data.EventsDbContext _context;
        private readonly FoodBookingsService _foodBookingsService;
        private readonly VenuesService _venuesService;

        public DetailsModel(Apex.Events.Data.EventsDbContext context, FoodBookingsService foodBookingsService, VenuesService venuesService)
        {
            _context = context;
            _foodBookingsService = foodBookingsService;
            _venuesService = venuesService;
        }

        // Display properties to hold Event details and associated FoodBookings
        public Event Event { get; set; } = default!;
        public IReadOnlyList<FoodBookingDTO> FoodBookings { get; set; } = [];
        // Display Property to hold Venue name
        public string? VenueName { get; set; }
        // Display property to hold list of venues
        public List<SelectListItem> Venues { get; set; } = [];

        // Bind property for the user-selected venue code from the dropdown
        [BindProperty]
        public string? SelectedVenueCode { get; set; }

        [BindProperty]
        public int EventId { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Retrieve GuestBookings and associated Guests
            var evt = await _context.Events
                .Include(e => e.GuestBookings!)
                .ThenInclude(gb => gb.Guest)
                .FirstOrDefaultAsync(m => m.EventId == id);

            if (evt == null)
            {
                return NotFound(new ProblemDetails
                {
                    Title = "Event Not Found",
                    Detail = $"No event found with ID {id}.",
                    Status = 404
                });
            }
            Event = evt;
            EventId = evt.EventId;

            // Set the selected venue to the event's current venue
            SelectedVenueCode = evt.VenueCode;

            // Retrieve FoodBookings using the service
            FoodBookings = (await _foodBookingsService.GetFoodBookingsForEventAsync(evt.EventId)).ToList();

            // Retrieve Venue name using the service
            VenueName = await _venuesService.GetVenueNameAsync(evt.VenueCode);

            Venues = await _venuesService.GetVenuesSelectListAsync();   

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Validate selection from dropdown.
            if (string.IsNullOrWhiteSpace(SelectedVenueCode))
            {
                ModelState.AddModelError(string.Empty, "Please select a venue to reserve.");
            }   

            // Retrieve the event from the hidden eventId field.
            var evt = await _context.Events
                .Include(e => e.GuestBookings!)
                .ThenInclude(gb => gb.Guest)
                .FirstOrDefaultAsync(e => e.EventId == EventId);

            if(evt == null)
            {
                return NotFound(new ProblemDetails
                {
                    Title = "Event Not Found",
                    Detail = $"No event found with ID {EventId}.",
                    Status = 404
                });
            }

            if (!ModelState.IsValid)
            {
                // Rebuild display data
                await RebuildVenueDropdownAsync(evt);
                Event = evt;
                FoodBookings = (await _foodBookingsService.GetFoodBookingsForEventAsync(evt.EventId)).ToList();
                VenueName = await _venuesService.GetVenueNameAsync(evt.VenueCode);
                Venues = await _venuesService.GetVenuesSelectListAsync();
                return Page();
            }

            // Store the old and new venue codes for comparison.
            var oldVenueCode = evt.VenueCode;
            var newVenueCode = SelectedVenueCode!;

            try
            {
                //await _venuesService.ChangeVenueReservationAsync(
                //    evt.EventType,
                //    evt.EventDate.ToDateTime(TimeOnly.MinValue),
                //    oldVenueCode,
                //    newVenueCode
                //);

                // Update the event's venue to the selected venue from the dropdown.
                evt.VenueCode = newVenueCode;

                await _context.SaveChangesAsync();

                // Redirect to the same page to reflect changes.
                return RedirectToPage("./Details", new { id = evt.EventId });
            }
            catch(Exception e)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred whilst reserving a venue: {e.Message}");
                // Rebuild display data
                await RebuildVenueDropdownAsync(evt);
                Event = evt;
                FoodBookings = (await _foodBookingsService.GetFoodBookingsForEventAsync(evt.EventId)).ToList();
                VenueName = await _venuesService.GetVenueNameAsync(evt.VenueCode);
                Venues = await _venuesService.GetVenuesSelectListAsync();
                return Page();
            }
        }

        private async Task RebuildVenueDropdownAsync(Event evt)
        {
            var availableVenues = await _venuesService.GetAvailableSuitableVenuesAsync(
                evt.EventType, evt.EventDate.ToDateTime(TimeOnly.MinValue)
            );

            Venues = availableVenues
                .Select(av => new SelectListItem
                {
                    Value = av.Code,
                    Text = av.Name,
                }).ToList();

            // Check if the event has an associated venue and if the current venue is not in the available venues list
            if (!string.IsNullOrWhiteSpace(evt.VenueCode) && Venues.All(v => v.Value != evt.VenueCode))
            {
                var currentVenueText = evt.VenueCode;
                if (!string.IsNullOrWhiteSpace(VenueName))
                {
                    currentVenueText = VenueName + " (Currently Reserved)";
                }
                Venues.Insert(0, new SelectListItem
                {
                    Value = evt.VenueCode,
                    Text = currentVenueText
                });
            }
        
            // By default, select the current venue in the dropdown.
            SelectedVenueCode = evt.VenueCode;
        }
    }
}
