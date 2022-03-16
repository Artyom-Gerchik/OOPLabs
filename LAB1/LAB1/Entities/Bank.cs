using System.ComponentModel.DataAnnotations.Schema;
using LAB1.Entities.UserCategories;

namespace LAB1.Entities;

public class Bank : Company
{
    public int? AmountOfClients { get; set; }
    public int? AmountOfOperators { get; set; }
    public int? AmountOfManagers { get; set; }
    public int? AmountOfAdministrators { get; set; }
    public double? AmountOfMoney { get; set; }

    [NotMapped] public List<int>? IdsOfClients { get; set; }

    //public List<Client>? Clients { get; set; }
    public List<BankAccount>? OpennedBankAccounts { get; set; }
}