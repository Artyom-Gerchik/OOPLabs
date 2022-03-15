using System.ComponentModel.DataAnnotations;

namespace LAB1.Entities;

public class BankAccount
{
    [Key] public int? Id { get; set; }
    public int? ClientId { get; set; }
    public int? BankId { get; set; }
}