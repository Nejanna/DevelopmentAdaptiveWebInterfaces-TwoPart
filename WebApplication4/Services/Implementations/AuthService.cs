using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication4.Models;
using WebApplication4.Services.Interfaces;

namespace WebApplication4.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly List<User> _users;
        private const string TokenSecret = "SecretkeyLab8jdjdjdjdjjdjdjdjdjdjdjdjdj";
        public AuthService()
        {
            _users = new List<User>
        {
            new User
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john@example.com",
                DateOfBirth = new DateTime(1990, 5, 15),
                PasswordHash = "pass123",
                LastLogin = DateTime.Now.AddDays(-199),
                FailedLoginAttempts = 13
            },
            new User
            {
                FirstName = "Alice",
                LastName = "Smith",
                Email = "alice@example.com",
                DateOfBirth = new DateTime(1985, 8, 22),
                PasswordHash = "password2",
                LastLogin = DateTime.Now.AddDays(-199),
                FailedLoginAttempts = 13
            }
        };
        }

        public async Task<User> RegisterAsync(User model)
        {
            if (_users.Any(u => u.Email == model.Email))
            {

                var newUser = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    DateOfBirth = model.DateOfBirth,
                    PasswordHash = model.PasswordHash
                };

                _users.Add(newUser);

                return newUser;
            }
            return null;

        }

        public async Task<string> LoginAsync(User model)
        {
            try
            {
                var user = _users.FirstOrDefault(u => u.Email == model.Email && u.PasswordHash == model.PasswordHash);

                if (user == null)
                {
                    return "Invalid email or password.";
                }

                var token = GenerateJwtToken(user);

                return token;
            }
            catch (Exception ex)
            {
                return $"Error during user login: {ex.Message}";
            }
        }
        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(TokenSecret);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = "https://localhost:44318/",
                Audience = "https://localhost:44318/",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };


            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
