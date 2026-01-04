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
    public class FoodItemsController : ControllerBase
    {
        private readonly CateringDbContext _context;

        public FoodItemsController(CateringDbContext context)
        {
            _context = context;
        }

        // GET: api/FoodItems
        [HttpGet("/api/FoodItems")]
        public async Task<ActionResult<IEnumerable<FoodItem>>> GetFoodItems()
        {
            // Retrieve all food items from the database context.
            var foodItems = await _context.FoodItems.ToListAsync();
            // If no food items are found, return a NoContent response.
            if (foodItems.Count == 0)
            {
                return NoContent();
            }
            return foodItems;
        }

        // GET: api/FoodItems/5
        [HttpGet("/api/FoodItems/{id}")]
        public async Task<ActionResult<FoodItem>> GetFoodItem(int id)
        {
            // Find the food item by its ID.
            var foodItem = await _context.FoodItems.FindAsync(id);

            if (foodItem == null)
            {
                return NotFound(new ProblemDetails
                {
                    Title = "Food Item Not Found",
                    Detail = $"No food item found with the ID: {id}.",
                    Status = StatusCodes.Status404NotFound,
                });
            }

            return foodItem;
        }

        // PUT: api/FoodItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("/api/PutFoodItem/{id}")]
        public async Task<IActionResult> PutFoodItem(int id, FoodItem foodItem)
        {
            // Validate that the route ID matches the body FoodItemId.
            if (id != foodItem.FoodItemId)
            {
                return BadRequest(new ProblemDetails
                {
                    Title = "Invalid Request",
                    Detail = $"Route id {id} does not match the body FoodItemId {foodItem.FoodItemId}",
                    Status = StatusCodes.Status400BadRequest,
                });
            }

            _context.Entry(foodItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                // Check if the food item exists before concluding it's a concurrency issue.
                if (!FoodItemExists(id))
                {
                    return NotFound(new ProblemDetails
                    {
                        Title = "Food Item Not Found",
                        Detail = $"No food item found with the ID: {id}.",
                        Status = StatusCodes.Status404NotFound,
                    });
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new ProblemDetails
                {
                    Title = "Food Item Update Concurrency Error",
                    Detail = $"Could not update the food item: {e.Message}",
                    Status = StatusCodes.Status500InternalServerError
                });
            }

            return NoContent();
        }

        // POST: api/FoodItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/api/PostFoodItem")]
        public async Task<ActionResult<FoodItem>> PostFoodItem(FoodItem foodItem)
        {
            try
            {
                _context.FoodItems.Add(foodItem);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ProblemDetails
                {
                    Title = "Database Update Error",
                    Detail = $"An error occurred while trying to add the food item to the database: {e.Message}",
                    Status = StatusCodes.Status500InternalServerError,
                });
            }
            // Return a CreatedAtAction response returning the id of the newly created food item.
            return CreatedAtAction("GetFoodItem", new { id = foodItem.FoodItemId }, foodItem);
        }

        // DELETE: api/FoodItems/5
        [HttpDelete("/api/DeleteFoodItem/{id}")]
        public async Task<IActionResult> DeleteFoodItem(int id)
        {
            // Find the food item by its ID.
            var foodItem = await _context.FoodItems.FindAsync(id);
            if (foodItem == null)
            {
                return NotFound(new ProblemDetails
                {
                    Title = "Food Item Not Found",
                    Detail = $"No food item found with the ID: {id}.",
                    Status = StatusCodes.Status404NotFound,
                });
            }

            try
            {
                _context.FoodItems.Remove(foodItem);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ProblemDetails
                {
                    Title = "Database Update Error",
                    Detail = $"An error occurred while trying to delete the food item from the database: {e.Message}",
                    Status = StatusCodes.Status500InternalServerError,
                });
            }

            // Return an OK response with the id of the deleted food item.
            return Ok(new { FoodItemId = id }); 
        }

        // Method to check if a food item exists by its ID.
        private bool FoodItemExists(int id)
        {
            return _context.FoodItems.Any(e => e.FoodItemId == id);
        }
    }
}
