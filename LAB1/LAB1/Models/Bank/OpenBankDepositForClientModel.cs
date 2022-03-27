using System.ComponentModel.DataAnnotations;

namespace LAB1.Models.Bank;

public class OpenBankDepositForClientModel
{
    public DateTime DateOfMoneyBack { get; set; }

    [Required] public double? AmountOfMoney { get; set; }

    [Required] public string? Name { get; set; }

    [Required] public double? Percent { get; set; }
}