using System.Collections.Generic;

namespace one2Do.ViewModels
{
    public class ToDoListViewModel
    {

        public int TotalTasks {get; set;}
        public int CompletedTasks {get; set;}

        public List<ToDoListItemViewModel> ToDoItems { get; set; } = new List<ToDoListItemViewModel>();
        public string SelectedCategory { get; internal set; }
        public List<string> Categories { get; internal set; }
    }
}
