using System;
using System.ComponentModel.DataAnnotations;

namespace one2Do.Models.ToDoModels
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Task Description")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; } // Removed nullable

        [DataType(DataType.Date)]
        [Display(Name = "Due Date")]
        public DateTime? DueDate { get; set; } // Made nullable to distinguish unset dates

        [Display(Name = "Completed")]
        public bool IsCompleted { get; set; }

        // Link to the ToDoList it belongs to
        [Required]
        public int ToDoListId { get; set; }
        public ToDoList ToDoList { get; set; }


    }
}
