using System.ComponentModel.DataAnnotations.Schema;

namespace LAB1.Entities.UserCategories;

[Table("Clients")]
public class Client : User
{
    public string? PassportNumberAndSeries { get; set; }
    public string? IdentificationNumber { get; set; }
    public int? CurrentBankId { get; set; }
    public double? BankBalance { get; set; }
    public double? Salary { get; set; }
    public List<BankAccount>? OpennedBankAccounts { get; set; }
    public List<Bank>? Banks { get; set; }
    public List<BankApproves>? BanksAndApproves { get; set; }
    public List<BankDeposit>? OpennedBankDeposits { get; set; }
    public List<InstallmentPlanApproves>? InstallmentPlansAndApproves { get; set; }
    public List<CreditsAndApproves>? CreditsAndApproves { get; set; }
    public Company? Work { get; set; }
}