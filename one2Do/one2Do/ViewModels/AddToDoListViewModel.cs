using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using one2Do.Models;
using one2Do.Models.ToDoModels;

namespace one2Do.ViewModels
{
    public class AddToDoListViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; } // Added Description
        public DateTime DueDate { get; set; } = DateTime.Now; // Added DueDate
        public bool IsCompleted { get; set; } // Added IsCompleted
        public int CategoryId { get; set; }
        public SelectList Categories { get; set; }

        public AddToDoListViewModel(IEnumerable<Category> categories)
        {
            Categories = categories != null ? new SelectList(categories, "Id", "Name") : new SelectList(new List<Category>());
        }

        public AddToDoListViewModel()
        {
            Categories = new SelectList(new List<Category>());
        }
    }
}
