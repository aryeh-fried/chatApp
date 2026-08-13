using ChatApp.Api.Models;
using ChatApp.Api.DTOs;

namespace ChatApp.Api.Services
{
    public interface IUserService
    {
       Task<List<User>> GetAllUsers();
       Task<User?> GetUserById(int id);
       Task<User> CreateUser(CreateUserDto createUserDto);

    }
}