namespace LAB1.Entities;

public class Bank : Company
{
    public int? AmountOfClients { get; set; }
    public int? AmountOfOperators { get; set; }
    public int? AmountOfManagers { get; set; }
    public int? AmountOfAdministrators { get; set; }
    public double? AmountOfMoney { get; set; }
    public List<BankAccount>? OpennedBankAccounts { get; set; }
    
    public List<BankDeposit>? OpennedBankDeposits { get; set; }

    
}