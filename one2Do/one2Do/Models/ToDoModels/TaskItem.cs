namespace one2Do.Models.ToDoModels
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public int ToDoListId { get; set; }
        public ToDoList ToDoList { get; set; }
    }
}
