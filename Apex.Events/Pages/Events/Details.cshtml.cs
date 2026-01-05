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
        // Display property for assigned staff
        public List<Staffing> AssignedStaff { get; set; } = [];
        // Display property for available staff dropdown (staff that are not assigned)
        public List<SelectListItem> AvailableStaff { get; set; } = [];

        public bool HasFirstAider { get; set; }

        // Bind property for the user-selected venue code from the dropdown
        [BindProperty]
        public string? SelectedVenueCode { get; set; }

        // Bind property for the hidden EventId field
        [BindProperty]
        public int EventId { get; set; }

        // Bind properties for adding staff
        [BindProperty]
        public int? SelectedStaffId { get; set; }
        [BindProperty]
        public string? NewStaffingName { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Retrieve GuestBookings, associated Guests and Staffing.
            var evt = await _context.Events
                .Include(e => e.GuestBookings!)
                    .ThenInclude(gb => gb.Guest)
                .Include(e => e.Staffings!)
                    .ThenInclude(s => s.Staff)
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

            // Retrieves the staff assigned to the event or an empty list if none are assigned
            AssignedStaff = evt.Staffings ?? [];

            // Determine if any assigned staff have the role of "First Aider"
            HasFirstAider = AssignedStaff.Any(s => s.Staff != null &&
                s.Staff.Role.Contains("First Aider", StringComparison.OrdinalIgnoreCase));

            // Retrieve IDs of assigned staff
            var assignedStaffIds = AssignedStaff.Select(s => s.EventStaffId).ToList();

            // Retrieve available staff for the dropdown (staff not already assigned to the event)
            var availableStaffList = await _context.Staff
                .Where(s => !assignedStaffIds.Contains(s.EventStaffId))
                .ToListAsync();

            AvailableStaff = availableStaffList.Select(s => new SelectListItem
            {
                Value = s.EventStaffId.ToString(),
                Text = $"{s.FirstName} {s.LastName} ({s.Role})"
            }).ToList();

            // Retrieve FoodBookings using the service
            FoodBookings = (await _foodBookingsService.GetFoodBookingsForEventAsync(evt.EventId)).ToList();

            // Retrieve Venue name using the service
            VenueName = await _venuesService.GetVenueNameAsync(evt.VenueCode);

            // Retrieve list of venues for the dropdown
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

            if (evt == null)
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
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred whilst reserving a venue: {e.Message}");
                // Rebuild display data
                Event = evt;
                FoodBookings = (await _foodBookingsService.GetFoodBookingsForEventAsync(evt.EventId)).ToList();
                VenueName = await _venuesService.GetVenueNameAsync(evt.VenueCode);
                Venues = await _venuesService.GetVenuesSelectListAsync();
                return Page();
            }
        }

        // Helper method to add staff to the event
        public async Task<IActionResult> OnPostAddStaffAsync()
        {
            // Validate selection from dropdown and staffing name.
            if (SelectedStaffId == null || SelectedStaffId == 0 || string.IsNullOrWhiteSpace(NewStaffingName))
            {
                ModelState.AddModelError(string.Empty, "Select a staff member and provide an assignment name.");
                return Page();
            }

            // Check if staff is already assigned to the event
            var existingStaffing = await _context.Staffings
                .FirstOrDefaultAsync(s => s.EventId == EventId && s.EventStaffId == SelectedStaffId);

            // If already assigned, return error
            if (existingStaffing != null)
            {
                ModelState.AddModelError(string.Empty, "Staff member is already assigned to this event.");
                return Page();
            }

            // Create new Staffing record
            var staffing = new Staffing
            {
                StaffingName = NewStaffingName,
                EventStaffId = SelectedStaffId.Value,
                EventId = EventId
            };

            // try, catch block to handle potential database errors when adding staff
            try
            {
                _context.Staffings.Add(staffing);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                ModelState.AddModelError(string.Empty, $"Error adding staff to the event: {e.Message}");
                return Page();
            }

            // Redirect to the same page to reflect changes.
            return RedirectToPage(new { id = EventId });
        }

        // Helper method to remove staff from an event.
        public async Task<IActionResult> OnPostRemoveStaffAsync(int staffingId)
        {
            // Retrieve the staffing record to be removed.
            var staffing = await _context.Staffings.FirstOrDefaultAsync(s => s.StaffingId == staffingId && s.EventId == EventId);

            if(staffing == null)
            {
                return NotFound();
            }

            // try, catch block to handle potential database errors when removing staff
            try
            {
                _context.Staffings.Remove(staffing);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                ModelState.AddModelError(string.Empty, $"Error occurred attempting to remove staff: {e.Message}");
                return Page();
            }

            // Redirect to the same page to reflect changes.
            return RedirectToPage(new { id = EventId });
        }


            
    }
       
}
