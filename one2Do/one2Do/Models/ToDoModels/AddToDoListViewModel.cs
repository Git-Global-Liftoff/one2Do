using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace one2Do.Models.ToDoModels
{
    public class AddToDoListViewModel
    {
        [Required]
        public string? Title { get; set; }
        public int CategoryId { get; set; }  
        public List<SelectListItem> Categories { get; set; } = new();
       
    }
}


