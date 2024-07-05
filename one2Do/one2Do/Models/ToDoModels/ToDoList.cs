namespace one2Do.Models.ToDoModels
{
    public class ToDoList
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public List<TaskItem> TaskItems { get; set; } // Changed from Tasks to TaskItems for consistency

        public ToDoList()
        {
            TaskItems = new List<TaskItem>(); // Initialize TaskItems list
        }
    }
}
