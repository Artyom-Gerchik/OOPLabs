namespace LAB1.Models.Bank;

public class FreezeBankDepositModel
{
    public Entities.UserCategories.Client? Client { get; set; }
    public Entities.Bank? Bank { get; set; }
    public int? IdOfDepositToFreeze { get; set; }
}