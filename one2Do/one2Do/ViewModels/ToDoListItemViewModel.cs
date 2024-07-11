namespace one2Do.ViewModels
{
    public class ToDoListItemViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public string CategoryName { get; set; }
    }
}
