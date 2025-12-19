using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Apex.Events.Data;
using Apex.Events.Services;

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

        public async Task<IActionResult> OnGetAsync(int eventId)
        {
            EventId = eventId;
            await PopulateMenusAsync();
            return Page();
        }

        [BindProperty]
        public int EventId { get; set; }
        [BindProperty]
        public int? SelectedMenuId { get; set; }
        [BindProperty]
        public int? ClientReferenceId { get; set; }
        [BindProperty]
        public int? NumberOfGuests { get; set; }

        public List<SelectListItem> Menus { get; set; }


        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await PopulateMenusAsync();
                return Page();
            }


            return RedirectToPage("./Index");
        }

        private async Task PopulateMenusAsync()
        {
            Menus = await _menuService.GetMenuTypesSelectListAsync();
        }
    }
}
