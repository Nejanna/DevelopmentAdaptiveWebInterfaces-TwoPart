using WebApplication4.Models;

namespace WebApplication4.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(User model);
        Task<string> LoginAsync(Login model);
    }
}
