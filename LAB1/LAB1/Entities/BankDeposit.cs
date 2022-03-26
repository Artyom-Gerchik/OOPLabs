namespace LAB1.Entities;

public class BankDeposit
{
    public int? Id { get; set; }
    public DateTime? DateOfDeal { get; set; }
    public DateTime DateOfMoneyBack { get; set; }
    public int? HowMuchLasts { get; set; }
    public int? ClientId { get; set; }
    public int? BankId { get; set; }
    public double? AmountOfMoney { get; set; }
    public string? Name { get; set; }
    public double? Percent { get; set; }
    public bool? Hidden { get; set; }
    public bool? Blocked { get; set; }
    public bool? Frozen { get; set; }
}