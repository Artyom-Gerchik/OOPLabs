using System.ComponentModel.DataAnnotations.Schema;

namespace LAB1.Entities.UserCategories;

[Table("Operators")]
public class Operator : User
{
    public int? BankId { get; set; }
    public List<Client>? ClientsWaitingForSalaryProject { get; set; }
}