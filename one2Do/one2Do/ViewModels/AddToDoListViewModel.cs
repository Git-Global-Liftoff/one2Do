using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using one2Do.Models;
using one2Do.Models.ToDoModels;

namespace one2Do.ViewModels
{
    public class AddToDoListViewModel
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }

        [Display(Name = "Completed")]
        public bool IsCompleted { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public SelectList Categories { get; set; }

        public AddToDoListViewModel(IEnumerable<Category> categories)
        {
            Categories = new SelectList(categories, "Id", "Name");
        }

        public AddToDoListViewModel() 
        {
            Categories = new SelectList(Array.Empty<Category>(), "Id", "Name");
        }
    }
}
