// File: Services/UserService.cs

using BackendAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackendAPI.Services;

/// <summary>
/// Service responsible for handling user-related operations such as
/// database access and JWT token generation.
/// </summary>
public class UserService
{
    private readonly IMongoCollection<User> _usersCollection;
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserService"/> class
    /// and sets up the MongoDB connection and user collection.
    /// </summary>
    /// <param name="configuration">Application configuration settings.</param>
    public UserService(IConfiguration configuration)
    {
        _configuration = configuration;

        var mongoConnectionString = configuration["ConnectionStrings:MongoDb"];
        var databaseName = configuration["ConnectionStrings:DatabaseName"];
        var client = new MongoClient(mongoConnectionString);
        var database = client.GetDatabase(databaseName);
        _usersCollection = database.GetCollection<User>("Users");
    }

    /// <summary>
    /// Retrieves all users from the database.
    /// </summary>
    /// <returns>A list of users.</returns>
    public async Task<List<User>> GetAllAsync() =>
        await _usersCollection.Find(_ => true).ToListAsync();

    /// <summary>
    /// Retrieves a user by their unique identifier.
    /// </summary>
    /// <param name="id">The user's ID.</param>
    /// <returns>The matching <see cref="User"/> or null if not found.</returns>
    public async Task<User?> GetByIdAsync(string id) =>
        await _usersCollection.Find(u => u.Id == id).FirstOrDefaultAsync();

    /// <summary>
    /// Inserts a new user into the database.
    /// </summary>
    /// <param name="user">The user to create.</param>
    public async Task CreateAsync(User user) =>
        await _usersCollection.InsertOneAsync(user);

    /// <summary>
    /// Retrieves a user by email or username.
    /// </summary>
    /// <param name="email">The email to search for (nullable).</param>
    /// <param name="username">The username to search for (nullable).</param>
    /// <returns>The matching <see cref="User"/> or null if not found.</returns>
    public async Task<User?> GetByEmailOrUsernameAsync(string? email, string? username)
    {
        var filterBuilder = Builders<User>.Filter;
        var filter = filterBuilder.Eq(u => u.Email, email) | filterBuilder.Eq(u => u.Username, username);
        return await _usersCollection.Find(filter).FirstOrDefaultAsync();
    }

    /// <summary>
    /// Generates a JSON Web Token (JWT) for an authenticated user.
    /// </summary>
    /// <param name="user">The authenticated user.</param>
    /// <returns>A signed JWT as a string.</returns>
    public string GenerateJwtToken(User user)
    {
        var secretKey = _configuration["JwtSettings:SecretKey"];
        var issuer = _configuration["JwtSettings:Issuer"];
        var audience = _configuration["JwtSettings:Audience"];
        var expiryMinutes = int.Parse(_configuration["JwtSettings:ExpiryMinutes"] ?? "60");

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer,
            audience,
            claims,
            expires: DateTime.UtcNow.AddMinutes(expiryMinutes),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
