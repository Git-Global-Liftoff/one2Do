using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace one2Do.Models.ToDoModels
{
    public class ToDoList
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "List Title")]
        public string Title { get; set; }

        public string UserId { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<ToDoListCategory> ToDoListCategories { get; set; } // Add this property
        public List<TaskItem> TaskItems { get; set; } // Add this property

        public ToDoList()
        {
            ToDoListCategories = new List<ToDoListCategory>(); // Initialize the list
            TaskItems = new List<TaskItem>(); // Initialize the list
        }
    }
}
