using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using one2Do.Controllers;
using one2Do.Data;
using one2Do.Models.ToDoModels;

namespace one2Do;

[Authorize]
public class HouseholdToDoListController : Controller
{
    // Define household items as properties
    private readonly one2doDbContext _context;
    private readonly string[] HouseholdItems =
    {
        "Laundry",
        "Organize Closets",
        "Iron",
        "Dishes",
        "Wash Baseboards",
        "Dust",
        "Change Linens"
    };

    public HouseholdToDoListController(one2doDbContext context)
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
    public IActionResult Create() //may need to tweek here to fix category column on "to do list" index view
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

        foreach (var item in HouseholdItems)
        {
            var taskItem = new TaskItem
            {
                Description = item,
                DueDate = DateTime.Now, 
                IsCompleted = false,
                ToDoList = newToDoList,
                ToDoListId = newToDoList.Id
            };
            _context.TaskItems.Add(taskItem);
        }

        _context.Add(newToDoList);
        _context.SaveChanges();

        //return RedirectToAction(nameof(Index));
        return RedirectToAction("Index", "ToDoList"); // Redirect to the appropriate action and controller
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

//THIS MIRRORS THE OTHER TWO TODOLIST CONTROLLERS AND INCLUDES ERROR HANDLING (ERRANDS CONTROLLER DOES NOT INCLUDE ERROR HANDLING, I DON'T BELIEVE....YET....BC IT'S NOT NECESSARY WITH DROP DOWN BOXES?):
// using System;
// using System.Linq;
// using System.Security.Claims;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using one2Do.Data;
// using one2Do.Models.ToDoModels;

// namespace one2Do
// {
//     [Authorize]
//     public class HouseholdToDoListController : Controller
//     {
//         private readonly one2doDbContext _context;
//         private readonly string[] HouseholdItems =
//         {
//             "Laundry",
//             "Organize Closets",
//             "Iron",
//             "Dishes",
//             "Wash Baseboards",
//             "Dust",
//             "Change Linens"
//         };

//         public HouseholdToDoListController(one2doDbContext context)
//         {
//             _context = context;
//         }

//         [HttpPost]
//         public IActionResult Create(string categoryName)
//         {
//             var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
//             var category = _context.Categories.FirstOrDefault(c => c.Name == categoryName);

//             if (category == null)
//             {
//                 TempData["ErrorMessage"] = $"Category '{categoryName}' not found.";
//                 return RedirectToAction("Index", "Home");
//             }

//             var newToDoList = new ToDoList
//             {
//                 Title = $"{categoryName} ToDo Template",
//                 UserId = userId,
//                 Category = category,
//                 Description = $"To do related to {categoryName}",
//                 DueDate = DateTime.Now,
//                 IsCompleted = false
//             };

//             foreach (var item in HouseholdItems)
//             {
//                 var taskItem = new TaskItem
//                 {
//                     Description = item,
//                     DueDate = DateTime.Now,
//                     IsCompleted = false,
//                     ToDoList = newToDoList
//                 };
//                 _context.TaskItems.Add(taskItem);
//             }

//             _context.ToDoLists.Add(newToDoList);
//             _context.SaveChanges();

//             return RedirectToAction("Index", "ToDoList");
//         }
//     }
// }
