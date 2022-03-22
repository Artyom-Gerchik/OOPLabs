using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LAB1.Entities.UserCategories;

namespace LAB1.Entities;

[Table("Companies")]
public class Company
{
    [Key] public int? Id { get; set; }
    public string? Type { get; set; }
    public string? LegalName { get; set; }
    public string? PayerAccountNumber { get; set; }
    public string? BankIdentificationCode { get; set; }
    public string? LegalAddress { get; set; }
    public List<Client>? Workers { get; set; }
    public double? SalaryForWorkers { get; set; }
}