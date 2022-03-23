using LAB1.Entities;

namespace LAB1.Models.Client;

public class GetTheSalaryProjectForClientModel
{
    public List<BankAccount>? ClientBankAccounts { get; set; }
    public int? IdOfSelectedBankAccount { get; set; }
}