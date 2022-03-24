namespace LAB1.Models.Bank;

public class MoveMoneyBetweenBankDepositsModel
{
    public Entities.UserCategories.Client? Client { get; set; }
    public Entities.Bank? Bank { get; set; }
    public int? IdOfBankDepositToWithdraw { get; set; }

    public int? IdOfBankDepositToDeposit { get; set; }
    //public double? AmountOfMoney { get; set; }
}