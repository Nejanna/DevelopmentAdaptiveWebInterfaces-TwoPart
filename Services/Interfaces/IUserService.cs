using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task<int> CreateUser(User user);
        Task UpdateUser(int id, User user);
        Task DeleteUser(int id);
    }
}
