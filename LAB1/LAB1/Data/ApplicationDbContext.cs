using LAB1.Entities;
using LAB1.Entities.UserCategories;
using LAB1.Models;
using LAB1.Models.Manager;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LAB1.Data;

public sealed class ApplicationDbContext : IdentityDbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Operator> Operators { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<Bank> Banks { get; set; }

    public DbSet<BankApproves> Approves { get; set; }

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
        Role foreignClientRole = new Role { Id = 4, Name = "foreignClient" };
        Role specialistRole = new Role { Id = 5, Name = "specialist" };
        Role managerRole = new Role { Id = 6, Name = "manager" };
        Role operatorRole = new Role { Id = 7, Name = "operator" };

        Bank firstBank = new Bank
        {
            Id = 1,
            Type = "OOO",
            LegalName = "firstBank",
            PayerAccountNumber = "123456789",
            BankIdentificationCode = "1234567890",
            LegalAddress = "Dzerzhinskogo District",
            AmountOfClients = 0,
            AmountOfOperators = 0,
            AmountOfManagers = 0,
            AmountOfAdministrators = 0,
            AmountOfMoney = 100500,
            OpennedBankAccounts = new List<BankAccount> { }
        };


        modelBuilder.Entity<Role>().HasData(administratorRole, userRole, clientRole, foreignClientRole, specialistRole,
            managerRole, operatorRole);
        modelBuilder.Entity<Bank>().HasData(firstBank);
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<Client>().ToTable("Clients");
        modelBuilder.Entity<Operator>().ToTable("Operators");
        modelBuilder.Entity<Manager>().ToTable("Managers");
        base.OnModelCreating(modelBuilder);
    }
}