using System.ComponentModel.DataAnnotations;

namespace LAB1.Entities;

public class InstallmentPlanApproves
{
    public InstallmentPlanApproves()
    {
    }

    public InstallmentPlanApproves(InstallmentPlan installmentPlan, bool approved)
    {
        InstallmentPlan = installmentPlan;
        Approved = approved;
    }

    [Key] public int? Id { get; set; }
    public Bank? Bank { get; set; }
    public InstallmentPlan? InstallmentPlan { get; set; }
    public bool? Approved { get; set; }
}