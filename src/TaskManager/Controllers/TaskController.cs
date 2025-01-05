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

        public TaskController(TaskService taskService, AzureNLPService azureNLPService)
        {
            this.taskService = taskService;
            this.azureNLPService = azureNLPService;
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