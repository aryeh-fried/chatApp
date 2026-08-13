using ChatApp.Api.Models;
using ChatApp.Api.DTOs;
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
    private static readonly List<User> _users = new()
    {
        new() { Id = 1, UserName = "JohnDoe", Email = "john.doe@example.com", Password = "password" },
        new() { Id = 2, UserName = "JaneSmith", Email = "jane.smith@example.com", Password = "password" },
        new() { Id = 3, UserName = "AliceJones", Email = "alice.jones@example.com", Password = "password" },
        new() { Id = 4, UserName = "BobBrown", Email = "bob.brown@example.com", Password = "password" },
        new() { Id = 5, UserName = "CharlieBlack", Email = "charlie.black@example.com", Password = "password" }
    };

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