using System.ComponentModel.DataAnnotations;

namespace LAB1.Entities.AdminRollBack;

public class RollBackTransferBetweenBankDeposits
{
    [Key] public int? Id { get; set; }
    public BankDeposit? BankDepositWhereWithdrawed { get; set; }
    public BankDeposit? BankDepositToDeposited { get; set; }
    public Transfer? Transfer { get; set; }

    public RollBackTransferBetweenBankDeposits()
    {
    }

    public RollBackTransferBetweenBankDeposits(BankDeposit bankDepositWhereWithdrawed,
        BankDeposit bankDepositToDeposited, Transfer transfer)
    {
        BankDepositWhereWithdrawed = bankDepositWhereWithdrawed;
        BankDepositToDeposited = bankDepositToDeposited;
        Transfer = transfer;
    }
}