using System.ComponentModel.DataAnnotations;
using LAB1.Entities.UserCategories;

namespace LAB1.Entities.AdminRollBack;

public class RollBackDeletedCredit
{
    public RollBackDeletedCredit()
    {
    }

    public RollBackDeletedCredit(Client client, Credit credit, Transfer transfer)
    {
        Client = client;
        Credit = credit;
        Transfer = transfer;
    }

    [Key] public int? Id { get; set; }
    public Client? Client { get; set; }
    public Credit? Credit { get; set; }
    public Transfer? Transfer { get; set; }
}