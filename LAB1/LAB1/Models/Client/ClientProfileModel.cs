using System.ComponentModel.DataAnnotations;
namespace LAB1.Models.Client;

public class ClientProfileModel : IValidatableObject
{
    public Entities.UserCategories.Client Client { get; set; }
    public int? SelectedBankId { get; set; }
    public List<Entities.Bank> BanksWhereApproved { get; set; }
    public List<Entities.Bank> Banks { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var errors = new List<ValidationResult>();

        return errors;
    }
}