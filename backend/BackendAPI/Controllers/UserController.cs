// File: Controllers/UserController.cs

using BackendAPI.Models;
using BackendAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers;

// Marks this class as an API controller and sets up routing
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    // Injects the UserService dependency
    public UserController(UserService userService)
    {
        _userService = userService;
    }

    // Handles GET requests to retrieve all users
    [HttpGet]
    public async Task<ActionResult<List<User>>> Get()
    {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }

    // Handles POST requests to create a new user
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] User user)
    {
        await _userService.CreateAsync(user);
        // Returns a 201 Created response with the new user's info
        return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
    }
}
