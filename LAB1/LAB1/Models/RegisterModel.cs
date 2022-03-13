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
    [Display(Name = "Surname")]
    public string Surname { get; set; }

    [Required]
    [Display(Name = "Patronymic")]
    public string Patronymic { get; set; }

    [Display(Name = "Passport Number And Series")]
    public string PassportNumberAndSeries { get; set; }

    [Display(Name = "Identification Number")]
    public string IdentificationNumber { get; set; }

    [Required]
    [Display(Name = "Phone Number")]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "The Password field is required")]
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
        List<ValidationResult> errors = new List<ValidationResult>();
        if (this.PhoneNumber[0] != '+')
        {
            errors.Add(new ValidationResult("Phone Number should start with '+'"));
        }

        if (this.PhoneNumber[1..].Any(x => char.IsLetter(x)))
        {
            errors.Add(new ValidationResult("Phone Number can't contain letters"));
        }

        if (this.Name.Any(x => char.IsDigit(x)))
        {
            errors.Add(new ValidationResult("First Name can't contain digits"));
        }

        if (this.Surname.Any(x => char.IsDigit(x)))
        {
            errors.Add(new ValidationResult("Last Name can't contain digits"));
        }

        if (this.Patronymic.Any(x => char.IsDigit(x)))
        {
            errors.Add(new ValidationResult("Second Name can't contain digits"));
        }

        if (this.IdentificationNumber[..6].Any(x => char.IsLetter(x)) ||
            char.IsDigit(this.IdentificationNumber[7]) ||
            this.IdentificationNumber[^2..^1].Any(x => char.IsDigit(x)))
        {
            errors.Add(new ValidationResult("Passport Identification number is not correct"));
        }

        if (this.PassportNumberAndSeries.Length != 9)
        {
            errors.Add(new ValidationResult("Passport series and number are not correct"));
        }


        return errors;
    }
}