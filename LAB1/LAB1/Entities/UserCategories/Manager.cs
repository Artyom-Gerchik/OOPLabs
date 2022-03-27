using System.ComponentModel.DataAnnotations.Schema;
using LAB1.Entities.ManagerRollBack;

namespace LAB1.Entities.UserCategories;

[Table("Managers")]
public class Manager : Operator
{
    public List<Client>? WaitingForRegistrationApprove { get; set; }
    public List<Client>? WaitingForInstallmentPlanApprove { get; set; }
    public List<Client>? WaitingForCreditApprove { get; set; }
    public List<SpecialistSendClients>? SendClientsList { get; set; }
    public List<SpecialistAddedMoney>? SpecialistAddedMonies { get; set; }
}