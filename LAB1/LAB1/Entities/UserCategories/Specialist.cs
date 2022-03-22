using System.ComponentModel.DataAnnotations.Schema;

namespace LAB1.Entities.UserCategories;

[Table("Specialists")]
public class Specialist : User
{
    public Company? Company { get; set; }
    public int? CompanyId { get; set; }
    public List<Client>? ClientsToPaymentProject { get; set; }
}