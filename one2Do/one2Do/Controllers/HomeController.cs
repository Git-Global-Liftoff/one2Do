using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using one2Do.Models;
using one2Do.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace one2Do.Controllers
{
    // [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly one2doDbContext _context;

        public HomeController(ILogger<HomeController> logger, one2doDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Get a random quote from the database
            var quote = _context.Quotes.OrderBy(q => EF.Functions.Random()).FirstOrDefault();

            // Pass the quote to the view
            ViewData["Quote"] = quote?.Text;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
