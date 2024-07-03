using Microsoft.AspNetCore.Mvc;
using one2Do.Models;

namespace one2Do.Controllers;

[Route("/ListTemplate")]
public class ListTemplateController : Controller
{
    private one2doDbContext context;

    public ListTemplateController(one2doDbContext dbContext)
    {
        context= dbContext;
    }
    
    [HttpGet("")]
    public IActionResult RenderListTemplatePage()
    {
        ListTemplate newList= new ListTemplate();
        return View("Index",newList );
    }
    
}
