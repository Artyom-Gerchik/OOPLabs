using System.ComponentModel.DataAnnotations;

namespace LAB1.Entities.AdminRollBack
{
    public class RollBackTransferBetweenBankAccounts
    {
        [Key]
        public int? Id { get; set; }
        public BankAccount? BankAccountWhereWithdrawed { get; set; }
        public BankAccount? BankAccountToDeposited { get; set; }
        public Transfer? Transfer { get; set; }

        public RollBackTransferBetweenBankAccounts()
        {
        }

        public RollBackTransferBetweenBankAccounts(BankAccount bankAccountWhereWithdrawed, BankAccount bankAccountToDeposited,
            Transfer transfer)
        {
            BankAccountWhereWithdrawed = bankAccountWhereWithdrawed;
            BankAccountToDeposited = bankAccountToDeposited;
            Transfer = transfer;
        }
    }
}