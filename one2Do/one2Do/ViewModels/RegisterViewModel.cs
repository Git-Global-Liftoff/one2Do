using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace one2Do.ViewModels;

public class RegisterViewModel
{
    [Required]
    public string? Name { get; set; }
    
    [Required]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }
    
    [Compare("Password", ErrorMessage = "Passwords don't match.")]
    [Display(Name = "Confirm Password")]
    public string? ConfirmPassword { get; set; }
    public string? Role {get; set; }
    public IEnumerable<SelectListItem>? RoleList {get; set; }
}
