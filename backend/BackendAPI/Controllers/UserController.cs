// File: Controllers/UserController.cs

using BackendAPI.Models;
using BackendAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BackendAPI.Dtos;
using BCrypt.Net;


namespace BackendAPI.Controllers;

// Marks this class as an API controller and sets up routing
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    // Constructor to inject the UserService dependency
    public UserController(UserService userService)
    {
        _userService = userService;
    }

    // GET: api/user
    // Returns a list of all users
    [HttpGet]
    public async Task<ActionResult<List<User>>> Get()
    {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }
        
    // POST: api/user
    // Creates a new user
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] User user)
    {
        await _userService.CreateAsync(user);
        return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
    }

    // POST: api/user/register
    // Registers a new user with validation
    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] RegisterRequest request  )
    {
        // Basic validations for the registration request
        if (string.IsNullOrWhiteSpace(request.Username) || 
            string.IsNullOrWhiteSpace(request.Password) || 
            string.IsNullOrWhiteSpace(request.Email))
        {
            return BadRequest("Username, password, and email are required.");
        }

        if (!request.Email.Contains("@"))
        {
            return BadRequest("Invalid email format.");
        }

        if (request.Password.Length < 8)
        {
            return BadRequest("Password must be at least 8 characters long.");
        }

        // Check if a user with the same email or username already exists
        var existingUser = await _userService.GetByEmailOrUsernameAsync(request.Email, request.Username);
        if (existingUser != null)
        {
            return Conflict("User with this email or username already exists.");
        }

        // Create a new user object and hash the password
        var user = new User
        {
            Username = request.Username,
            Email = request.Email,
            CreatedAt = DateTime.UtcNow,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password) 
        };

        // Save the new user to the database
        await _userService.CreateAsync(user);

        return Ok("User registered successfully.");
    }

    // POST: api/user/login
    // Logs in a user with validation
    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginRequest request)
        {
            // Validate the login request
            var user = await _userService.GetByEmailOrUsernameAsync(null, request.Username);

            if (user == null)
            {
                return Unauthorized("Invalid username or password.");

            }

            // Verify the password using BCrypt
            bool validPassword = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (!validPassword)
            
            {
                 return Unauthorized("Invalid username or password.");
            }
            return Ok("Login successful.");
        }

}
