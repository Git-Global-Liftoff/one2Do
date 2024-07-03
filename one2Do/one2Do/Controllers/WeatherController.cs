using Microsoft.AspNetCore.Authorization;
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


    public WeatherController(IWForecastRepository WForecastRepository)
    {
        _WForecastRepository = WForecastRepository;
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
