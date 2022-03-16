using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LAB1.Entities.UserCategories;

//[Table("Clients")]
public class Client : User
{
    public string? PassportNumberAndSeries { get; set; }
    public string? IdentificationNumber { get; set; }
    public int? BankId { get; set; }
    public List<BankAccount>? OpennedBankAccounts { get; set; }
    public bool? ApprovedByManager { get; set; }

    //public int? ManagerId { get; set; }
}