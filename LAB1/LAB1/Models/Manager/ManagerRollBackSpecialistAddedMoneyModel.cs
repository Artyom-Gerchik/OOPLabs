using System.ComponentModel.DataAnnotations;

namespace LAB1.Models.Manager;

public class ManagerRollBackSpecialistAddedMoneyModel : IValidatableObject
{
    public Entities.UserCategories.Manager? Manager { get; set; }
    public int? IdOfClientRequest { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var errors = new List<ValidationResult>();

        return errors;
    }
}