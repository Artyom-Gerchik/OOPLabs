namespace LAB1.Models.Bank;

public class MoveMoneyBetweenBankAccountModel
{
    public Entities.UserCategories.Client? Client { get; set; }
    public Entities.Bank? Bank { get; set; }
    public int? IdOfBankAccountToWithdraw { get; set; }
    public int? IdOfBankAccountToDeposit { get; set; }
    public double? AmountOfMoney { get; set; }
}