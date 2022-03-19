using System.ComponentModel.DataAnnotations;

namespace LAB1.Entities;

public class BankApproves
{
    public BankApproves()
    {
    }

    public BankApproves(Bank bank, bool approved)
    {
        Bank = bank;
        Approved = approved;
    }

    [Key] public int? Id { get; set; }
    public Bank? Bank { get; set; }
    public bool? Approved { get; set; }
}