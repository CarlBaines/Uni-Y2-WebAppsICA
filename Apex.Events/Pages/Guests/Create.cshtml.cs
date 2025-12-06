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

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Guest Guest { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

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

            return RedirectToPage("./Index");
        }
    }
}
