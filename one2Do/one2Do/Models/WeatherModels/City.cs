using System.ComponentModel.DataAnnotations;
using one2Do.Models;

namespace one2Do.WeatherModel;

public class City
{
    [Key]
    public int Id { get; set; }
    public string UserId { get; set; } 

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

    public User User { get; set; }
}
