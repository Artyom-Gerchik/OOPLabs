namespace LAB1.Models.Bank;

public class GetMoneyFromDepositModel
{
    public Entities.UserCategories.Client? Client { get; set; }
    public Entities.Bank? Bank { get; set; }
    public int? IdOfDepositToWithdraw { get; set; }
}