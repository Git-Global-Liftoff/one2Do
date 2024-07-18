using System.ComponentModel.DataAnnotations.Schema;

namespace one2Do.Models;

public class Image
{
    [NotMapped]
    public IFormFile Images { get; set; }
    public string UserId { get; set; }
    public int Id { get; set; }
    public string ImageUrl { get; set; }
}
