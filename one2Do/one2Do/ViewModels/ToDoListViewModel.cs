// using System.Collections.Generic;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using one2Do.Models.ToDoModels;

// namespace one2Do.ViewModels
// {
//     public class ToDoListViewModel
//     {

//         public int TotalTasks {get; set;}
//         public int CompletedTasks {get; set;}

//         public List<ToDoListItemViewModel> ToDoItems { get; set; } = new List<ToDoListItemViewModel>();
//         public int SelectedCategoryId { get; set; }
//         // public List<string> Categories { get; internal set; }
//         // public int CategoryId { get; set; }
//         // public List<ToDoListCategory>? ToDoListCategories { get; set; }

// // List of categories for the dropdown
//         public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();

//         public static implicit operator ToDoListViewModel(ToDoListViewModel v)
//         {
//             throw new NotImplementedException();
//         }
//     }
// }
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using one2Do.Models.ToDoModels;

namespace one2Do.ViewModels
{
    public class ToDoListViewModel
    {
        public int TotalTasks { get; set; }
        public int CompletedTasks { get; set; }

        public List<ToDoListItemViewModel> ToDoItems { get; set; } = new List<ToDoListItemViewModel>();

        // ID of the selected category for filtering
        public int SelectedCategoryId { get; set; }

        // List of categories for dropdown
        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();
        
        [DataType(DataType.Date)]
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }

    }
}
