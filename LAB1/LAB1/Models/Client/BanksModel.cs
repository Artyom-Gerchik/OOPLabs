using System.ComponentModel.DataAnnotations;
namespace LAB1.Models;

public class BanksModel : IValidatableObject
{
    public List<Entities.Bank>? Banks { get; set; }
    public int? SelectedBankId { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var errors = new List<ValidationResult>();

        return errors;
    }

}