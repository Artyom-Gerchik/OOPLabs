using System.ComponentModel.DataAnnotations;

namespace LAB1.Models.Client;

public class ClientGetApproveModel : IValidatableObject
{
    public List<Entities.Bank>? ClientBanks { get; set; }
    public List<Entities.UserCategories.Manager>? Managers { get; set; }
    public int? IdOfSelectedBank { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var errors = new List<ValidationResult>();

        return errors;
    }
}