namespace LAB1.Models.Manager;

public class ManagerApproveModel
{
    public List<Entities.UserCategories.Client>? ClientsToApprove { get; set; }

    public int? IdOfApprovedClient { get; set; }
}