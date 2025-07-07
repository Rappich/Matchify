// File: Services/UserService.cs

using BackendAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BackendAPI.Services;

/// <summary>
// Handles user-related database operations.
public class UserService
{
    private readonly IMongoCollection<User> _usersCollection;

    // Initializes the MongoDB connection and Users collection.
    public UserService(IConfiguration configuration)
    {
        var mongoConnectionString = configuration["MONGODB_CONN"];
        var databaseName = configuration["ConnectionStrings:DatabaseName"];
        var client = new MongoClient(mongoConnectionString);
        var database = client.GetDatabase(databaseName);
        _usersCollection = database.GetCollection<User>("Users");
    }

    // Gets all users.
    public async Task<List<User>> GetAllAsync() =>
        await _usersCollection.Find(_ => true).ToListAsync();

    // Gets a user by ID.
    public async Task<User?> GetByIdAsync(string id) =>
        await _usersCollection.Find(u => u.Id == id).FirstOrDefaultAsync();

    // Creates a new user.
    public async Task CreateAsync(User user) =>
        await _usersCollection.InsertOneAsync(user);
}
