using Microsoft.AspNetCore.Mvc;
using Serilog;
using WebApplication4.Models;
using WebApplication4.Services.Interfaces;



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
        public async Task<IActionResult> Login(User model)
        {
            var token = await _authService.LoginAsync(model);

            if (!string.IsNullOrEmpty(token))
            {
                // Логування успішного входу task 3
                Log.Information("User {Email} logged in at {Time}", model.Email, DateTime.Now);

                return Ok(new { Token = token });
            }
            else
            {
                // Логування task 3
                Log.Information("User {Email} logged in at {Time}", model.Email, DateTime.Now);

                return Unauthorized("Invalid email or password.");
            }
        }
    }
}

