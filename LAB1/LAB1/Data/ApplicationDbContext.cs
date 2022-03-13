using LAB1.Entities;
using LAB1.Entities.UserCategories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LAB1.Data;

public sealed class ApplicationDbContext : IdentityDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Bank> Banks { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Role administratorRole = new Role { Id = 1, Name = "administrator" };
        Role userRole = new Role { Id = 2, Name = "user" };
        Role clientRole = new Role { Id = 3, Name = "client" };
        Role specialistRole = new Role { Id = 4, Name = "specialist" };
        Role managerRole = new Role { Id = 5, Name = "manager" };
        Role operatorRole = new Role { Id = 6, Name = "operator" };

        modelBuilder.Entity<Role>().HasData(new Role[]
            { administratorRole, userRole, clientRole, specialistRole, managerRole, operatorRole });
        base.OnModelCreating(modelBuilder);
    }
}