using System.ComponentModel.DataAnnotations.Schema;
using LAB1.Entities.AdminRollBack;

namespace LAB1.Entities.UserCategories;

[Table("Operators")]
public class Operator : User
{
    public int? BankId { get; set; }
    public List<Client>? ClientsWaitingForSalaryProject { get; set; }

    public List<RollBackTransferBetweenBankAccounts>? TransfersBetweenBankAccounts { get; set; }
}