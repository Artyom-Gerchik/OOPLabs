using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LAB1.Entities;

public class BankApproves
{
    [Key] public int? Id { get; set; }
    public Bank? Bank { get; set; }
    public bool? Approved { get; set; }

    public BankApproves()
    {
    }

    public BankApproves(Bank bank, bool approved)
    {
        Bank = bank;
        Approved = approved;
    }
}