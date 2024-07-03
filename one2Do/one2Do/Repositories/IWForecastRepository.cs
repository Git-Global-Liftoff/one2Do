using one2Do.OpenWeatherMap_Model;

namespace one2Do;

public interface IWForecastRepository
{
    WeatherResponse GetForecast(string city);

}
