using TaskManager.Models;  
  
namespace TaskManager.Services  
{  
    public class TaskService  
    {  
        private static List<TaskItem> tasks = new List<TaskItem>();  
  
        public IEnumerable<TaskItem> GetAllTasks() => tasks;  
  
        public void AddTask(TaskItem task)  
        {  
            task.Id = tasks.Count + 1;  
            tasks.Add(task);  
        }  
    }  
}  
 