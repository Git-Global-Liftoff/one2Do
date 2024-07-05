using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using one2Do.Models;

namespace one2Do.Controllers;

public class UserController : Controller
{
    private readonly UserManager<User> userManager;
    public UserController(UserManager<User> userManager)
    {
        this.userManager= userManager;
    }
    public async Task<IActionResult> Index()
    {
        var user = await userManager.GetUserAsync(User);
        if (user == null)
        {
            return RedirectToAction("Login", "Account");
        }
        return View(user);
    }

    public IActionResult Todo()
    {
        return View();
    }


}
