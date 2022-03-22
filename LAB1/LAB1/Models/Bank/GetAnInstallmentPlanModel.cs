using System.ComponentModel.DataAnnotations;

namespace LAB1.Models.Bank;

public class GetAnInstallmentPlanModel
{
    public int? DurationInMonths { get; set; }
    public double? AmountOfMoney { get; set; }
    public List<Entities.UserCategories.Manager>? Managers { get; set; }
    public int? IdOfSelectedManager { get; set; }
    public Entities.UserCategories.Client? Client { get; set; }
}