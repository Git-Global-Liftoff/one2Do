using System;
using System.Collections.Generic;
using one2Do.Models.ToDoModels;

namespace one2Do.ViewModels
{
    public class ToDoListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public string CategoryName { get; set; }
        public List<TaskItem> Tasks { get; set; }

        public ToDoListViewModel()
        {
            Tasks = new List<TaskItem>();
        }
    }
}
