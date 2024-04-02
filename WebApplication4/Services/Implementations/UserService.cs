using WebApplication4.Models;
using WebApplication4.Services.Interfaces;

namespace WebApplication4.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly List<User> _users;

        public UserService()
        {
            _users = new List<User>();
        }

        public Task<User> GetUserById(int id)
        {
            return Task.FromResult(_users.FirstOrDefault(u => u.Id == id));
        }

        public Task<List<User>> GetUsers()
        {
            return Task.FromResult(_users);
        }

        public async Task UpdateUser(int id, User user)
        {
            var existingUser = await Task.Run(() => _users.FirstOrDefault(u => u.Id == id));
            if (existingUser != null)
            {
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Email = user.Email;
                existingUser.DateOfBirth = user.DateOfBirth;
                existingUser.PasswordHash = user.PasswordHash;
                existingUser.LastLogin = user.LastLogin;
                existingUser.FailedLoginAttempts = user.FailedLoginAttempts;
            }
            else
            {
                throw new ArgumentException("User not found.");
            }
        }

        public async Task DeleteUser(int id)
        {
            var userToDelete = await Task.Run(() => _users.FirstOrDefault(u => u.Id == id));

            if (userToDelete != null)
            {
                _users.Remove(userToDelete);
            }
            else
            {
                throw new ArgumentException("User not found.");
            }
        }
    }
}
