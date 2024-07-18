using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace one2Do.WeatherModel;

public class City
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; }

    [Required]
    [Display(Name = "City name:")]
    public string Name { get; set; }

    // These properties won't be mapped to the database
    [NotMapped]
    [Display(Name = "Temp.")]
    public float Temperature { get; set; }

    [NotMapped]
    [Display(Name = "Humidity")]
    public int Humidity { get; set; }

    [NotMapped]
    [Display(Name = "Pressure:")]
    public int Pressure { get; set; }

    [NotMapped]
    [Display(Name = "Wind Speed:")]
    public float Wind { get; set; }

    [NotMapped]
    [Display(Name = "Weather Condition:.")]
    public string Weather { get; set; }
}
