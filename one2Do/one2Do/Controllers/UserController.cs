using Microsoft.AspNetCore.Mvc;

namespace one2Do.Controllers;

public class UserController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Todo()
    {
        return View();
    }


}
