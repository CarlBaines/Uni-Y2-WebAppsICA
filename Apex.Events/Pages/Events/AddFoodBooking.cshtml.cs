using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Apex.Events.Data;
using Apex.Events.Services;
using Apex.Events.DTOs;

namespace Apex.Events.Pages.Events
{
    public class AddFoodBookingModel : PageModel
    {
        private readonly Apex.Events.Data.EventsDbContext _context;
        private readonly FoodBookingsService _foodBookingsService;
        private readonly MenuService _menuService;

        public AddFoodBookingModel(Apex.Events.Data.EventsDbContext context, FoodBookingsService foodBookingsService, MenuService menuService)
        {
            _context = context;
            _foodBookingsService = foodBookingsService;
            _menuService = menuService;
        }

        // On get method to load the page
        public async Task<IActionResult> OnGetAsync(int id)
        {
            EventId = id;
            await PopulateMenusAsync(); // Populate the menu options
            return Page();
        }

        // Bind properties for form inputs
        [BindProperty]
        public int EventId { get; set; }
        [BindProperty]
        public int? SelectedMenuId { get; set; }
        [BindProperty]
        public int? ClientReferenceId { get; set; }
        [BindProperty]
        public int? NumberOfGuests { get; set; }

        // List of menus for the dropdown
        public List<SelectListItem> Menus { get; set; } = [];


        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // Validate user inputs
            if (!SelectedMenuId.HasValue)
            {
                ModelState.AddModelError(nameof(SelectedMenuId), "Please select a menu.");
            }

            if (!ClientReferenceId.HasValue)
            {
                ModelState.AddModelError(nameof(ClientReferenceId), "Please enter a client reference Id.");
            }

            if(!NumberOfGuests.HasValue || NumberOfGuests <= 0)
            {
                ModelState.AddModelError(nameof(NumberOfGuests), "Please enter a valid number of guests.");
            }

            // If model state is invalid, reload the page.
            if (!ModelState.IsValid)
            {
                await PopulateMenusAsync();
                return Page();
            }

            // try catch block to handle any errors during food booking creation
            try
            {
                var booking = new FoodBookingDTO
                {
                    EventId = EventId,
                    MenuId = SelectedMenuId!.Value,
                    ClientReferenceId = ClientReferenceId!.Value,
                    NumberOfGuests = NumberOfGuests!.Value
                };
                await _foodBookingsService.CreateFoodBookingAsync(booking); 
            }
            catch (HttpRequestException e)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred during food booking creation: {e.Message}");
                await PopulateMenusAsync();
                return Page();
            }

            // Redirect to the event details page after successful creation passing the event id.
            return RedirectToPage("./Details", new { id = EventId });
        }

        // Helper method to populate the menu options for the dropdown.
        private async Task PopulateMenusAsync()
        {
            Menus = await _menuService.GetMenuTypesSelectListAsync();
        }
    }
}
