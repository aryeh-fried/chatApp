using ChatApp.Api.Models;
using ChatApp.Api.DTOs;

namespace ChatApp.Api.Services
{
    public class UserService : IUserService
    {
        private  readonly List<User> _users = new()
    {
        new() { Id = 1, UserName = "JohnDoe", Email = "john.doe@example.com", Password = "password" },
        new() { Id = 2, UserName = "JaneSmith", Email = "jane.smith@example.com", Password = "password" },
        new() { Id = 3, UserName = "AliceJones", Email = "alice.jones@example.com", Password = "password" },
        new() { Id = 4, UserName = "BobBrown", Email = "bob.brown@example.com", Password = "password" },
        new() { Id = 5, UserName = "CharlieBlack", Email = "charlie.black@example.com", Password = "password" }
    };
        public User CreateUser(CreateUserDto createUserDto)
        {
            var newId = _users.Max(u => u.Id) + 1;
            var newUser = new User
            {
                Id = newId,
                UserName = createUserDto.UserName,
                Email = createUserDto.Email,
                Password = createUserDto.Password
            };
            _users.Add(newUser);
            return newUser;
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public User? GetUserById(int id)
        {
            
            return _users.FirstOrDefault(u => u.Id == id);
        }

        
    }
}