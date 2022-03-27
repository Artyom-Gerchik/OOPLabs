using System.ComponentModel.DataAnnotations;

namespace LAB1.Models.Bank;

public class MoveMoneyBetweenBankAccountModel : IValidatableObject
{
    public Entities.UserCategories.Client? Client { get; set; }
    public Entities.Bank? Bank { get; set; }

    [Required] public int? IdOfBankAccountToWithdraw { get; set; }

    [Required] public int? IdOfBankAccountToDeposit { get; set; }

    [Required] public double? AmountOfMoney { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var errors = new List<ValidationResult>();

        return errors;
    }
}