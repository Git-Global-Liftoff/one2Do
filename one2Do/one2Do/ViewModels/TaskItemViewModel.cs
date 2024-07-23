using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using one2Do.Models.ToDoModels;

namespace one2Do.ViewModels
{
    public class TaskItemViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Task description is required.")]
        [Display(Name = "Task Description")]
        public string Description { get; set; } = string.Empty; // Ensure non-null default

        [DataType(DataType.Date)]
        [Display(Name = "Due Date")]
        public DateTime? DueDate { get; set; } = DateTime.Now;

        [Display(Name = "Completed")]
        public bool IsCompleted { get; set; }

        [Required]
        public int ToDoListId { get; set; }
        public SelectList ToDoLists { get; set; }

        public TaskItemViewModel(IEnumerable<ToDoList> toDoLists)
        {
            ToDoLists = new SelectList(toDoLists, "Id", "Title");
        }

        public TaskItemViewModel()
        {
            ToDoLists = new SelectList(new List<ToDoList>());
        }
    }
}
