using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Apex.Events.Data;
using Microsoft.EntityFrameworkCore;

namespace Apex.Events.Pages.Guests
{
    public class CreateModel : PageModel
    {
        private readonly Apex.Events.Data.EventsDbContext _context;

        public CreateModel(Apex.Events.Data.EventsDbContext context)
        {
            _context = context;
        }

        // On get method to display the create guest page
        public IActionResult OnGet()
        {
            return Page();
        }

        // Bind property to hold the guest data
        [BindProperty]
        public Guest Guest { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // Validate model state.
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Check for duplicate guest input by email
            var existingGuest = await _context.Guests
                .FirstOrDefaultAsync(g => g.Email == Guest.Email);

            // If a guest with the same email already exists, add a model error and return the page.
            if (existingGuest != null)
            {
                ModelState.AddModelError("Guest.Email", "A guest with this email already exists.");
                return Page();
            }

            // try, catch block to handle potential database concurrency issues when adding a new guest
            try
            {
                _context.Guests.Add(Guest);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e)
            {
                ModelState.AddModelError(string.Empty, $"Database Error occurred during guest creation: {e.Message}. Please try again!");
                return Page();
            }

            // Redirect to the index page upon successful creation
            return RedirectToPage("./Index");
        }
    }
}
