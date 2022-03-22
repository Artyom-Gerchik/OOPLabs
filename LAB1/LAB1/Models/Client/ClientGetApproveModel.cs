namespace LAB1.Models.Client;

public class ClientGetApproveModel
{
    public List<Entities.Bank>? ClientBanks { get; set; }
    public List<Entities.UserCategories.Manager>? Managers { get; set; }
    public int? IdOfSelectedBank { get; set; }
}