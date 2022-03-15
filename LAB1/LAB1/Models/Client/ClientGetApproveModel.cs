using LAB1.Entities.UserCategories;

namespace LAB1.Models.Client;

public class ClientGetApproveModel
{
    public List<Entities.UserCategories.Manager>? Managers { get; set; }
    public int? IdOfSelectedManager { get; set; }
}