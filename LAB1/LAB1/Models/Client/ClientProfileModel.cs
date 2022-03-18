using LAB1.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LAB1.Models.Client;

public class ClientProfileModel
{
    public Entities.UserCategories.Client Client { get; set; }
    public int? SelectedBankId { get; set; }
    public List<Entities.Bank> BanksWhereApproved { get; set; }
    public List<Entities.Bank> Banks { get; set; }
}