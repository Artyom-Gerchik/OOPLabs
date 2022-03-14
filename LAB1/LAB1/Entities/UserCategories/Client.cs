using System.ComponentModel.DataAnnotations;

namespace LAB1.Entities.UserCategories;

public class Client : User
{
    public string? PassportNumberAndSeries { get; set; }
    public string? IdentificationNumber { get; set; }

    public int? BankId { get; set; }

    public List<BankAccount>? OpennedBankAccounts { get; set; }
}