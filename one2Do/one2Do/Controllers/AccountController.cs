using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using one2Do.Models;
using one2Do.ViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace one2Do.Controllers;


public class AccountController : Controller
{
    private readonly SignInManager<User> signInManager;
    private readonly UserManager<User> userManager;


    public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
    {
        this.signInManager = signInManager;
        this.userManager = userManager;
    }





    public IActionResult Login ()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Login (LoginViewModel model)
    {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.Username);
                if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
                {
                    var signInResult = await signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
                    if (signInResult.Succeeded)
                    {
                        // Increment streak points on every login
                        user.StreakPoints += 1;
                        await userManager.UpdateAsync(user);

                        return RedirectToAction("Index", "User");
                    }
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }

        return View(model);
        }
    
    
    
    public IActionResult Register ()
    {
        var model = new RegisterViewModel
    {
        RoleList = new List<SelectListItem>
        {
            new SelectListItem { Value = "Basic", Text = "Basic" },
            new SelectListItem { Value = "Premium", Text = "Premium" }
        }
        };
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> Register (RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            User user = new()
            {
                Name = model.Name,
                UserName = model.Email,
                Email = model.Email
            };

            var result = await userManager.CreateAsync(user, model.Password!);

            if (result.Succeeded)
            {
                 if (!string.IsNullOrEmpty(model.Role))
            {
                await userManager.AddToRoleAsync(user, model.Role);
            }
                await signInManager.SignInAsync(user, false);
                
                return RedirectToAction("Index", "Home");

            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        return View();
    }
    
    
    
    public async Task<IActionResult> Logout ()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

}
