using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using one2Do.Data;
using one2Do.Models.ToDoModels;
using one2Do.ViewModels;

namespace one2Do.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly one2doDbContext _context;

        public ToDoListController(one2doDbContext context)
        {
            _context = context;
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
                var toDoList = new ToDoList
                {
                    Title = viewModel.Title,
                    Description = viewModel.Description,
                    DueDate = viewModel.DueDate,
                    IsCompleted = viewModel.IsCompleted,
                    CategoryId = viewModel.CategoryId,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                };

                _context.Add(toDoList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            viewModel.Categories = new SelectList(_context.Categories, "Id", "Name", viewModel.CategoryId);
            return View(viewModel);
        }

        // GET: ToDoList/Index
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var toDoLists = await _context.ToDoLists
                .Include(t => t.Category)
                .Where(t => t.UserId == userId)
                .ToListAsync();

            var viewModel = new ToDoListViewModel
            {
                ToDoItems = toDoLists.Select(t => new ToDoListItemViewModel
                {
                    Title = t.Title,
                    Description = t.Description,
                    DueDate = t.DueDate,
                    IsCompleted = t.IsCompleted,
                    CategoryName = t.Category?.Name ?? "No Category"
                }).ToList(),
                TotalTasks = toDoLists.Count,
                CompletedTasks = toDoLists.Count(t => t.IsCompleted)
            };

            return View(viewModel);
        }
    }
}
