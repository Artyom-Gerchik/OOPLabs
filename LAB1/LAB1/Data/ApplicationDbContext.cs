using LAB1.Entities;
using LAB1.Entities.UserCategories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LAB1.Data;

public sealed class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Operator> Operators { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<Bank> Banks { get; set; }

    public DbSet<BankApproves> Approves { get; set; }

    public DbSet<Company> Companies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var administratorRole = new Role { Id = 1, Name = "administrator" };
        var userRole = new Role { Id = 2, Name = "user" };
        var clientRole = new Role { Id = 3, Name = "client" };
        var foreignClientRole = new Role { Id = 4, Name = "foreignClient" };
        var specialistRole = new Role { Id = 5, Name = "specialist" };
        var managerRole = new Role { Id = 6, Name = "manager" };
        var operatorRole = new Role { Id = 7, Name = "operator" };

        var firstBank = new Bank
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
            OpennedBankAccounts = new List<BankAccount>(),
            OpennedBankDeposits = new List<BankDeposit>(),
            OpennedInstallmentPlans = new List<InstallmentPlan>()
        };

        var secondBank = new Bank
        {
            Id = 2,
            Type = "OAO",
            LegalName = "secondBank",
            PayerAccountNumber = "123456787",
            BankIdentificationCode = "1234557890",
            LegalAddress = "Dzerzhinskogo District 88",
            AmountOfClients = 0,
            AmountOfOperators = 0,
            AmountOfManagers = 0,
            AmountOfAdministrators = 0,
            AmountOfMoney = 1005005,
            OpennedBankAccounts = new List<BankAccount>(),
            OpennedBankDeposits = new List<BankDeposit>(),
            OpennedInstallmentPlans = new List<InstallmentPlan>()
        };

        var firstCompany = new Company()
        {
            Id = 3,
            Type = "OPG",
            LegalName = "Vagner Group",
            PayerAccountNumber = firstBank.PayerAccountNumber,
            BankIdentificationCode = firstBank.BankIdentificationCode,
            LegalAddress = "Palmyra",
            Workers = new List<Client>(),
            SalaryForWorkers = 10000
        };
        
        modelBuilder.Entity<Role>().HasData(administratorRole, userRole, clientRole, foreignClientRole, specialistRole,
            managerRole, operatorRole);
        modelBuilder.Entity<Bank>().ToTable("Banks").HasData(firstBank, secondBank);
        modelBuilder.Entity<Company>().ToTable("Companies").HasData(firstCompany);
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<Client>().ToTable("Clients");
        modelBuilder.Entity<Operator>().ToTable("Operators");
        modelBuilder.Entity<Manager>().ToTable("Managers");
        base.OnModelCreating(modelBuilder);
    }
}