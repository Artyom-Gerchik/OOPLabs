namespace LAB1.Models.Bank;

public class SpeedRunInstallmentPlanModel
{
    public Entities.UserCategories.Client? Client { get; set; }
    public Entities.Bank? Bank { get; set; }
    public int? IdOfInstallmentPlanToSpeedRun { get; set; }
}