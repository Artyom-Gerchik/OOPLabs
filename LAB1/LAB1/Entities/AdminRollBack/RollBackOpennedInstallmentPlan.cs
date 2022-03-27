using System.ComponentModel.DataAnnotations;
using LAB1.Entities.UserCategories;

namespace LAB1.Entities.AdminRollBack;

public class RollBackOpennedInstallmentPlan
{
    public RollBackOpennedInstallmentPlan()
    {
    }

    public RollBackOpennedInstallmentPlan(Client client, InstallmentPlan installmentPlan)
    {
        Client = client;
        InstallmentPlan = installmentPlan;
    }

    [Key] public int? Id { get; set; }
    public Client? Client { get; set; }
    public InstallmentPlan? InstallmentPlan { get; set; }
}