using System.ComponentModel.DataAnnotations;
using LAB1.Entities.UserCategories;

namespace LAB1.Entities.AdminRollBack;

public class RollBackOpennedCredit
{
    public RollBackOpennedCredit()
    {
    }

    public RollBackOpennedCredit(Client client, Credit credit)
    {
        Client = client;
        Credit = credit;
    }

    [Key] public int? Id { get; set; }
    public Client? Client { get; set; }
    public Credit? Credit { get; set; }
}