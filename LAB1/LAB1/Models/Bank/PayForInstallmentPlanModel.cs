namespace LAB1.Models.Bank;

public class PayForInstallmentPlanModel
{
    public Entities.UserCategories.Client? Client { get; set; }
    public Entities.Bank? Bank { get; set; }
    public int? IdOfInstallmentPlanToPay { get; set; }
}