namespace LAB1.Models.Administrator;

public class AdministratorGetAdditionalInfoModel
{
    public List<Entities.Bank>? Banks { get; set; }
    public int? SelectedBankId { get; set; }
}