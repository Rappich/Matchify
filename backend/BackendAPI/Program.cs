using DotNetEnv;
using MongoDB.Driver;
using BackendAPI.Services;


var builder = WebApplication.CreateBuilder(args);

//  Load environment variables from .env
DotNetEnv.Env.Load();

//  Load config from appsettings.json and environment
builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

//  Get MongoDB connection details
var mongoConnection = Environment.GetEnvironmentVariable("MONGODB_CONN")
                      ?? builder.Configuration.GetConnectionString("MongoDb")
                      ?? throw new Exception("MongoDB connection string not configured.");

var mongoDatabaseName = Environment.GetEnvironmentVariable("MONGODB_DBNAME")
                        ?? builder.Configuration["DatabaseName"]
                        ?? "MatchifyDB";

//  Register MongoDB services
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(mongoConnection));
builder.Services.AddSingleton(sp => sp.GetRequiredService<IMongoClient>().GetDatabase(mongoDatabaseName));

//  Register custom services (like UserService – we’ll create this soon!)
builder.Services.AddSingleton<UserService>();

//  Register support for attribute-based controllers like [ApiController]
builder.Services.AddControllers();

// (Optional: Swagger setup)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//  Development-time tools
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//  Middleware pipeline
app.UseHttpsRedirection();

//  Enable routing for controllers like /api/user
app.MapControllers();

//  Temporary test endpoint
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
