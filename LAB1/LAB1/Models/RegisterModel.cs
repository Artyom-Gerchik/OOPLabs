using System.ComponentModel.DataAnnotations;

namespace LAB1.Models;

public class RegisterModel : IValidatableObject
{
    [Required]
    [Display(Name = "Email")]
    [RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Correct Email Address")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "Name")]
    public string Name { get; set; }

    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "Surname")]
    public string Surname { get; set; }

    [Required]
    [DataType(DataType.Text)]
    [Display(Name = "Patronymic")]
    public string Patronymic { get; set; }

    [Required]
    [Display(Name = "Phone Number")]
    [DataType(DataType.PhoneNumber)]
    [StringLength(13, MinimumLength = 13, ErrorMessage = "Length of Phone Number should be 12 digits")]
    public string PhoneNumber { get; set; }

    [Required]
    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    [StringLength(30, MinimumLength = 6, ErrorMessage = "Length of Password should be between 6 and 30 letters")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    [Compare("Password", ErrorMessage = "Passwords doesn't match")]
    public string ConfirmPassword { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var errors = new List<ValidationResult>();

        if (PhoneNumber[0] != '+') errors.Add(new ValidationResult("Phone Number should start with '+'"));

        if (PhoneNumber[1..].Any(x => char.IsLetter(x))) errors.Add(new ValidationResult("Phone Number can't contain letters"));

        if (Name.Any(x => char.IsDigit(x))) errors.Add(new ValidationResult("Name can't contain digits"));

        if (Surname.Any(x => char.IsDigit(x))) errors.Add(new ValidationResult("Surname can't contain digits"));

        if (Patronymic.Any(x => char.IsDigit(x))) errors.Add(new ValidationResult("Patronymic can't contain digits"));

        return errors;
    }
}