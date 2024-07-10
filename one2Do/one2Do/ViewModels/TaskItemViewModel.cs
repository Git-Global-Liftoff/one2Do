using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using one2Do.Models;
using one2Do.Models.ToDoModels;

namespace one2Do.ViewModels
{
    public class TaskItemViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Task description is required.")]
        [Display(Name = "Task Description")]
        public string Description { get; set; } = string.Empty;  // Ensure non-null default

        [DataType(DataType.Date)]
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; } = DateTime.Now;

        [Display(Name = "Completed")]
        public bool IsCompleted { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }  // Consider making nullable for flexibility

        public SelectList Categories { get; set; }

        public TaskItemViewModel(IEnumerable<Category> categories)
        {
            Categories = new SelectList(categories ?? new List<Category>(), "Id", "Name");
        }

        public TaskItemViewModel()
        {
            Categories = new SelectList(new List<Category>());
        }
    }
}
