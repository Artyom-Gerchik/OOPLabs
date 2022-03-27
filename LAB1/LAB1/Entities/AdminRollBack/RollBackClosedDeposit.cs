using System.ComponentModel.DataAnnotations;
using LAB1.Entities.UserCategories;

namespace LAB1.Entities.AdminRollBack;

public class RollBackClosedDeposit
{
    public RollBackClosedDeposit()
    {
    }

    public RollBackClosedDeposit(Client client, BankDeposit bankDeposit)
    {
        Client = client;
        BankDeposit = bankDeposit;
    }

    [Key] public int? Id { get; set; }
    public Client? Client { get; set; }
    public BankDeposit? BankDeposit { get; set; }
}