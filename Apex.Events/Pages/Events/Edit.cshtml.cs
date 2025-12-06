using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Apex.Events.Data;
using System.ComponentModel.DataAnnotations;

namespace Apex.Events.Pages.Events
{
    public class EditModel : PageModel
    {
        private readonly Apex.Events.Data.EventsDbContext _context;

        public EditModel(Apex.Events.Data.EventsDbContext context)
        {
            _context = context;
        }

        // This event is for display purposes only. It is not bound on POST.
        public Event? Event { get; set; }

        [BindProperty]
        public int EventId { get; set; }

        [BindProperty]
        [Required]
        [MaxLength(50)]
        // This property is bound on POST to allow editing of the EventName.
        public string EventName { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evt = await _context.Events.FirstOrDefaultAsync(m => m.EventId == id);
            if (evt == null)
            {
                return NotFound();
            }
            // Set the Event property for display
            // and initialise the bound properties.
            Event = evt;
            EventId = evt.EventId;
            EventName = evt.EventName;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // If the model state is invalid, re-fetch the Event for display.
                Event = await _context.Events.FirstOrDefaultAsync(m => m.EventId == EventId);
                return Page();
            }

            var evt = await _context.Events.FirstOrDefaultAsync(m => m.EventId == EventId);
            if(evt == null)
            {
                return NotFound();
            }

            // Updates only the EventName property.
            evt.EventName = EventName;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Check if the event still exists
                if (!await _context.Events.AnyAsync(e => e.EventId == EventId))
                {
                    return NotFound();
                }
                ModelState.AddModelError(string.Empty, "The event record was modified already. Please reload and try again.");
                return Page();
            }
            catch (DbUpdateException e)
            {
                ModelState.AddModelError(string.Empty, $"A Database Error occurred whilst editing an event: {e.Message}. Please try again.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
