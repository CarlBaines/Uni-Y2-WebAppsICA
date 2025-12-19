using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Apex.Events.Data;
using Apex.Events.Services;
using Microsoft.EntityFrameworkCore;
using Apex.Events.DTOs;

namespace Apex.Events.Pages.Events
{
    public class CreateModel : PageModel
    {
        private readonly Apex.Events.Data.EventsDbContext _context;
        private readonly EventTypesService _eventTypesService;
        private readonly VenuesService _venuesService;

        public List<SelectListItem> EventTypeItems { get; set; } = [];
        public List<SelectListItem> VenueItems { get; set; } = [];

        public CreateModel(Apex.Events.Data.EventsDbContext context, EventTypesService eventTypesService, VenuesService venuesService, MenuService menuService)
        {
            _context = context;
            _eventTypesService = eventTypesService;
            _venuesService = venuesService;
        }

        public async Task<IActionResult> OnGetAsync(int eventId)
        {
            await PopulateDropdownsAsync();
            return Page();
        }

        [BindProperty]
        public Event Event { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdownsAsync();
                return Page();
            }

            try
            {
                _context.Events.Add(Event);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                ModelState.AddModelError(string.Empty, $"A database error occurred during event creation: {e.Message}. Please try again!");
                await PopulateDropdownsAsync();
                return Page();
            }

            return RedirectToPage("./Index");
        }

        private async Task PopulateDropdownsAsync()
        {
            EventTypeItems = await _eventTypesService.GetEventTypesSelectListAsync();
            VenueItems = await _venuesService.GetVenuesSelectListAsync();
        }
    }
}
