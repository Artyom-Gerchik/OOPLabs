namespace LAB1.Models.Bank;

public class SpeedRunCreditModel
{
    public Entities.UserCategories.Client? Client { get; set; }
    public Entities.Bank? Bank { get; set; }
    public int? IdOfCreditToSpeedRun { get; set; }
}