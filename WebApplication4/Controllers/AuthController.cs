using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
using WebApplication4.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User model)
        {
            var result = await _authService.RegisterAsync(model);
            return Ok(model);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(Login model)
        {
            var token = await _authService.LoginAsync(model);

            if (!string.IsNullOrEmpty(token))
            {
                return Ok(new { Token = token });
            }
            else
            {
                return Unauthorized("Invalid email or password.");
            }
        }
    }
}

