using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using one2Do.Data;
using one2Do.Models.QuoteModels;
using one2Do.ViewModels;

namespace one2Do
{
    public class QuotesController : Controller
    {
        private readonly QuoteService _quoteService;
        private readonly one2doDbContext _dbContext;

        public QuotesController(QuoteService quoteService, one2doDbContext dbContext)
        {
            _quoteService = quoteService;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var quotes = await _quoteService.GetQuotesAsync();
            var viewModel = new SelectedQuoteViewModel { Quotes = quotes };
            return View(viewModel);
        }
// // public async Task<IActionResult> Index(bool showSavedQuotes = false)
// // {
// //     var viewModel = new SelectedQuoteViewModel();

// //     if (showSavedQuotes)
// //     {
// //         viewModel.SavedQuotes = await _dbContext.SavedQuotes.ToListAsync();
// //     }
// //     else
// //     {
// //         viewModel.Quotes = await _quoteService.GetQuotesAsync();
// //     }

// //     return View(viewModel);
// // }

//         public async Task<IActionResult> Index()
        
//         {
//             //use to display list of quotes from api:
//             var quotes = await _quoteService.GetQuotesAsync();
//             var viewModel = new SelectedQuoteViewModel { Quotes = quotes };
//             return View(viewModel);

//         //     //use for saved quotes, selected from the above list:
//         //     var savedQuotes = await _dbContext.SavedQuotes.ToListAsync();
//         //     var viewModel = new SelectedQuoteViewModel { SavedQuotes = savedQuotes };
//         //     return View(viewModel);
//         // }


        [HttpPost]
        public async Task<IActionResult> SaveQuote(SelectedQuoteViewModel model)
        {
            Console.WriteLine("first");

            if (ModelState.IsValid)
            {
                try
                {
                    Console.WriteLine("second");
                    var selectedQuote = new SavedQuote { Text = model.SelectedQuote };

                    _dbContext.SavedQuotes.Add(selectedQuote);
                    Console.WriteLine(selectedQuote);
                    Console.WriteLine("added");
                    await _dbContext.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    ModelState.AddModelError(string.Empty, "An error occurred while saving the quote.");
                }
            }
            else
            {
                foreach (var error in ModelState)
                {
                 // Log model state errors
            
                    Console.WriteLine(
                        $"Key: {error.Key}, Error: {string.Join(", ", error.Value.Errors.Select(e => e.ErrorMessage))}"
                    );
                }
            }

           // Re-fetch quotes in case of an error
            model.Quotes = await _quoteService.GetQuotesAsync();
            return View("Index", model);
        }
       public async Task<IActionResult> List()
        {
            var savedQuotes = await _dbContext.SavedQuotes.ToListAsync();
            // var viewModel = new SelectedQuoteViewModel { SavedQuotes = savedQuotes };
            return View(savedQuotes);
        } 
    }

}
