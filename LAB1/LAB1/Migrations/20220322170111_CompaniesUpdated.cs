using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class CompaniesUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    LegalName = table.Column<string>(type: "TEXT", nullable: true),
                    PayerAccountNumber = table.Column<string>(type: "TEXT", nullable: true),
                    BankIdentificationCode = table.Column<string>(type: "TEXT", nullable: true),
                    LegalAddress = table.Column<string>(type: "TEXT", nullable: true),
                    SalaryForWorkers = table.Column<double>(type: "REAL", nullable: true),
                    IsItBank = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Surname = table.Column<string>(type: "TEXT", nullable: true),
                    Patronymic = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Operators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BankId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operators_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specialists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specialists_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Specialists_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Managers_Operators_Id",
                        column: x => x.Id,
                        principalTable: "Operators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PassportNumberAndSeries = table.Column<string>(type: "TEXT", nullable: true),
                    IdentificationNumber = table.Column<string>(type: "TEXT", nullable: true),
                    CurrentBankId = table.Column<int>(type: "INTEGER", nullable: true),
                    BankBalance = table.Column<double>(type: "REAL", nullable: true),
                    Salary = table.Column<double>(type: "REAL", nullable: true),
                    CompanyId = table.Column<int>(type: "INTEGER", nullable: true),
                    ManagerId = table.Column<int>(type: "INTEGER", nullable: true),
                    ManagerId1 = table.Column<int>(type: "INTEGER", nullable: true),
                    ManagerId2 = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clients_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clients_Managers_ManagerId1",
                        column: x => x.ManagerId1,
                        principalTable: "Managers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clients_Managers_ManagerId2",
                        column: x => x.ManagerId2,
                        principalTable: "Managers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clients_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AmountOfClients = table.Column<int>(type: "INTEGER", nullable: true),
                    AmountOfOperators = table.Column<int>(type: "INTEGER", nullable: true),
                    AmountOfManagers = table.Column<int>(type: "INTEGER", nullable: true),
                    AmountOfAdministrators = table.Column<int>(type: "INTEGER", nullable: true),
                    AmountOfMoney = table.Column<double>(type: "REAL", nullable: true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Banks_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Banks_Companies_Id",
                        column: x => x.Id,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Approves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BankId = table.Column<int>(type: "INTEGER", nullable: true),
                    Approved = table.Column<bool>(type: "INTEGER", nullable: true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Approves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Approves_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Approves_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true),
                    BankId = table.Column<int>(type: "INTEGER", nullable: true),
                    AmountOfMoney = table.Column<double>(type: "REAL", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccount_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BankAccount_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BankDeposit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateOfDeal = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DateOfMoneyBack = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HowMuchLasts = table.Column<int>(type: "INTEGER", nullable: true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true),
                    BankId = table.Column<int>(type: "INTEGER", nullable: true),
                    AmountOfMoney = table.Column<double>(type: "REAL", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Percent = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDeposit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankDeposit_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BankDeposit_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Credit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BankId = table.Column<int>(type: "INTEGER", nullable: true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true),
                    DurationInMonths = table.Column<int>(type: "INTEGER", nullable: true),
                    Percent = table.Column<double>(type: "REAL", nullable: true),
                    AmountOfMoney = table.Column<double>(type: "REAL", nullable: true),
                    DateOfDeal = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateToPay = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HowMuchLasts = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Credit_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InstallmentPlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BankId = table.Column<int>(type: "INTEGER", nullable: true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true),
                    DurationInMonths = table.Column<int>(type: "INTEGER", nullable: true),
                    AmountOfMoney = table.Column<double>(type: "REAL", nullable: true),
                    DateOfDeal = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateToPay = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HowMuchLasts = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstallmentPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstallmentPlan_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CreditsAndApproves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BankId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreditId = table.Column<int>(type: "INTEGER", nullable: true),
                    Approved = table.Column<bool>(type: "INTEGER", nullable: true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditsAndApproves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditsAndApproves_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CreditsAndApproves_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CreditsAndApproves_Credit_CreditId",
                        column: x => x.CreditId,
                        principalTable: "Credit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InstallmentPlanApproves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BankId = table.Column<int>(type: "INTEGER", nullable: true),
                    InstallmentPlanId = table.Column<int>(type: "INTEGER", nullable: true),
                    Approved = table.Column<bool>(type: "INTEGER", nullable: true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstallmentPlanApproves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstallmentPlanApproves_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstallmentPlanApproves_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstallmentPlanApproves_InstallmentPlan_InstallmentPlanId",
                        column: x => x.InstallmentPlanId,
                        principalTable: "InstallmentPlan",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "BankIdentificationCode", "IsItBank", "LegalAddress", "LegalName", "PayerAccountNumber", "SalaryForWorkers", "Type" },
                values: new object[] { 1, "1111111111", true, "Dzerzhinskogo District 1", "firstBank", "111111111", null, "OAO" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "BankIdentificationCode", "IsItBank", "LegalAddress", "LegalName", "PayerAccountNumber", "SalaryForWorkers", "Type" },
                values: new object[] { 2, "2222222222", true, "Dzerzhinskogo District 2", "secondBank", "222222222", null, "OAO" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "BankIdentificationCode", "IsItBank", "LegalAddress", "LegalName", "PayerAccountNumber", "SalaryForWorkers", "Type" },
                values: new object[] { 3, "3333333333", true, "Dzerzhinskogo District 3", "thirdBank", "333333333", null, "OAO" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "BankIdentificationCode", "IsItBank", "LegalAddress", "LegalName", "PayerAccountNumber", "SalaryForWorkers", "Type" },
                values: new object[] { 4, "1111111111", false, "Palmyra", "Vagner Group", "123456789", 100000.0, "OPG" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "BankIdentificationCode", "IsItBank", "LegalAddress", "LegalName", "PayerAccountNumber", "SalaryForWorkers", "Type" },
                values: new object[] { 5, "1111111111", false, "Sirya", "Slavic Union", "123456788", 200000.0, "OPG" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "BankIdentificationCode", "IsItBank", "LegalAddress", "LegalName", "PayerAccountNumber", "SalaryForWorkers", "Type" },
                values: new object[] { 6, "1111111111", false, "Burdj-Halif", "VDV", "123456787", 300000.0, "OPG" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "BankIdentificationCode", "IsItBank", "LegalAddress", "LegalName", "PayerAccountNumber", "SalaryForWorkers", "Type" },
                values: new object[] { 7, "1111111111", false, "Grozniy", "CCO", "123456786", 400000.0, "OPG" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "BankIdentificationCode", "IsItBank", "LegalAddress", "LegalName", "PayerAccountNumber", "SalaryForWorkers", "Type" },
                values: new object[] { 8, "2222222222", false, "London", "SAS", "123456785", 500000.0, "OPG" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "BankIdentificationCode", "IsItBank", "LegalAddress", "LegalName", "PayerAccountNumber", "SalaryForWorkers", "Type" },
                values: new object[] { 9, "2222222222", false, "Paris", "GIGN", "123456784", 600000.0, "OPG" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "BankIdentificationCode", "IsItBank", "LegalAddress", "LegalName", "PayerAccountNumber", "SalaryForWorkers", "Type" },
                values: new object[] { 10, "2222222222", false, "Berlin", "KSK", "123456783", 700000.0, "OPG" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "BankIdentificationCode", "IsItBank", "LegalAddress", "LegalName", "PayerAccountNumber", "SalaryForWorkers", "Type" },
                values: new object[] { 11, "3333333333", false, "Poznan", "GROM", "123456782", 800000.0, "OPG" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "BankIdentificationCode", "IsItBank", "LegalAddress", "LegalName", "PayerAccountNumber", "SalaryForWorkers", "Type" },
                values: new object[] { 12, "3333333333", false, "St-Petersburg", "FSKN", "123456781", 900000.0, "OPG" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "BankIdentificationCode", "IsItBank", "LegalAddress", "LegalName", "PayerAccountNumber", "SalaryForWorkers", "Type" },
                values: new object[] { 13, "3333333333", false, "Moscow", "FSB", "123456780", 1000000.0, "OPG" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "administrator" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "user" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "client" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "foreignClient" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "specialist" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "manager" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "operator" });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "AmountOfAdministrators", "AmountOfClients", "AmountOfManagers", "AmountOfMoney", "AmountOfOperators", "ClientId" },
                values: new object[] { 1, 0, 0, 0, 100500.0, 0, null });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "AmountOfAdministrators", "AmountOfClients", "AmountOfManagers", "AmountOfMoney", "AmountOfOperators", "ClientId" },
                values: new object[] { 2, 0, 0, 0, 1005005.0, 0, null });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "AmountOfAdministrators", "AmountOfClients", "AmountOfManagers", "AmountOfMoney", "AmountOfOperators", "ClientId" },
                values: new object[] { 3, 0, 0, 0, 1005005.0, 0, null });

            migrationBuilder.CreateIndex(
                name: "IX_Approves_BankId",
                table: "Approves",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Approves_ClientId",
                table: "Approves",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_BankId",
                table: "BankAccount",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_ClientId",
                table: "BankAccount",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_BankDeposit_BankId",
                table: "BankDeposit",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankDeposit_ClientId",
                table: "BankDeposit",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Banks_ClientId",
                table: "Banks",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CompanyId",
                table: "Clients",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ManagerId",
                table: "Clients",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ManagerId1",
                table: "Clients",
                column: "ManagerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ManagerId2",
                table: "Clients",
                column: "ManagerId2");

            migrationBuilder.CreateIndex(
                name: "IX_Credit_BankId",
                table: "Credit",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditsAndApproves_BankId",
                table: "CreditsAndApproves",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditsAndApproves_ClientId",
                table: "CreditsAndApproves",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditsAndApproves_CreditId",
                table: "CreditsAndApproves",
                column: "CreditId");

            migrationBuilder.CreateIndex(
                name: "IX_InstallmentPlan_BankId",
                table: "InstallmentPlan",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_InstallmentPlanApproves_BankId",
                table: "InstallmentPlanApproves",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_InstallmentPlanApproves_ClientId",
                table: "InstallmentPlanApproves",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_InstallmentPlanApproves_InstallmentPlanId",
                table: "InstallmentPlanApproves",
                column: "InstallmentPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialists_CompanyId",
                table: "Specialists",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Approves");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.DropTable(
                name: "BankDeposit");

            migrationBuilder.DropTable(
                name: "CreditsAndApproves");

            migrationBuilder.DropTable(
                name: "InstallmentPlanApproves");

            migrationBuilder.DropTable(
                name: "Specialists");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Credit");

            migrationBuilder.DropTable(
                name: "InstallmentPlan");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Operators");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
