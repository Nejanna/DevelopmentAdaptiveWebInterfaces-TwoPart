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
    public class UserController : ControllerBase
    {
    
            private readonly IUserService _userService;

            public UserController(IUserService userService)
            {
                _userService = userService;
            }

            [HttpGet]
            public async Task<IActionResult> GetUsers()
            {
                var users = await _userService.GetUsers();
                return Ok(users);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetUser(int id)
            {
                var user = await _userService.GetUserById(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateUser(int id, User user)
            {
                if (id != user.Id)
                {
                    return BadRequest("Mismatched id parameter.");
                }

                try
                {
                    await _userService.UpdateUser(id, user);
                    return NoContent();
                }
                catch (ArgumentException ex)
                {
                    return NotFound(ex.Message);
                }
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteUser(int id)
            {
                try
                {
                    await _userService.DeleteUser(id);
                    return NoContent();
                }
                catch (ArgumentException ex)
                {
                    return NotFound(ex.Message);
                }
            }
        }
    }


