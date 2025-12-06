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

namespace Apex.Events.Pages.Events
{
    public class CreateModel : PageModel
    {
        private readonly Apex.Events.Data.EventsDbContext _context;
        private readonly EventTypesService _eventTypesService;

        public List<SelectListItem> EventTypeItems { get; set; } = [];

        public CreateModel(Apex.Events.Data.EventsDbContext context, EventTypesService eventTypesService)
        {
            _context = context;
            _eventTypesService = eventTypesService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            // Populate EventTypes dropdown
            EventTypeItems = await _eventTypesService.GetEventTypesSelectListAsync();

            return Page();
        }

        [BindProperty]
        public Event Event { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Populate EventTypes dropdown
                EventTypeItems = await _eventTypesService.GetEventTypesSelectListAsync();
                return Page();
            }

            try
            {
                _context.Events.Add(Event);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                ModelState.AddModelError(string.Empty, $"A database error occurred during event creation: {e.Message}. Please try again!");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
