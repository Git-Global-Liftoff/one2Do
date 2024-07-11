using System.Collections.Generic;

namespace one2Do.ViewModels
{
    public class ToDoListViewModel
    {
        public List<ToDoListItemViewModel> ToDoItems { get; set; } = new List<ToDoListItemViewModel>();
    }
}
