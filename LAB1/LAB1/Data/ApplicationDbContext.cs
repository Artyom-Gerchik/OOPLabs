using LAB1.Entities;
using LAB1.Entities.UserCategories;
using LAB1.Models;
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

    // TODO: add operators and managers

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

        // modelBuilder.Entity<User>().Map(m =>
        // {
        //     m.MapInheritedProperties();
        //     m.ToTable("Users");
        // });
        //
        // modelBuilder.Entity<Client>().Map(m =>
        // {
        //     m.MapInheritedProperties();
        //     m.ToTable("Clients");
        // });

        // modelBuilder.Entity<Manager>(b =>
        // {
        //     b.HasData(new
        //     {
        //         Id = 5,
        //         Name = "Super",
        //         Surname = "Mega",
        //         Patronymic = "Manager",
        //         Email = "superManager@gmail.com",
        //         PhoneNumber = "+375441234566",
        //         Password = "123456",
        //     });
        //
        //     b.OwnsOne(e => e.WaitingForRegistrationApprove).HasData(new
        //     {
        //         RoleId = 6,
        //         Role = managerRole,
        //         WaitingForRegistrationApprove = new List<Client>(),
        //         BankId = 1
        //     });
        // });

        // Manager firstManager = new Manager
        // {
        //     Id = 5,
        //     Name = "Super",
        //     Surname = "Mega",
        //     Patronymic = "Manager",
        //     Email = "superManager@gmail.com",
        //     PhoneNumber = "+375441234566",
        //     Password = "123456",
        //     RoleId = 6,
        //     Role = managerRole,
        //     WaitingForRegistrationApprove = new List<Client>(),
        //     BankId = 1
        // };

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