using System.ComponentModel.DataAnnotations;

namespace one2Do.ViewModels;

public class LoginViewModel
{
    [Required(ErrorMessage = "Username is required.")]
    public string? Username { get; set; }

    [Required(ErrorMessage = "Username is required.")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Display(Name = "Remember Me")]
    public bool RememberMe { get; set; }

}
