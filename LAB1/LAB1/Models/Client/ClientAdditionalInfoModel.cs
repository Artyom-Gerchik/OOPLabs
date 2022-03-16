using System.ComponentModel.DataAnnotations;

namespace LAB1.Models.Client;

public class ClientAdditionalInfoModel : IValidatableObject
{
    [Display(Name = "Passport Number And Series")]
    public string PassportNumberAndSeries { get; set; }

    [Display(Name = "Identification Number")]
    public string IdentificationNumber { get; set; }
    

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        List<ValidationResult> errors = new List<ValidationResult>();
        if (IdentificationNumber[..6].Any(x => char.IsLetter(x)) ||
            char.IsDigit(this.IdentificationNumber[7]) ||
            IdentificationNumber[^2..^1].Any(x => char.IsDigit(x)))
        {
            errors.Add(new ValidationResult("Passport Identification number is not correct"));
        }

        if (PassportNumberAndSeries.Length != 9)
        {
            errors.Add(new ValidationResult("Passport series and number are not correct"));
        }

        return errors;
    }
}