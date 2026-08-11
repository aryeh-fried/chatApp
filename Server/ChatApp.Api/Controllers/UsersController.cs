using ChatApp.Api.Models;
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
    public ActionResult<User> CreateUser(User AddUser)
    {
        AddUser.Id = _users.Max(u => u.Id) + 1;
        _users.Add(AddUser);
        return CreatedAtAction(nameof(GetUser), new { id = AddUser.Id }, AddUser);
    }
}   