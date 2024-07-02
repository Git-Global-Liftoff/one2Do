using Microsoft.AspNetCore.Mvc;

namespace one2Do.Controllers;

public class ListTemplateController : Controller
{
    private one2doDbContext context;

    public ListTemplateController(one2doDbContext dbContext)
    {
        context= dbContext;
    }
    
    public IActionResult Index()
    {
        return View();
    }
}
