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
    public DbSet<Administrator> Administrators { get; set; }
    public DbSet<Specialist> Specialists { get; set; }

    public DbSet<Bank> Banks { get; set; }

    //public DbSet<BankApproves> Approves { get; set; }
    public DbSet<Company> Companies { get; set; }

    public DbSet<Transfer> Transfers { get; set; }
    //public DbSet<RollBackTransferBetweenBankAccounts> RollBackTransferBetweenBankAccounts { get; set; }

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
            Type = "OAO",
            LegalName = "firstBank",
            PayerAccountNumber = "111111111",
            BankIdentificationCode = "1111111111",
            LegalAddress = "Dzerzhinskogo District 1",
            IsItBank = true,
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
            PayerAccountNumber = "222222222",
            BankIdentificationCode = "2222222222",
            LegalAddress = "Dzerzhinskogo District 2",
            IsItBank = true,
            AmountOfClients = 0,
            AmountOfOperators = 0,
            AmountOfManagers = 0,
            AmountOfAdministrators = 0,
            AmountOfMoney = 1005005,
            OpennedBankAccounts = new List<BankAccount>(),
            OpennedBankDeposits = new List<BankDeposit>(),
            OpennedInstallmentPlans = new List<InstallmentPlan>()
        };

        var thirdBank = new Bank
        {
            Id = 3,
            Type = "OAO",
            LegalName = "thirdBank",
            PayerAccountNumber = "333333333",
            BankIdentificationCode = "3333333333",
            LegalAddress = "Dzerzhinskogo District 3",
            IsItBank = true,
            AmountOfClients = 0,
            AmountOfOperators = 0,
            AmountOfManagers = 0,
            AmountOfAdministrators = 0,
            AmountOfMoney = 1005005,
            OpennedBankAccounts = new List<BankAccount>(),
            OpennedBankDeposits = new List<BankDeposit>(),
            OpennedInstallmentPlans = new List<InstallmentPlan>()
        };

        var firstCompany = new Company
        {
            Id = 4,
            Type = "OPG",
            LegalName = "Vagner Group",
            PayerAccountNumber = "123456789",
            BankIdentificationCode = firstBank.BankIdentificationCode,
            LegalAddress = "Palmyra",
            Workers = new List<Client>(),
            SalaryForWorkers = 100000,
            IsItBank = false,
            Specialists = new List<Specialist>()
        };

        var secondCompany = new Company
        {
            Id = 5,
            Type = "OPG",
            LegalName = "Slavic Union",
            PayerAccountNumber = "123456788",
            BankIdentificationCode = firstBank.BankIdentificationCode,
            LegalAddress = "Sirya",
            Workers = new List<Client>(),
            SalaryForWorkers = 200000,
            IsItBank = false,
            Specialists = new List<Specialist>()
        };

        var thirdCompany = new Company
        {
            Id = 6,
            Type = "OPG",
            LegalName = "VDV",
            PayerAccountNumber = "123456787",
            BankIdentificationCode = firstBank.BankIdentificationCode,
            LegalAddress = "Burdj-Halif",
            Workers = new List<Client>(),
            SalaryForWorkers = 300000,
            IsItBank = false,
            Specialists = new List<Specialist>()
        };

        var fourthCompany = new Company
        {
            Id = 7,
            Type = "OPG",
            LegalName = "CCO",
            PayerAccountNumber = "123456786",
            BankIdentificationCode = firstBank.BankIdentificationCode,
            LegalAddress = "Grozniy",
            Workers = new List<Client>(),
            SalaryForWorkers = 400000,
            IsItBank = false,
            Specialists = new List<Specialist>()
        };

        var fifthCompany = new Company
        {
            Id = 8,
            Type = "OPG",
            LegalName = "SAS",
            PayerAccountNumber = "123456785",
            BankIdentificationCode = secondBank.BankIdentificationCode,
            LegalAddress = "London",
            Workers = new List<Client>(),
            SalaryForWorkers = 500000,
            IsItBank = false,
            Specialists = new List<Specialist>()
        };

        var sixthCompany = new Company
        {
            Id = 9,
            Type = "OPG",
            LegalName = "GIGN",
            PayerAccountNumber = "123456784",
            BankIdentificationCode = secondBank.BankIdentificationCode,
            LegalAddress = "Paris",
            Workers = new List<Client>(),
            SalaryForWorkers = 600000,
            IsItBank = false,
            Specialists = new List<Specialist>()
        };

        var seventhCompany = new Company
        {
            Id = 10,
            Type = "OPG",
            LegalName = "KSK",
            PayerAccountNumber = "123456783",
            BankIdentificationCode = secondBank.BankIdentificationCode,
            LegalAddress = "Berlin",
            Workers = new List<Client>(),
            SalaryForWorkers = 700000,
            IsItBank = false,
            Specialists = new List<Specialist>()
        };

        var eighthCompany = new Company
        {
            Id = 11,
            Type = "OPG",
            LegalName = "GROM",
            PayerAccountNumber = "123456782",
            BankIdentificationCode = thirdBank.BankIdentificationCode,
            LegalAddress = "Poznan",
            Workers = new List<Client>(),
            SalaryForWorkers = 800000,
            IsItBank = false,
            Specialists = new List<Specialist>()
        };

        var ninthCompany = new Company
        {
            Id = 12,
            Type = "OPG",
            LegalName = "FSKN",
            PayerAccountNumber = "123456781",
            BankIdentificationCode = thirdBank.BankIdentificationCode,
            LegalAddress = "St-Petersburg",
            Workers = new List<Client>(),
            SalaryForWorkers = 900000,
            IsItBank = false,
            Specialists = new List<Specialist>()
        };

        var tenthCompany = new Company
        {
            Id = 13,
            Type = "OPG",
            LegalName = "FSB",
            PayerAccountNumber = "123456780",
            BankIdentificationCode = thirdBank.BankIdentificationCode,
            LegalAddress = "Moscow",
            Workers = new List<Client>(),
            SalaryForWorkers = 1000000,
            IsItBank = false,
            Specialists = new List<Specialist>()
        };

        var banks = new List<Bank>();
        banks.Add(firstBank);
        banks.Add(secondBank);
        banks.Add(thirdBank);

        var companies = new List<Company>();
        companies.Add(firstCompany);
        companies.Add(secondCompany);
        companies.Add(thirdCompany);
        companies.Add(fourthCompany);
        companies.Add(fifthCompany);
        companies.Add(sixthCompany);
        companies.Add(seventhCompany);
        companies.Add(eighthCompany);
        companies.Add(ninthCompany);
        companies.Add(tenthCompany);


        modelBuilder.Entity<Role>().HasData(administratorRole, userRole, clientRole, foreignClientRole, specialistRole,
            managerRole, operatorRole);
        modelBuilder.Entity<Bank>().ToTable("Banks").HasData(banks);
        modelBuilder.Entity<Company>().ToTable("Companies").HasData(companies);
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<Client>().ToTable("Clients");
        modelBuilder.Entity<Operator>().ToTable("Operators");
        modelBuilder.Entity<Manager>().ToTable("Managers");
        modelBuilder.Entity<Specialist>().ToTable("Specialists");
        modelBuilder.Entity<Administrator>().ToTable("Administrators");
        base.OnModelCreating(modelBuilder);
    }
}