using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskManager.Models;
using TaskManager.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the TaskService and AzureNLPService
builder.Services.AddSingleton<TaskService>();
builder.Services.AddSingleton<AzureNLPService>(sp =>
{
    // Replace with your Azure credentials
    return new AzureNLPService("YOUR_AZURE_ENDPOINT", "YOUR_AZURE_API_KEY");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Task management endpoints
app.MapGet("/api/task", (TaskService taskService) =>
{
    var tasks = taskService.GetAllTasks();
    return Results.Ok(tasks);
}).WithName("GetAllTasks").WithOpenApi();

app.MapPost("/api/task", (TaskItem task, TaskService taskService, AzureNLPService azureNLPService) =>
{
    var sentiment = azureNLPService.AnalyzeTask(task.Description);
    taskService.AddTask(task);
    return Results.Ok(new { Task = task, Sentiment = sentiment });
}).WithName("AddTask").WithOpenApi();

app.UseAuthorization();
app.MapControllers();

app.Run();