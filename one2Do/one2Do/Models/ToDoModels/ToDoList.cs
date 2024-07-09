using one2Do.Models;  
using System.Collections.Generic;

namespace one2Do.Models.ToDoModels
{
    public class ToDoList
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public int CategoryId { get; set; } 


       
        public string UserId { get; set; }
        
        
        public List<TaskItem> TaskItems { get; set; } 

        // Constructor to initialize TaskItems list to avoid null reference issues
        public ToDoList()
        {
            TaskItems = new List<TaskItem>(); 
        }
    }
}
