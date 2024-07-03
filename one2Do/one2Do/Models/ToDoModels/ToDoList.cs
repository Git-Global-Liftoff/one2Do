namespace one2Do.Models.ToDoModels
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<TaskItem> Tasks { get; set; }
    }
}
