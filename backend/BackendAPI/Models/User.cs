// File: Models/User.cs

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BackendAPI.Models;

// Represents a user in the application.
public class User
{
    // MongoDB document ID.
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    // User's username.
    [BsonElement("username")]
    public string Username { get; set; } = string.Empty;

    // User's email address.
    [BsonElement("email")]
    public string Email { get; set; } = string.Empty;

    // When the user was created.
    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
