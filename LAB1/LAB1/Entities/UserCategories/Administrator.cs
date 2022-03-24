using System.ComponentModel.DataAnnotations.Schema;

namespace LAB1.Entities.UserCategories;

[Table("Administrators")]
public class Administrator : User
{
    public int? BankId { get; set; }
    public List<OpennedBankAccount>? OpennedBankAccounts { get; set; }
    public List<DeletedBankAccount>? DeletedBankAccounts { get; set; }
}