using WebApplication4.Models;

namespace WebApplication4.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task UpdateUser(int id, User user);
        Task DeleteUser(int id);
    }
}
