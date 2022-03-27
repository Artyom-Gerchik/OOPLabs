using System.ComponentModel.DataAnnotations;
using LAB1.Entities.UserCategories;

namespace LAB1.Entities.AdminRollBack;

public class RollBackDeletedInstallmentPlan
{
    public RollBackDeletedInstallmentPlan()
    {
    }

    public RollBackDeletedInstallmentPlan(Client client, InstallmentPlan installmentPlan, Transfer transfer)
    {
        Client = client;
        InstallmentPlan = installmentPlan;
        Transfer = transfer;
    }

    [Key] public int? Id { get; set; }
    public Client? Client { get; set; }
    public InstallmentPlan? InstallmentPlan { get; set; }

    public Transfer? Transfer { get; set; }
}