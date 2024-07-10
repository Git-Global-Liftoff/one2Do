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

        [Required] // Assuming every list must be linked to a user
        public string UserId { get; set; } // ID of the user who owns the list

        [Required] // Ensures a category is always selected
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<ToDoListCategory> ToDoListCategories { get; set; }

        public List<TaskItem> Tasks { get; set; } = new List<TaskItem>(); // Initialization moved here for consistency
    }
}
