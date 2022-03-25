using System.ComponentModel.DataAnnotations.Schema;
using LAB1.Entities.AdminRollBack;

namespace LAB1.Entities.UserCategories;

[Table("Administrators")]
public class Administrator : User
{
    public int? BankId { get; set; }
    public List<OpennedBankAccount>? OpennedBankAccounts { get; set; }
    public List<DeletedBankAccount>? DeletedBankAccounts { get; set; }
    public List<RollBackTransferBetweenBankAccounts>? TransfersBetweenBankAccounts { get; set; }
    public List<RollBackOpenedDeposit>? OpennedDepositsToRollBack { get; set; }
    public List<RollBackClosedDeposit>? ClosedDepositsToRollBack { get; set; }
    public List<RollBackTransferBetweenBankDeposits>? TransfersBetweenBankDeposits { get; set; }
    public List<RollBackOpennedInstallmentPlan>? OpennedInstallmentPlans { get; set; }
}