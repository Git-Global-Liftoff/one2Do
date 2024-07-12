using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using one2Do.Models;
using System.Collections.Generic;
using System.Linq;
using one2Do.Data;
using one2Do.WeatherModel;

namespace one2Do.Controllers
{
    [Authorize]
    public class CitiesController : Controller
    {
        private readonly one2doDbContext _context;
        private readonly IWForecastRepository _WForecastRepository;
        private readonly UserManager<User> _userManager;


        public CitiesController(one2doDbContext context, UserManager<User> userManager, IWForecastRepository WForecastRepository)
        {
            _context = context;
            _userManager = userManager;
            _WForecastRepository = WForecastRepository;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var cities = _context.Cities.Where(c => c.UserId == userId).ToList();

            var cityWeatherList = new List<City>();
            foreach (var city in cities)
            {
                WeatherResponse weatherResponse = _WForecastRepository.GetForecast(city.Name);
                if (weatherResponse != null)
                {
                    var viewModel = new City
                    {
                        Name = weatherResponse.Name,
                        Temperature = weatherResponse.Main.Temp,
                        Humidity = weatherResponse.Main.Humidity,
                        Weather = weatherResponse.Weather[0].Main,
                        Wind = weatherResponse.Wind.Speed
                    };
                    cityWeatherList.Add(viewModel);
                }
            }

            return View(cityWeatherList);
        }


        [HttpPost]
        public IActionResult AddCity(string cityName)
        {
            var userId = _userManager.GetUserId(User);
            if (!string.IsNullOrEmpty(cityName) && !_context.Cities.Any(c => c.Name == cityName && c.UserId == userId))
            {
                _context.Cities.Add(new CityNames { Name = cityName, UserId = userId });
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult RemoveCity(string cityName)
        {
             var city = _context.Cities.FirstOrDefault(c => c.Name == cityName && c.UserId == _userManager.GetUserId(User));
            if (city != null)
            {
                _context.Cities.Remove(city);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}