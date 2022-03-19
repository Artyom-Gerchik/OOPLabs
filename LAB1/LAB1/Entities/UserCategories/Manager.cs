using System.ComponentModel.DataAnnotations.Schema;

namespace LAB1.Entities.UserCategories;

[Table("Managers")]
//[Keyless]
public class Manager : Operator
{
    public List<Client> WaitingForRegistrationApprove { get; set; }
    //public List<int>? IdsOfClientsWaitingForRegistrationApprove { get; set; }
}