using ChatApp.Api.Models;
using ChatApp.Api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private static readonly List<User> _users = new()
    {
        new() { Id = 1, UserName = "JohnDoe", Email = "john.doe@example.com", Password = "password" },
        new() { Id = 2, UserName = "JaneSmith", Email = "jane.smith@example.com", Password = "password" },
        new() { Id = 3, UserName = "AliceJones", Email = "alice.jones@example.com", Password = "password" },
        new() { Id = 4, UserName = "BobBrown", Email = "bob.brown@example.com", Password = "password" },
        new() { Id = 5, UserName = "CharlieBlack", Email = "charlie.black@example.com", Password = "password" }
    };

    [HttpGet]
    public List<User> GetUsers()
    {

        return _users;
    }
    [HttpGet("{id}")]
    public ActionResult<User> GetUser(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
           return NotFound();
        }


        return user;
    }
    [HttpPost]
    public ActionResult<User> CreateUser(CreateUserDto AddUser)
    {
        var newId = _users.Max(u => u.Id) + 1;
        _users.Add(new User
        {
            Id = newId,
            UserName = AddUser.UserName,
            Email = AddUser.Email,
            Password = AddUser.Password
        });
        return CreatedAtAction(nameof(GetUser), new { id = newId}, AddUser);
    }
}   