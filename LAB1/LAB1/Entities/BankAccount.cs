using System.ComponentModel.DataAnnotations;

namespace LAB1.Entities;

public class BankAccount
{
    public int? Id { get; set; }
    public int? ClientId { get; set; }
    public int? BankId { get; set; }
    public double? AmountOfMoney { get; set; }
    public string? Name { get; set; }
}