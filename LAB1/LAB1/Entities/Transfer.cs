using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LAB1.Entities;

public class Transfer
{
    [Key] public double? Id { get; set; }
    public double? AmountOfMoney { get; set; }
}