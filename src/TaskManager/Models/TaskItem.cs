namespace TaskManager.Models  
{  
    public class TaskItem  
    {  
        public int Id { get; set; }  
        public required string Description { get; set; }  // Marking as required  
        public bool IsCompleted { get; set; }  
        public DateTime DueDate { get; set; }  
    }  
}   