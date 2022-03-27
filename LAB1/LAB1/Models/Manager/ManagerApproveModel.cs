using System.ComponentModel.DataAnnotations;

namespace LAB1.Models.Manager;

public class ManagerApproveModel : IValidatableObject
{
    public List<Entities.UserCategories.Client>? ClientsToApproveBankRegistration { get; set; }
    public List<Entities.UserCategories.Client>? ClientsToApproveInstallmentPlan { get; set; }
    public List<Entities.UserCategories.Client>? WaitingForCreditApprove { get; set; }
    public int? IdOfApprovedClientForCredit { get; set; }
    public int? IdOfApprovedClientForRegistration { get; set; }
    public int? IdOfApprovedClientForInstallmentPlan { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var errors = new List<ValidationResult>();

        return errors;
    }
}