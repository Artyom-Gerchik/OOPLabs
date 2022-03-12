using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace LAB1.Entities.UserCategories;

public class User
{
    [Key] public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Patronymic { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Password { get; set; }
    public int? RoleId { get; set; }
    public Role? Role { get; set; }
}