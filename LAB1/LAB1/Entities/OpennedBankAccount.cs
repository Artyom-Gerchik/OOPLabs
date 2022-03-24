using System.ComponentModel.DataAnnotations;
using LAB1.Entities.UserCategories;

namespace LAB1.Entities;

public class OpennedBankAccount
{
    [Key] public int? Id { get; set; }
    public Client? Client { get; set; }
    public BankAccount? BankAccount { get; set; }

    public OpennedBankAccount()
    {
    }

    public OpennedBankAccount(Client client, BankAccount bankAccount)
    {
        Client = client;
        BankAccount = bankAccount;
    }
}