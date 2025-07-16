// File: Controllers/UserController.cs

using BackendAPI.Models;
using BackendAPI.Services;
using Microsoft.AspNetCore.Mvc;
using BackendAPI.Dtos;
using BCrypt.Net;

namespace BackendAPI.Controllers;

/// <summary>
/// Controller responsible for managing user-related API endpoints,
/// including registration, login, and user retrieval.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserController"/> class.
    /// </summary>
    /// <param name="userService">The user service dependency.</param>
    public UserController(UserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Retrieves a list of all users.
    /// </summary>
    /// <returns>A list of users in the system.</returns>
    [HttpGet]
    public async Task<ActionResult<List<User>>> Get()
    {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }

    /// <summary>
    /// Creates a new user directly from a <see cref="User"/> object.
    /// </summary>
    /// <param name="user">The user object to insert.</param>
    /// <returns>A 201 Created response with the new user.</returns>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] User user)
    {
        await _userService.CreateAsync(user);
        return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
    }

    /// <summary>
    /// Registers a new user with validation logic.
    /// </summary>
    /// <param name="request">The registration request containing username, email, and password.</param>
    /// <returns>A 200 OK response on success, or an error message if validation fails.</returns>
    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] RegisterRequest request)
    {
        // Validate input
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

        // Check if user already exists
        var existingUser = await _userService.GetByEmailOrUsernameAsync(request.Email, request.Username);
        if (existingUser != null)
        {
            return Conflict("User with this email or username already exists.");
        }

        // Create and hash password
        var user = new User
        {
            Username = request.Username,
            Email = request.Email,
            CreatedAt = DateTime.UtcNow,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };

        await _userService.CreateAsync(user);

        return Ok("User registered successfully.");
    }

    /// <summary>
    /// Logs in a user and returns a JWT token if credentials are valid.
    /// </summary>
    /// <param name="request">The login request containing username and password.</param>
    /// <returns>A 200 OK response with a JWT token or 401 Unauthorized if login fails.</returns>
    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginRequest request)
    {
        var user = await _userService.GetByEmailOrUsernameAsync(null, request.Username);

        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            return Unauthorized("Invalid username or password.");
        }

        var token = _userService.GenerateJwtToken(user);

        return Ok(new { token });
    }
}
