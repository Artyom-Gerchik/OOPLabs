using System.ComponentModel.DataAnnotations;

namespace LAB1.Entities;

public class CreditsAndApproves
{
    public CreditsAndApproves()
    {
    }

    public CreditsAndApproves(Credit credit, bool approved)
    {
        Credit = credit;
        Approved = approved;
    }

    [Key] public int? Id { get; set; }
    public Bank? Bank { get; set; }
    public Credit? Credit { get; set; }
    public bool? Approved { get; set; }
}