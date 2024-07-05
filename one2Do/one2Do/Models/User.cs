using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace one2Do.Models;

public class User : IdentityUser
{
    [StringLength(100)]
    [MaxLength(100)]
    [Required]
    public string? Name { get; set; }
    public int StreakPoints { get; set; }
    public DateTime? LastLoginDate {get; set; }

}