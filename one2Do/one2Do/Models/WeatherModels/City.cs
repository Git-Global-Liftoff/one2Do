using System.ComponentModel.DataAnnotations;

namespace one2Do.OpenWeatherMap_Model;

public class City
{
    [Display(Name = "City name:")]
    public string Name { get; set;}

    [Display(Name = "Temp.")]
    public float Temperature { get; set;}

    [Display(Name = "Humidity")]
    public int Humidity { get; set;}

    [Display(Name = "Pressure:")]
    public int Pressure { get; set;}

    [Display(Name = "Wind Speed:")]
    public float Wind { get; set;}

    [Display(Name = "Weather Condition:.")]
    public string Weather { get; set;}

}
