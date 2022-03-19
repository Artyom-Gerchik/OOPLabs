namespace LAB1.Models.Bank;

public class SpeedRunDepositModel
{
    public Entities.UserCategories.Client? Client { get; set; }
    public Entities.Bank? Bank { get; set; }
    public int? IdOfDepositToSpeedRun { get; set; }
}