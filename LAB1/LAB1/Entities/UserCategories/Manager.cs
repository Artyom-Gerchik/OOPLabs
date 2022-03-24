using System.ComponentModel.DataAnnotations.Schema;

namespace LAB1.Entities.UserCategories;

[Table("Managers")]
public class Manager : Operator
{
    public List<Client>? WaitingForRegistrationApprove { get; set; }
    public List<Client>? WaitingForInstallmentPlanApprove { get; set; }
    public List<Client>? WaitingForCreditApprove { get; set; }
}