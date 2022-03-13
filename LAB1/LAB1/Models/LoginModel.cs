using System.ComponentModel.DataAnnotations;

namespace LAB1.Models;

public class LoginModel
{
    [Required(ErrorMessage = "Email?")]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password?")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}