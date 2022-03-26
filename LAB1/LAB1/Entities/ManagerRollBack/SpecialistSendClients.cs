using System.ComponentModel.DataAnnotations;
using LAB1.Entities.UserCategories;

namespace LAB1.Entities.ManagerRollBack;

public class SpecialistSendClients
{
    [Key] public int? Id { get; set; }

    public Client Client { get; set; }

    public SpecialistSendClients()
    {
    }

    public SpecialistSendClients(Client client)
    {
        Client = client;
    }
}