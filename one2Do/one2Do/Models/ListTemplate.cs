
﻿using one2Do.Models.ToDoModels; // Added missing namespace 

namespace one2Do.Models;

public class ListTemplate

    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public List<TaskItem>? TaskItems { get; set; } //Changed from Task to TaskItem
        public List<Categories>? Categories { get; set; }

        public ListTemplate(string title, int id)
        {
            Title = title;
            Id = id;
            TaskItems = new List<TaskItem>();
        }

        public ListTemplate()
        {
            TaskItems = new List<TaskItem>();
            Categories = new List<Categories>();
        }
    }

