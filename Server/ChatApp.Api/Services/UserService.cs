using ChatApp.Api.Models;
using ChatApp.Api.DTOs.Users;
using ChatApp.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Api.Services
{
    public class UserService : IUserService
    {
        private readonly ChatAppDbContext _context;

        public UserService(ChatAppDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(CreateUserDto createUserDto)
        {
            var newUser = new User
            {
                UserName = createUserDto.UserName,
                Email = createUserDto.Email,
                Password = createUserDto.Password
            };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }
       
        public async Task<User?> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}