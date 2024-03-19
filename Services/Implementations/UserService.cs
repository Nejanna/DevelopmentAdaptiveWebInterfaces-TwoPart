using project.Models;
using project.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly List<User> _users;

        public UserService()
        {
            _users = new List<User>
            {
                new User { Id = 1, Name = "User1", Email = "user1@example.com" },
                new User { Id = 2, Name = "User2", Email = "user2@example.com" },
                new User { Id = 3, Name = "User3", Email = "user3@example.com" },
                new User { Id = 4, Name = "User4", Email = "user4@example.com" },
                new User { Id = 5, Name = "User5", Email = "user5@example.com" },
                new User { Id = 6, Name = "User6", Email = "user6@example.com" },
                new User { Id = 7, Name = "User7", Email = "user7@example.com" },
                new User { Id = 8, Name = "User8", Email = "user8@example.com" },
                new User { Id = 9, Name = "User9", Email = "user9@example.com" },
                new User { Id = 10, Name = "User10", Email = "user10@example.com" }
            };
        }

        public Task<List<User>> GetUsers()
        {
            return Task.FromResult(_users);
        }

        public Task<User> GetUserById(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            return Task.FromResult(user);
        }

        public Task<int> CreateUser(User user)
        {
            user.Id = _users.Count + 1;
            _users.Add(user);
            return Task.FromResult(user.Id);
        }

        public Task UpdateUser(int id, User user)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
            }
            else
            {
                throw new ArgumentException("Order not found.");
            }
            return Task.CompletedTask;
        }

        public Task DeleteUser(int id)
        {
            var userToRemove = _users.FirstOrDefault(u => u.Id == id);
            if (userToRemove != null)
            {
                _users.Remove(userToRemove);
            }
            else
            {
                throw new ArgumentException("Order not found.");
            }
            return Task.CompletedTask;
        }
    }
}
