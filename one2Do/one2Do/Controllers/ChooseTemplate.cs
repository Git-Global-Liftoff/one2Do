using Microsoft.AspNetCore.Mvc;

namespace one2Do;

public class ChooseTemplateController: Controller
{
    private readonly one2doDbContext context;
    public ChooseTemplateController(one2doDbContext dbContext)
    {
        context=dbContext;
    }
    public IActionResult Index()
    {
        return View();
    }
}
