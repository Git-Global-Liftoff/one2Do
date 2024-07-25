// using System.Security.Claims;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using one2Do.Controllers;
// using one2Do.Data;
// using one2Do.Models.ToDoModels;

// namespace one2Do;

// [Authorize]
// public class ErrandsToDoListController : Controller
// {
//     // Define household items as properties
//     private readonly one2doDbContext _context;
//     private readonly string[] Errands =
//     {
//         "Renew Drivers License",
//         "Trader Joe's",
//         "Return Rental Car",
//         "Buy Nothing Pickups",
//         "Home Depot",
//         "Drop off Taxes",
//         "Be Rad"
//     };

//     public ErrandsToDoListController(one2doDbContext context)
//     {
//         _context = context;
//     }

//     // You can override methods from ToDoListController if necessary

//     // GET: HouseholdToDoList/Create
//     // //public IActionResult Create()
//     // {

//     //     var viewModel = new AddToDoListViewModel
//     //     {
//     //         Categories = _context.Categories.Select(c => new SelectListItem
//     //         {
//     //             Value = c.Id.ToString(),
//     //             Text = c.Name
//     //         }).ToList(),
//     //         HouseholdItems = HouseholdItems // Pass household items to the view model
//     //     };
//     //     return View(viewModel);
//     // }

//     // POST: HouseholdToDoList/Create
//     [HttpPost]
//     //[ValidateAntiForgeryToken]
//     public IActionResult Create()
//     {
        
//         var theCategory = _context.Categories.Find(2);
//         var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // More reliable way to get user ID
//         // var newToDoList = new ToDoList
//         // {
//         //     Title = "Household ToDo Template",
//         //     UserId = userId,
//         //     CategoryId = 1 // Store only the CategoryId
//         // };
//         var newToDoList = new ToDoList(
//             "Errands ToDo Template",
//             userId,
//             2,
//             theCategory,
//             "To do around town",
//             DateTime.Now,
//             false
//         );

//         foreach (var item in Errands)
//         {
//             var taskItem = new TaskItem
//             {
//                 Description = item,
//                 DueDate = DateTime.Now, 
//                 IsCompleted = false,
//                 ToDoList = newToDoList,
//                 ToDoListId = newToDoList.Id
//             };
//             _context.TaskItems.Add(taskItem);
//         }

//         _context.Add(newToDoList);
//         _context.SaveChanges();

//         //return RedirectToAction(nameof(Index));
//         return RedirectToAction("Index", "ToDoList"); // Redirect to the appropriate action and controller
//     }
// }


// // {
// //             Title = title;
// //             UserId = userId;
// //             CategoryId = categoryId;
// //             Category = category;
// //             Description = description;
// //             DueDate = dueDate;
// //             IsCompleted = isCompleted;
// //         }

//THIS VERSION USES LINQ EXPRESSION AND IS NOT HARD-CODED:

using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using one2Do.Controllers;
using one2Do.Data;
using one2Do.Models.ToDoModels;
using System.Linq;

namespace one2Do;

[Authorize]
public class ErrandsToDoListController : Controller
{
    // Define household items as properties
    private readonly one2doDbContext _context;
    private readonly string[] Errands =
    {
        "Renew Drivers License",
        "Trader Joe's",
        "Return Rental Car",
        "Buy Nothing Pickups",
        "Home Depot",
        "Drop off Taxes",
        "Be Rad"
    };

    public ErrandsToDoListController(one2doDbContext context)
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
    public IActionResult Create(string categoryName)
    {
        
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var category=_context.Categories.FirstOrDefault(c => c.Name ==categoryName);
        
        if (category == null)
        {
            return RedirectToAction("Index");
        } // More reliable way to get user ID
        // var newToDoList = new ToDoList
        // {
        //     Title = "Household ToDo Template",
        //     UserId = userId,
        //     CategoryId = 1 // Store only the CategoryId
        // };
        var newToDoList = new ToDoList
        {
           Title = $"{categoryName} ToDo Template",
           UserId = userId,
            Category = category,
            Description = $"To do related to {categoryName}",
            DueDate = DateTime.Now,
            IsCompleted = false
    };

        foreach (var item in Errands)
        {
            var taskItem = new TaskItem
            {
                Description = item,
                DueDate = DateTime.Now, 
                IsCompleted = false,
                ToDoList = newToDoList,
            
            };
            _context.TaskItems.Add(taskItem);
        }

        _context.ToDoLists.Add(newToDoList);
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



