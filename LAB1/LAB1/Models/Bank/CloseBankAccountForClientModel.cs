namespace LAB1.Models.Bank;

public class CloseBankAccountForClientModel
{
    public Entities.UserCategories.Client? Client { get; set; }
    public Entities.Bank? Bank { get; set; }

    public int? IdOfBankAccountToClose { get; set; }
}