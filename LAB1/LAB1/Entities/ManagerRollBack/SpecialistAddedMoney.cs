using System.ComponentModel.DataAnnotations;
using LAB1.Entities.UserCategories;

namespace LAB1.Entities.ManagerRollBack;

public class SpecialistAddedMoney
{
    public SpecialistAddedMoney()
    {
    }

    public SpecialistAddedMoney(Client client)
    {
        Client = client;
    }

    [Key] public int? Id { get; set; }
    public Client Client { get; set; }
}