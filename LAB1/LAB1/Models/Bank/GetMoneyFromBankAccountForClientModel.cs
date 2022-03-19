namespace LAB1.Models.Bank;

public class GetMoneyFromBankAccountForClientModel
{
    public Entities.UserCategories.Client? Client { get; set; }
    public Entities.Bank? Bank { get; set; }
    public int? IdOfBankAccountToWithdraw { get; set; }
    public double? AmountOfMoney { get; set; }
}