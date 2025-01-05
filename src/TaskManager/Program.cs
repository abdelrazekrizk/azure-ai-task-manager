using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskManager.Services;
using DotNetEnv; // Import the DotNetEnv namespace

// Load environment variables from .env file
Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the TaskService and AzureNLPService
builder.Services.AddSingleton<TaskService>();
builder.Services.AddSingleton<AzureNLPService>(sp =>
{
    // Read Azure credentials from environment variables
    var endpoint = Environment.GetEnvironmentVariable("AZURE_ENDPOINT");
    var apiKey = Environment.GetEnvironmentVariable("AZURE_API_KEY");

    // Check if the endpoint or API key is null and throw an exception if they are
    if (string.IsNullOrEmpty(endpoint) || string.IsNullOrEmpty(apiKey))
    {
        throw new InvalidOperationException("Azure endpoint or API key is not set in environment variables.");
    }

    return new AzureNLPService(endpoint, apiKey);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Enable HTTPS redirection

app.UseAuthorization();
app.MapControllers();

app.Run();  