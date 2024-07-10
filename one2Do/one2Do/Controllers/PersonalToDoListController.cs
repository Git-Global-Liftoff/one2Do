using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using one2Do.Controllers;
using one2Do.Data;
using one2Do.Models.ToDoModels;
using System.Security.Claims;


namespace one2Do;


    [Authorize] 

    public class PersonalToDoController : Controller
    {
        // Define professional items as properties....don't need to do, any longer, actually?
       private readonly one2doDbContext _context;
        private readonly string[] PersonalTasks = { "Manicure", "Lunch with Caroline", "Research Therapists", "Eat Lots of Ice Cream", "Oil Pulling", "Test New Smoothie Recipe", "Solo Dance Party" }; 

        public PersonalToDoController(one2doDbContext context) 
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
        public async Task<IActionResult> Create()
        {
        
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // More reliable way to get user ID
                var newToDoList = new ToDoList
                {
                    Title = "Personal ToDo Template",
                    UserId = userId,
                    CategoryId = 1 // Store only the CategoryId
                };

                _context.Add(newToDoList);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return Redirect("/");
            }
           
        }
    }