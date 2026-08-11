using ChatApp.Api.Models;
using ChatApp.Api.DTOs;

namespace ChatApp.Api.Services
{
    public interface IUserService
    {
       List<User> GetAllUsers();
       User? GetUserById(int id);
       User CreateUser(CreateUserDto createUserDto);

    }
}