using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using one2Do.Data;
using one2Do.Models.ToDoModels;
using one2Do.ViewModels;
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Ensure we are only showing ToDoLists for the logged-in user
            var toDoLists = await _context.ToDoLists
                .Include(t => t.Category) // Ensure the category data is loaded
                .Where(t => t.UserId == userId)
                .ToListAsync();
            return View(toDoLists);
        }

        // GET: ToDoList/Create
        public IActionResult Create()
        {
            var categories = _context.Categories.ToList();
            var viewModel = new AddToDoListViewModel(categories);
            return View(viewModel);
        }

        // POST: ToDoList/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddToDoListViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Fetch the user ID from the current user claim
                var newToDoList = new ToDoList
                {
                    Title = viewModel.Title,
                    UserId = userId,
                    CategoryId = viewModel.CategoryId // Ensure this handles the nullable scenario
                };

                _context.ToDoLists.Add(newToDoList);
                await _context.SaveChangesAsync();
                return Redirect("/");
            }
            // Reload categories if model state is not valid
            viewModel.Categories = new SelectList(_context.Categories, "Id", "Name", viewModel.CategoryId);
            return View(viewModel);
        }

        // Additional methods for Edit, Delete, Details etc. will be here
    }
}
