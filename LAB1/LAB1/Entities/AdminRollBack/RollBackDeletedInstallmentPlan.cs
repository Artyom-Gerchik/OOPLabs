using System.ComponentModel.DataAnnotations;
using LAB1.Entities.UserCategories;

namespace LAB1.Entities.AdminRollBack;

public class RollBackDeletedInstallmentPlan
{
    [Key] public int? Id { get; set; }
    public Client? Client { get; set; }
    public InstallmentPlan? InstallmentPlan { get; set; }

    public Transfer? Transfer { get; set; }

    public RollBackDeletedInstallmentPlan()
    {
    }

    public RollBackDeletedInstallmentPlan(Client client, InstallmentPlan installmentPlan, Transfer transfer)
    {
        Client = client;
        InstallmentPlan = installmentPlan;
        Transfer = transfer;
    }
}