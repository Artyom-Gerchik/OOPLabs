using System.ComponentModel.DataAnnotations;
namespace LAB1.Models.Manager;

public class ManagerRollBackSpecialistSendModel : IValidatableObject
{
    public Entities.UserCategories.Manager? Manager { get; set; }
    public int? IdOfSelectedRequest { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var errors = new List<ValidationResult>();

        return errors;
    }
}