using System.ComponentModel.DataAnnotations;
using LAB1.Entities.UserCategories;

namespace LAB1.Entities;

public class Role
{
    [Key] public int? Id { get; set; }
    public string? Name { get; set; }
}