using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using one2Do.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace one2Do;


public class CategoriesController : Controller
{   
    private one2doDbContext context; //

    public CategoriesController(one2doDbContext dbContext)
    {
        context = dbContext;
    }

    [HttpGet]

    public IActionResult Index()
    {
       
        return View();
    }

//     [HttpGet]

//     public IActionResult ////////do i need this? See codingEvents line 39 in EventCategoryController.cs
//     //this is checkign to see if model is valid....

 }

