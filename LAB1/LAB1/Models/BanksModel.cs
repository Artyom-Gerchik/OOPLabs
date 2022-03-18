using LAB1.Entities;

namespace LAB1.Models;

public class BanksModel
{
    public List<Entities.Bank>? Banks { get; set; }
    public string? SelectedBankId { get; set; }
}