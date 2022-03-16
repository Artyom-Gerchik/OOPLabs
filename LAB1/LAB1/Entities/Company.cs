using System.ComponentModel.DataAnnotations;

namespace LAB1.Entities;

public class Company
{
    [Key] public int? Id { get; set; }
    public string? Type { get; set; }
    public string? LegalName { get; set; }
    public string? PayerAccountNumber { get; set; }
    public string? BankIdentificationCode { get; set; }
    public string? LegalAddress { get; set; }
}