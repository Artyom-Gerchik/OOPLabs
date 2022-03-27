using LAB1.Entities;
using LAB1.Entities.UserCategories;

namespace LAB1.Models;

public class RoleModel
{
    public List<Role>? Roles { get; set; }
    public int? IdOfSelectedRole { get; set; }
    public User User { get; set; }
}