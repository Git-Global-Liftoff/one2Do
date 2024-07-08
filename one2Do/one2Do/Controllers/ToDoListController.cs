using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using one2Do.Data;
using one2Do.Models.ToDoModels;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Security.Claims;

namespace one2Do.Controllers
{
    [Authorize]
    public class ToDoListController : Controller
    {
        private readonly one2doDbContext _context;

        public ToDoListController(one2doDbContext context)
        {
            _context = context;
        }

        // GET: ToDoList
        public async Task<IActionResult> Index()
        {
            // Fetch ToDoLists from the database
            var toDoLists = await _context.ToDoLists.ToListAsync();
            return View(toDoLists);
        }

        // GET: ToDoList/Create
        public IActionResult Create()
        {
            var viewModel = new AddToDoListViewModel
            {
                Categories = _context.Categories.Select(c => new SelectListItem 
                { 
                    Value = c.Id.ToString(), 
                    Text = c.Name 
                }).ToList()
            };
            return View(viewModel);
        }

        // POST: ToDoList/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddToDoListViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // More reliable way to get user ID
                var newToDoList = new ToDoList
                {
                    Title = viewModel.Title,
                    UserId = userId,
                    CategoryId = viewModel.CategoryId // Store only the CategoryId
                };

                _context.Add(newToDoList);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return Redirect("/");
            }
            // Reload categories if model state is not valid or to display in case of failure
            viewModel.Categories = _context.Categories.Select(c => new SelectListItem 
            { 
                Value = c.Id.ToString(), 
                Text = c.Name 
            }).ToList();  
            return View(viewModel);
        }
    }
}
