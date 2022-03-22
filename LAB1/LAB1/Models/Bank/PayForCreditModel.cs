namespace LAB1.Models.Bank;

public class PayForCreditModel
{
    public Entities.UserCategories.Client? Client { get; set; }
    public Entities.Bank? Bank { get; set; }
    public int? IdOfCreditToPay { get; set; }
}