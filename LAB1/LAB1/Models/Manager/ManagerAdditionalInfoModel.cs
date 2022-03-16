using LAB1.Entities;

namespace LAB1.Models.Manager;

public class ManagerAdditionalInfoModel
{
    public List<Bank>? Banks { get; set; }
    public int? SelectedBankId { get; set; }
}