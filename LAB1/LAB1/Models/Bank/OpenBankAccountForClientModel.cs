using System.ComponentModel.DataAnnotations;
namespace LAB1.Models.Bank;

public class OpenBankAccountForClientModel
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public double? InitiallAmountOfMoney { get; set; }
}