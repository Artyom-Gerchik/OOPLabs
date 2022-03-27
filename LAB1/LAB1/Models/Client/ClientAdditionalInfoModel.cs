using System.ComponentModel.DataAnnotations;
using LAB1.Entities;

namespace LAB1.Models.Client;

public class ClientAdditionalInfoModel : IValidatableObject
{
    [Required]
    [Display(Name = "Passport Number And Series")]
    [StringLength(9, MinimumLength = 9, ErrorMessage = "Length of Passport Number And Series 9 chars")]
    public string PassportNumberAndSeries { get; set; }

    [Required]
    [Display(Name = "Identification Number")]
    [StringLength(14, MinimumLength = 14, ErrorMessage = "Length of Identification Number should be 14 digits")]
    public string IdentificationNumber { get; set; }

    public int? IdOfSelectedCompany { get; set; }
    public List<Company>? Companies { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var errors = new List<ValidationResult>();
        if (IdentificationNumber[..6].Any(x => char.IsLetter(x)) || char.IsDigit(IdentificationNumber[7]) ||
            IdentificationNumber[^2..^1].Any(x => char.IsDigit(x)))
            errors.Add(new ValidationResult("Passport Identification number is not correct"));

        if (PassportNumberAndSeries[..1].Any(x => char.IsDigit(x)))
            errors.Add(new ValidationResult("Passport series and number are not correct"));

        return errors;
    }
}