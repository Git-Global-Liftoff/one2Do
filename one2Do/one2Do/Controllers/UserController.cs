using Microsoft.AspNetCore.Mvc;
using one2Do.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using one2Do.Models;

namespace one2Do.Controllers
{
    [Authorize] // To ensure only authenticated users can access actions within this controller
    public class UserController : Controller
    {
        private readonly one2doDbContext _context;

        // Constructor to initialize the database context
        public UserController(one2doDbContext context)
        {
            _context = context;
        }

        // Action to handle requests to the User's main page
        public IActionResult Index()
        {
            // Get a random quote from the database
            var quote = _context.Quotes.OrderBy(q => EF.Functions.Random()).FirstOrDefault();

            // Pass the quote to the view using ViewData
            ViewData["Quote"] = quote?.Text;

            return View();
        }

        // Action to handle requests to the user's To-Do list page
        public IActionResult Todo()
        {
            return View();
        }

        // Action to handle search by category
        [HttpPost]
        public IActionResult SearchByCategory(string category)
        {
            var lists = _context.ListTemplates
                .Include(lt => lt.TaskItems)
                .Include(lt => lt.Categories)
                .AsEnumerable() //helped solve the exception error on search results page 
                .Where(lt => lt.Categories != null && lt.Categories.Any(c => c.ListType.Contains(category)))
                .ToList();

            // Pass the search results to the view
            ViewData["Lists"] = lists;
            ViewData["Category"] = category;

            return View(lists);
        }
    }
}
