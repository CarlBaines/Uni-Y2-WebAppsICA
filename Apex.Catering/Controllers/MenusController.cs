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
    public class MenusController : ControllerBase
    {
        private readonly CateringDbContext _context;

        public MenusController(CateringDbContext context)
        {
            _context = context;
        }

        // GET: api/Menus
        [HttpGet("/api/GetMenu")]
        public async Task<ActionResult<IEnumerable<Menu>>> GetMenus()
        {
            var menus = await _context.Menus.ToListAsync();
            if(menus.Count == 0)
            {
                return NoContent();
            }
            return menus;
        }

        // GET: api/Menus/5
        [HttpGet("/api/GetMenu/{id}")]
        public async Task<ActionResult<Menu>> GetMenu(int id)
        {
            var menu = await _context.Menus.FindAsync(id);

            if (menu == null)
            {
                return NotFound(new ProblemDetails
                {
                    Title = "Menu not found",
                    Status = StatusCodes.Status404NotFound,
                    Detail = $"No menu with ID {id} exists in the database."
                });
            }

            return menu;
        }

        // PUT: api/Menus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("/api/PutMenu/{id}")]
        public async Task<IActionResult> PutMenu(int id, Menu menu)
        {
            if (id != menu.MenuId)
            {
                return BadRequest(new ProblemDetails
                {
                    Title = "Invalid Request",
                    Status = StatusCodes.Status400BadRequest,
                    Detail = $"Route id {id} does not match the body MenuId {menu.MenuId}"
                });
            }

            _context.Entry(menu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!MenuExists(id))
                {
                    return NotFound(new ProblemDetails
                    {
                        Title = "Menu not found",
                        Status = StatusCodes.Status404NotFound,
                        Detail = $"No menu with ID {id} exists in the database."
                    });
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new ProblemDetails
                {
                    Title = "Menu Update Concurrency Error",
                    Status = StatusCodes.Status500InternalServerError,
                    Detail = $"Could not update the menu: {e.Message}"
                });
            }

            return NoContent();
        }

        // POST: api/Menus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/api/PostMenu")]
        public async Task<ActionResult<Menu>> PostMenu(Menu menu)
        {
            try
            {
                _context.Menus.Add(menu);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ProblemDetails
                {
                    Title = "Database Update Error",
                    Status = StatusCodes.Status500InternalServerError,
                    Detail = $"An error occurred while adding the menu to the database: {e.Message}"
                });

            }

            return CreatedAtAction("GetMenu", new { id = menu.MenuId }, menu);
        }

        // DELETE: api/Menus/5
        [HttpDelete("/api/DeleteMenu/{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            var menu = await _context.Menus.FindAsync(id);
            if (menu == null)
            {
                return NotFound(new ProblemDetails
                {
                    Title = "Menu not found",
                    Status = StatusCodes.Status404NotFound,
                    Detail = $"No menu with ID {id} exists in the database."
                });
            }

            try
            {
                _context.Menus.Remove(menu);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ProblemDetails
                {
                    Title = "Database Update Error",
                    Status = StatusCodes.Status500InternalServerError,
                    Detail = $"An error occurred while deleting the menu from the database: {e.Message}"
                });

            }

            return Ok(new { MenuId = id });
        }

        private bool MenuExists(int id)
        {
            return _context.Menus.Any(e => e.MenuId == id);
        }
    }
}
