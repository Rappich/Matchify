using DotNetEnv;
using MongoDB.Driver;
using BackendAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

/// =============================
/// Load configuration
/// =============================

// Load environment variables from .env file (lokal utveckling)
DotNetEnv.Env.Load();

// Läs in appsettings.json + miljövariabler
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

/// =============================
/// MongoDB setup
/// =============================

// Hämta anslutningssträng och databasenamn från konfiguration eller miljövariabler
var mongoConnection = builder.Configuration["MONGODB_CONN"]
                      ?? builder.Configuration.GetConnectionString("MongoDb")
                      ?? throw new Exception("MongoDB connection string not configured.");

var mongoDatabaseName = builder.Configuration["MONGODB_DBNAME"]
                        ?? builder.Configuration["DatabaseName"]
                        ?? "MatchifyDB";

// Registrera MongoDB-klient som singleton, så den återanvänds
builder.Services.AddSingleton<IMongoClient>(_ => new MongoClient(mongoConnection));

// Registrera MongoDB-databas som singleton (hämtad från klienten)
builder.Services.AddSingleton(sp =>
    sp.GetRequiredService<IMongoClient>().GetDatabase(mongoDatabaseName));

/// =============================
/// Register your services here
/// =============================

builder.Services.AddSingleton<UserService>();

/// =============================
/// JWT Authentication setup
/// =============================

/// Read JWT settings from configuration
/// Ensure these are set in appsettings.json or environment variables
var jwtSecret = builder.Configuration["JwtSettings:SecretKey"];
var jwtIssuer = builder.Configuration["JwtSettings:Issuer"];
var jwtAudience = builder.Configuration["JwtSettings:Audience"];

if (string.IsNullOrEmpty(jwtSecret) || string.IsNullOrEmpty(jwtIssuer) || string.IsNullOrEmpty(jwtAudience))
{
    throw new Exception("JWT configuration is missing in appsettings.json or environment variables.");
}

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret))
        };
    });

/// =============================
/// MVC and Swagger setup
/// =============================

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/// =============================
/// Build app and configure middleware
/// =============================

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

/// =============================
/// Test endpoints
/// =============================

app.MapGet("/", () => "Welcome to Matchify backend. Use /api/test/ping to test MongoDB connection.");

app.MapGet("/api/test/ping", (IMongoDatabase db) =>
{
    try
    {
        var collections = db.ListCollectionNames().ToList();
        return Results.Ok(new { status = "connected", collections });
    }
    catch (Exception ex)
    {
        return Results.Problem($"MongoDB error: {ex.Message}");
    }
});

app.Run();
