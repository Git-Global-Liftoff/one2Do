using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using one2Do.Models.ToDoModels;
using one2Do.Models;

namespace one2Do.ViewModels
{
    public class AddToDoListViewModel
    {
        [Required(ErrorMessage = "Please enter a title for the to-do list.")]
        [MinLength(3, ErrorMessage = "The title must be at least 3 characters long.")]
        public string Title { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }  

        public SelectList Categories { get; set; }

        public AddToDoListViewModel(IEnumerable<Category> categories)
        {
            Categories = new SelectList(categories ?? new List<Category>(), "Id", "Name", "Select a Category");
        }

        public AddToDoListViewModel() 
        {
            Categories = new SelectList(new List<Category>());
        }
    }
}
