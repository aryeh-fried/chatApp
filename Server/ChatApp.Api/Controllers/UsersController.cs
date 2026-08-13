using ChatApp.Api.Models;
using ChatApp.Api.DTOs.Users;
using Microsoft.AspNetCore.Mvc;
using ChatApp.Api.Services;

namespace ChatApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    private readonly IUserService _userService;
   

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetUsers()
    {
        return await _userService.GetAllUsers();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _userService.GetUserById(id);
        if (user == null)
        {
           return NotFound();
        }

        return user;
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(CreateUserDto AddUser)
    {
        var newUser = await _userService.CreateUser(AddUser);
        return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
    }
}   