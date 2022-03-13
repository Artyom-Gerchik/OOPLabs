using System.ComponentModel.DataAnnotations;

namespace LAB1.Models;

public class LoginModel
{
    [Required(ErrorMessage = "Не указан Email")]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "Не указан пароль")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}