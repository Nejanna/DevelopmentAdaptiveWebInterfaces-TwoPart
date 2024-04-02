using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
using WebApplication4.Services.Interfaces;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MenuController : ControllerBase
    {
        
            private readonly IMenuService menu;

            public MenuController(IMenuService menuService)
            {
                menu = menuService;
            }
            [HttpGet]
            public async Task<IActionResult> GetMenuItems()
            {
                var menuItems = await menu.GetMenuItems();
                return Ok(menuItems);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetMenuItem(int id)
            {
                var menuItem = await menu.GetMenuItem(id);
                if (menuItem == null)
                {
                    return NotFound();
                }
                return Ok(menuItem);
            }

            [HttpPost]
            public async Task<IActionResult> PostMenuItem(MenuItem menuItem)
            {
                var id = await menu.CreateMenuItem(menuItem);
                return CreatedAtAction(nameof(GetMenuItem), new { id }, menuItem);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateMenuItem(int id, MenuItem menuItem)
            {
                if (id != menuItem.Id)
                {
                    return BadRequest();
                }

                try
                {
                    await menu.UpdateMenuItem(menuItem);
                }
                catch (ArgumentException ex)
                {
                    return NotFound(ex.Message);
                }

                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteMenuItem(int id)
            {
                try
                {
                    await menu.DeleteMenuItem(id);
                }
                catch (ArgumentException ex)
                {
                    return NotFound(ex.Message);
                }
                return NoContent();
            }
        }
    }

