using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Identity.Client;
using one2Do.Models;
using one2Do.WeatherModel;


namespace one2Do.Controllers;


[Authorize]
public class WeatherController : Controller
{
    private readonly IWForecastRepository _WForecastRepository;
    private readonly UserManager<User> userManager;
    private readonly one2doDbContext _context;


    public WeatherController(IWForecastRepository WForecastRepository, UserManager<User> userManager, one2doDbContext context)
    {
        _WForecastRepository = WForecastRepository;
        this.userManager = userManager;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var user = await userManager.GetUserAsync(User);
        var cities = _context.Cities.Where(c => c.UserId == user.Id).ToList();

        // Initialize the model with an empty list
        var model = new MultipleCity{ Cities = cities };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> AddCity(string cityName)
    {
        var user = await userManager.GetUserAsync(User);
        var cities = _context.Cities.Where( c=> c.UserId == user.Id).ToList();
        if (cities.Count < 3)
        {
            var weatherResponse = _WForecastRepository.GetForecast(cityName);
            
            if (weatherResponse != null)
            {
                var City = new City
                {
                    Name = cityName,
                    Temperature = weatherResponse.Main.Temp,
                    Humidity = weatherResponse.Main.Humidity,
                    Pressure = weatherResponse.Main.Pressure,
                    Weather = weatherResponse.Weather[0].Main,
                    Wind = weatherResponse.Wind.Speed,
                    UserId = user.Id
                };
                _context.Cities.Add(City);
                await _context.SaveChangesAsync();

                cities.Add(City);
            }
            else
            {
                ModelState.AddModelError("", "Could not retrieve weather data. Please try again.");
            }
        }
        else
        {
            ModelState.AddModelError("", "You can only add up to 3 cities.");
        }
        var model = new MultipleCity { Cities = cities };
        return View("Index", model);
    }


    [HttpGet]
    public IActionResult SearchByCity()
    {
        var viewModel = new SearchByCity();
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult SearchByCity(SearchByCity model)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("City", "Weather", new { city = model.CityName});
        }

        return View(model);
    }



    [HttpGet]
    public IActionResult City(string city)
    {
        WeatherResponse weatherResponse = _WForecastRepository.GetForecast(city);
        City viewModel = new City();
        if(weatherResponse != null)
        {
            viewModel.Name = weatherResponse.Name;
            viewModel.Temperature = weatherResponse.Main.Temp;
            viewModel.Humidity = weatherResponse.Main.Pressure;
            viewModel.Weather = weatherResponse.Weather[0].Main;
            viewModel.Wind = weatherResponse.Wind.Speed;
        }
        return View(viewModel);
    }

}
