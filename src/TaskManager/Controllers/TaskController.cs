using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly TaskService taskService;
        private readonly AzureNLPService azureNLPService;

        public TaskController()
        {
            // Replace with your Azure credentials
            azureNLPService = new AzureNLPService("YOUR_AZURE_ENDPOINT", "YOUR_AZURE_API_KEY");
            taskService = new TaskService();
        }

        [HttpGet]
        public ActionResult<IEnumerable<TaskItem>> GetAllTasks()
        {
            return Ok(taskService.GetAllTasks());
        }

        [HttpPost]
        public ActionResult AddTask([FromBody] TaskItem task)
        {
            var sentiment = azureNLPService.AnalyzeTask(task.Description);
            taskService.AddTask(task);
            return Ok(new { Task = task, Sentiment = sentiment });
        }
    }
}