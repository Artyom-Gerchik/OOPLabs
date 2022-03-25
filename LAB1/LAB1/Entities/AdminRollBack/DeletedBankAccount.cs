using System.ComponentModel.DataAnnotations;
using LAB1.Entities.UserCategories;

namespace LAB1.Entities.AdminRollBack;

public class DeletedBankAccount
{
    [Key] public int? Id { get; set; }
    public Client? Client { get; set; }
    public BankAccount? BankAccount { get; set; }

    public DeletedBankAccount()
    {
    }

    public DeletedBankAccount(Client client, BankAccount bankAccount)
    {
        Client = client;
        BankAccount = bankAccount;
    }
}