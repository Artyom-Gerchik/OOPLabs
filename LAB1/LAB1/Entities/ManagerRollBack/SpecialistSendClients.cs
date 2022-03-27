using System.ComponentModel.DataAnnotations;
using LAB1.Entities.UserCategories;

namespace LAB1.Entities.ManagerRollBack;

public class SpecialistSendClients
{
    public SpecialistSendClients()
    {
    }

    public SpecialistSendClients(Client client)
    {
        Client = client;
    }

    [Key] public int? Id { get; set; }

    public Client Client { get; set; }
}