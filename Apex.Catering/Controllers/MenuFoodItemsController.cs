using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Apex.Catering.Data;

namespace Apex.Catering.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuFoodItemsController : ControllerBase
    {
        private readonly CateringDbContext _context;

        public MenuFoodItemsController(CateringDbContext context)
        {
            _context = context;
        }

        // GET: api/MenuFoodItems
        [HttpGet("/api/GetMenuFoodItem")]
        public async Task<ActionResult<IEnumerable<MenuFoodItem>>> GetMenuFoodItems()
        {
            // Retrieve all Menu-FoodItem links
            var menuFoodItems = await _context.MenuFoodItems.ToListAsync();
            // If no links are found, return NoContent
            if (menuFoodItems.Count == 0)
            {
                return NoContent();
            }
            return menuFoodItems;
        }

        // GET: api/MenuFoodItems/5
        [HttpGet("/api/GetMenuFoodItem/{id}")]
        public async Task<ActionResult<MenuFoodItem>> GetMenuFoodItem(int id)
        {
            // Retrieve a specific Menu-FoodItem link via id.
            var menuFoodItem = await _context.MenuFoodItems.FindAsync(id);

            if (menuFoodItem == null)
            {
                return NotFound(new ProblemDetails
                {
                    Title = "Menu-FoodItem Link Not Found",
                    Detail = $"No link found with the Menu ID: {id}.",
                    Status = StatusCodes.Status404NotFound,
                });
            }

            return menuFoodItem;
        }

        // PUT: api/MenuFoodItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("/api/PutMenuFoodItem/{id}")]
        public async Task<IActionResult> PutMenuFoodItem(int id, MenuFoodItem menuFoodItem)
        {
            // Ensure the route id matches the body MenuId
            if (id != menuFoodItem.MenuId)
            {
                return BadRequest(new ProblemDetails
                {
                    Title = "Invalid Request",
                    Detail = $"Route id {id} does not match the body MenuId {menuFoodItem.MenuId}",
                    Status = StatusCodes.Status400BadRequest,
                });
            }

            _context.Entry(menuFoodItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                // Check if the Menu-FoodItem link exists before concluding it's a concurrency issue
                if (!MenuFoodItemExists(id))
                {
                    return NotFound(new ProblemDetails
                    {
                        Title = "Menu-FoodItem Link Not Found",
                        Detail = $"No link found with the Menu ID: {id}.",
                        Status = StatusCodes.Status404NotFound,
                    });
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new ProblemDetails
                {
                    Title = "Menu-FoodItem Update Concurrency Error",
                    Detail = $"Could not update the Menu-FoodItem link: {e.Message}",
                    Status = StatusCodes.Status500InternalServerError
                });
            }

            return NoContent();
        }

        // POST: api/MenuFoodItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/api/PostMenuFoodItem")]
        public async Task<ActionResult<MenuFoodItem>> PostMenuFoodItem(MenuFoodItem menuFoodItem)
        {
            try
            {
                _context.MenuFoodItems.Add(menuFoodItem);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                // Check for conflict based on MenuId before concluding it's an internal server error.
                if (MenuFoodItemExists(menuFoodItem.MenuId))
                {
                    return Conflict(new ProblemDetails
                    {
                        Title = "Conflict",
                        Detail = $"A link with the Menu ID: {menuFoodItem.MenuId} already exists.",
                        Status = StatusCodes.Status409Conflict,
                    });
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new ProblemDetails
                {
                    Title = "Database Update Error",
                    Detail = $"An error occurred while trying to add the Menu-FoodItem link: {e.Message}",
                    Status = StatusCodes.Status500InternalServerError,
                });
            }

            // Return the created Menu-FoodItem link with a 201 status code.
            return CreatedAtAction("GetMenuFoodItem", new { id = menuFoodItem.MenuId }, menuFoodItem);
        }

        // DELETE: api/MenuFoodItems/5/1
        [HttpDelete("/api/DeleteMenuFoodItem/{MenuId}/{FoodItemId}")]
        public async Task<IActionResult> DeleteMenuFoodItem(int MenuId, int FoodItemId)
        {
            // Retrieve the specific Menu-FoodItem link via composite keys.
            var menuFoodItem = await _context.MenuFoodItems.FindAsync(MenuId, FoodItemId);
            if (menuFoodItem == null)
            {
                return NotFound(new ProblemDetails
                {
                    Title = "Menu-FoodItem Link Not Found",
                    Detail = $"No link found between Menu ID: {MenuId} and FoodItem ID: {FoodItemId}.",
                    Status = StatusCodes.Status404NotFound,
                });
            }

            try
            {
                _context.MenuFoodItems.Remove(menuFoodItem);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                // Handle potential database update exceptions during deletion.
                return StatusCode(StatusCodes.Status500InternalServerError, new ProblemDetails
                {
                    Title = "Internal Server Error",
                    Detail = $"An error occurred while trying to delete the Menu-FoodItem link: {e.Message}",
                    Status = StatusCodes.Status500InternalServerError,
                });
            }

            // Return the deleted MenuId and FoodItemId for confirmation.
            return Ok(new { MenuId, FoodItemId });
        }

        // Method to check if a Menu-FoodItem link exists based on MenuId.
        private bool MenuFoodItemExists(int id)
        {
            return _context.MenuFoodItems.Any(e => e.MenuId == id);
        }
    }
}
