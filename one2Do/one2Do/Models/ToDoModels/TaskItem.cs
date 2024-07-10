namespace one2Do.Models.ToDoModels
{
    public class TaskItem
    {
        public int Id { get; set; } // Primary key
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }
        public ToDoList ToDoList { get; set; }


    }
}
