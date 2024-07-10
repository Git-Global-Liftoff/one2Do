﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using one2Do.Controllers;
using one2Do.Data;
using one2Do.Models.ToDoModels;
using System.Security.Claims;


namespace one2Do;


    [Authorize] 

    public class HouseholdToDoController : Controller
    {
        // Define household items as properties
       private readonly one2doDbContext _context;
        private readonly string[] HouseholdItems = { "Laundry", "Organize Closets", "Iron", "Dishes", "Wash Baseboards", "Dust", "Change Linens" };

        public HouseholdToDoController(one2doDbContext context) 
        {
            _context = context;
        }

        // You can override methods from ToDoListController if necessary

        // GET: HouseholdToDoList/Create
        // //public IActionResult Create()
        // {

        //     var viewModel = new AddToDoListViewModel
        //     {
        //         Categories = _context.Categories.Select(c => new SelectListItem
        //         {
        //             Value = c.Id.ToString(),
        //             Text = c.Name
        //         }).ToList(),
        //         HouseholdItems = HouseholdItems // Pass household items to the view model
        //     };
        //     return View(viewModel);
        // }

        // POST: HouseholdToDoList/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create()
        {
        
            var theCategory = _context.Categories.Find(1);
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // More reliable way to get user ID
                // var newToDoList = new ToDoList
                // {
                //     Title = "Household ToDo Template",
                //     UserId = userId,
                //     CategoryId = 1 // Store only the CategoryId
                // };
                var newToDoList = new ToDoList(
                    "Household ToDo Template",
                    userId,
                    1,
                    theCategory,
                    "To do around the house",
                    DateTime.Now, 
                    false

                );

                _context.Add(newToDoList);
                 _context.SaveChanges();
                //return RedirectToAction(nameof(Index));
                return Redirect("/");
            
           
        }

    }
// {
//             Title = title;
//             UserId = userId;
//             CategoryId = categoryId;
//             Category = category;
//             Description = description;
//             DueDate = dueDate;
//             IsCompleted = isCompleted;
//         }
