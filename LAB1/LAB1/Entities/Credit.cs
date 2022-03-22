using System.ComponentModel.DataAnnotations;

namespace LAB1.Entities;

public class Credit
{
    [Key] public int? Id { get; set; }
    public int? BankId { get; set; }
    public int? ClientId { get; set; }
    public int? DurationInMonths { get; set; }
    public double? Percent { get; set; }
    public double? AmountOfMoney { get; set; }
    public DateTime? DateOfMoneyBack { get; set; }
    public int? HowMuchLasts { get; set; }
}