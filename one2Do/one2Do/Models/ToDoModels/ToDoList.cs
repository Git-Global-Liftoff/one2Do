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

        [DataType(DataType.Date)]
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }

        public List<ToDoListCategory> ToDoListCategories { get; set; }
        public List<TaskItem> TaskItems { get; set; }

        public ToDoList()
        {
            TaskItems = new List<TaskItem>();
            ToDoListCategories = new List<ToDoListCategory>();
        }
    }
}
