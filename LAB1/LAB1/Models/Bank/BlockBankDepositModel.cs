namespace LAB1.Models.Bank;

public class BlockBankDepositModel
{
    public Entities.UserCategories.Client? Client { get; set; }
    public Entities.Bank? Bank { get; set; }
    public int? IdOfDepositToBlock { get; set; }
}