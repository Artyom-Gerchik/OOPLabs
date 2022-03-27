using System.ComponentModel.DataAnnotations;

namespace LAB1.Entities;

public class Transfer
{
    [Key] public double? Id { get; set; }
    public double? AmountOfMoney { get; set; }
}