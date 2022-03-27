using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class ClearOne : Migration
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
                name: "Transfers",
                columns: table => new
                {
                    Id = table.Column<double>(type: "REAL", nullable: false),
                    AmountOfMoney = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.Id);
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
                name: "Administrators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BankId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrators_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    WorkId = table.Column<int>(type: "INTEGER", nullable: true),
                    AtSalaryProject = table.Column<bool>(type: "INTEGER", nullable: true),
                    ManagerId = table.Column<int>(type: "INTEGER", nullable: true),
                    ManagerId1 = table.Column<int>(type: "INTEGER", nullable: true),
                    ManagerId2 = table.Column<int>(type: "INTEGER", nullable: true),
                    OperatorId = table.Column<int>(type: "INTEGER", nullable: true),
                    SpecialistId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Companies_WorkId",
                        column: x => x.WorkId,
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
                        name: "FK_Clients_Operators_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Operators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clients_Specialists_SpecialistId",
                        column: x => x.SpecialistId,
                        principalTable: "Specialists",
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
                name: "SpecialistAddedMoney",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    ManagerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialistAddedMoney", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialistAddedMoney_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialistAddedMoney_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SpecialistSendClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    ManagerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialistSendClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialistSendClients_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialistSendClients_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
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
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    IsASalaryProjectAccount = table.Column<bool>(type: "INTEGER", nullable: true),
                    Hidden = table.Column<bool>(type: "INTEGER", nullable: true)
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
                name: "BankApproves",
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
                    table.PrimaryKey("PK_BankApproves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankApproves_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BankApproves_Clients_ClientId",
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
                    Percent = table.Column<double>(type: "REAL", nullable: true),
                    Hidden = table.Column<bool>(type: "INTEGER", nullable: true),
                    Blocked = table.Column<bool>(type: "INTEGER", nullable: true),
                    Frozen = table.Column<bool>(type: "INTEGER", nullable: true)
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
                    HowMuchLasts = table.Column<int>(type: "INTEGER", nullable: true),
                    Hidden = table.Column<bool>(type: "INTEGER", nullable: true)
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
                    HowMuchLasts = table.Column<int>(type: "INTEGER", nullable: true),
                    Hidden = table.Column<bool>(type: "INTEGER", nullable: true)
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
                name: "DeletedBankAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true),
                    BankAccountId = table.Column<int>(type: "INTEGER", nullable: true),
                    AdministratorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeletedBankAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeletedBankAccount_Administrators_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeletedBankAccount_BankAccount_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeletedBankAccount_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OpennedBankAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true),
                    BankAccountId = table.Column<int>(type: "INTEGER", nullable: true),
                    AdministratorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpennedBankAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpennedBankAccount_Administrators_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OpennedBankAccount_BankAccount_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OpennedBankAccount_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RollBackTransferBetweenBankAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BankAccountWhereWithdrawedId = table.Column<int>(type: "INTEGER", nullable: true),
                    BankAccountToDepositedId = table.Column<int>(type: "INTEGER", nullable: true),
                    TransferId = table.Column<double>(type: "REAL", nullable: true),
                    AdministratorId = table.Column<int>(type: "INTEGER", nullable: true),
                    OperatorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RollBackTransferBetweenBankAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RollBackTransferBetweenBankAccounts_Administrators_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackTransferBetweenBankAccounts_BankAccount_BankAccountToDepositedId",
                        column: x => x.BankAccountToDepositedId,
                        principalTable: "BankAccount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackTransferBetweenBankAccounts_BankAccount_BankAccountWhereWithdrawedId",
                        column: x => x.BankAccountWhereWithdrawedId,
                        principalTable: "BankAccount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackTransferBetweenBankAccounts_Operators_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Operators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackTransferBetweenBankAccounts_Transfers_TransferId",
                        column: x => x.TransferId,
                        principalTable: "Transfers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RollBackClosedDeposit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true),
                    BankDepositId = table.Column<int>(type: "INTEGER", nullable: true),
                    AdministratorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RollBackClosedDeposit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RollBackClosedDeposit_Administrators_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackClosedDeposit_BankDeposit_BankDepositId",
                        column: x => x.BankDepositId,
                        principalTable: "BankDeposit",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackClosedDeposit_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RollBackOpenedDeposit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true),
                    BankDepositId = table.Column<int>(type: "INTEGER", nullable: true),
                    AdministratorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RollBackOpenedDeposit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RollBackOpenedDeposit_Administrators_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackOpenedDeposit_BankDeposit_BankDepositId",
                        column: x => x.BankDepositId,
                        principalTable: "BankDeposit",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackOpenedDeposit_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RollBackTransferBetweenBankDeposits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BankDepositWhereWithdrawedId = table.Column<int>(type: "INTEGER", nullable: true),
                    BankDepositToDepositedId = table.Column<int>(type: "INTEGER", nullable: true),
                    TransferId = table.Column<double>(type: "REAL", nullable: true),
                    AdministratorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RollBackTransferBetweenBankDeposits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RollBackTransferBetweenBankDeposits_Administrators_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackTransferBetweenBankDeposits_BankDeposit_BankDepositToDepositedId",
                        column: x => x.BankDepositToDepositedId,
                        principalTable: "BankDeposit",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackTransferBetweenBankDeposits_BankDeposit_BankDepositWhereWithdrawedId",
                        column: x => x.BankDepositWhereWithdrawedId,
                        principalTable: "BankDeposit",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackTransferBetweenBankDeposits_Transfers_TransferId",
                        column: x => x.TransferId,
                        principalTable: "Transfers",
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
                name: "RollBackDeletedCredit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreditId = table.Column<int>(type: "INTEGER", nullable: true),
                    TransferId = table.Column<double>(type: "REAL", nullable: true),
                    AdministratorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RollBackDeletedCredit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RollBackDeletedCredit_Administrators_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackDeletedCredit_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackDeletedCredit_Credit_CreditId",
                        column: x => x.CreditId,
                        principalTable: "Credit",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackDeletedCredit_Transfers_TransferId",
                        column: x => x.TransferId,
                        principalTable: "Transfers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RollBackOpennedCredit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreditId = table.Column<int>(type: "INTEGER", nullable: true),
                    AdministratorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RollBackOpennedCredit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RollBackOpennedCredit_Administrators_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackOpennedCredit_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackOpennedCredit_Credit_CreditId",
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

            migrationBuilder.CreateTable(
                name: "RollBackDeletedInstallmentPlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true),
                    InstallmentPlanId = table.Column<int>(type: "INTEGER", nullable: true),
                    TransferId = table.Column<double>(type: "REAL", nullable: true),
                    AdministratorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RollBackDeletedInstallmentPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RollBackDeletedInstallmentPlan_Administrators_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackDeletedInstallmentPlan_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackDeletedInstallmentPlan_InstallmentPlan_InstallmentPlanId",
                        column: x => x.InstallmentPlanId,
                        principalTable: "InstallmentPlan",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackDeletedInstallmentPlan_Transfers_TransferId",
                        column: x => x.TransferId,
                        principalTable: "Transfers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RollBackOpennedInstallmentPlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true),
                    InstallmentPlanId = table.Column<int>(type: "INTEGER", nullable: true),
                    AdministratorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RollBackOpennedInstallmentPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RollBackOpennedInstallmentPlan_Administrators_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackOpennedInstallmentPlan_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackOpennedInstallmentPlan_InstallmentPlan_InstallmentPlanId",
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
                name: "IX_BankApproves_BankId",
                table: "BankApproves",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankApproves_ClientId",
                table: "BankApproves",
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
                name: "IX_Clients_OperatorId",
                table: "Clients",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_SpecialistId",
                table: "Clients",
                column: "SpecialistId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_WorkId",
                table: "Clients",
                column: "WorkId");

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
                name: "IX_DeletedBankAccount_AdministratorId",
                table: "DeletedBankAccount",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_DeletedBankAccount_BankAccountId",
                table: "DeletedBankAccount",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_DeletedBankAccount_ClientId",
                table: "DeletedBankAccount",
                column: "ClientId");

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
                name: "IX_OpennedBankAccount_AdministratorId",
                table: "OpennedBankAccount",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_OpennedBankAccount_BankAccountId",
                table: "OpennedBankAccount",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_OpennedBankAccount_ClientId",
                table: "OpennedBankAccount",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackClosedDeposit_AdministratorId",
                table: "RollBackClosedDeposit",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackClosedDeposit_BankDepositId",
                table: "RollBackClosedDeposit",
                column: "BankDepositId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackClosedDeposit_ClientId",
                table: "RollBackClosedDeposit",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackDeletedCredit_AdministratorId",
                table: "RollBackDeletedCredit",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackDeletedCredit_ClientId",
                table: "RollBackDeletedCredit",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackDeletedCredit_CreditId",
                table: "RollBackDeletedCredit",
                column: "CreditId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackDeletedCredit_TransferId",
                table: "RollBackDeletedCredit",
                column: "TransferId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackDeletedInstallmentPlan_AdministratorId",
                table: "RollBackDeletedInstallmentPlan",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackDeletedInstallmentPlan_ClientId",
                table: "RollBackDeletedInstallmentPlan",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackDeletedInstallmentPlan_InstallmentPlanId",
                table: "RollBackDeletedInstallmentPlan",
                column: "InstallmentPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackDeletedInstallmentPlan_TransferId",
                table: "RollBackDeletedInstallmentPlan",
                column: "TransferId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackOpenedDeposit_AdministratorId",
                table: "RollBackOpenedDeposit",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackOpenedDeposit_BankDepositId",
                table: "RollBackOpenedDeposit",
                column: "BankDepositId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackOpenedDeposit_ClientId",
                table: "RollBackOpenedDeposit",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackOpennedCredit_AdministratorId",
                table: "RollBackOpennedCredit",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackOpennedCredit_ClientId",
                table: "RollBackOpennedCredit",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackOpennedCredit_CreditId",
                table: "RollBackOpennedCredit",
                column: "CreditId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackOpennedInstallmentPlan_AdministratorId",
                table: "RollBackOpennedInstallmentPlan",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackOpennedInstallmentPlan_ClientId",
                table: "RollBackOpennedInstallmentPlan",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackOpennedInstallmentPlan_InstallmentPlanId",
                table: "RollBackOpennedInstallmentPlan",
                column: "InstallmentPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackTransferBetweenBankAccounts_AdministratorId",
                table: "RollBackTransferBetweenBankAccounts",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackTransferBetweenBankAccounts_BankAccountToDepositedId",
                table: "RollBackTransferBetweenBankAccounts",
                column: "BankAccountToDepositedId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackTransferBetweenBankAccounts_BankAccountWhereWithdrawedId",
                table: "RollBackTransferBetweenBankAccounts",
                column: "BankAccountWhereWithdrawedId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackTransferBetweenBankAccounts_OperatorId",
                table: "RollBackTransferBetweenBankAccounts",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackTransferBetweenBankAccounts_TransferId",
                table: "RollBackTransferBetweenBankAccounts",
                column: "TransferId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackTransferBetweenBankDeposits_AdministratorId",
                table: "RollBackTransferBetweenBankDeposits",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackTransferBetweenBankDeposits_BankDepositToDepositedId",
                table: "RollBackTransferBetweenBankDeposits",
                column: "BankDepositToDepositedId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackTransferBetweenBankDeposits_BankDepositWhereWithdrawedId",
                table: "RollBackTransferBetweenBankDeposits",
                column: "BankDepositWhereWithdrawedId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackTransferBetweenBankDeposits_TransferId",
                table: "RollBackTransferBetweenBankDeposits",
                column: "TransferId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialistAddedMoney_ClientId",
                table: "SpecialistAddedMoney",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialistAddedMoney_ManagerId",
                table: "SpecialistAddedMoney",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialists_CompanyId",
                table: "Specialists",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialistSendClients_ClientId",
                table: "SpecialistSendClients",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialistSendClients_ManagerId",
                table: "SpecialistSendClients",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "BankApproves");

            migrationBuilder.DropTable(
                name: "CreditsAndApproves");

            migrationBuilder.DropTable(
                name: "DeletedBankAccount");

            migrationBuilder.DropTable(
                name: "InstallmentPlanApproves");

            migrationBuilder.DropTable(
                name: "OpennedBankAccount");

            migrationBuilder.DropTable(
                name: "RollBackClosedDeposit");

            migrationBuilder.DropTable(
                name: "RollBackDeletedCredit");

            migrationBuilder.DropTable(
                name: "RollBackDeletedInstallmentPlan");

            migrationBuilder.DropTable(
                name: "RollBackOpenedDeposit");

            migrationBuilder.DropTable(
                name: "RollBackOpennedCredit");

            migrationBuilder.DropTable(
                name: "RollBackOpennedInstallmentPlan");

            migrationBuilder.DropTable(
                name: "RollBackTransferBetweenBankAccounts");

            migrationBuilder.DropTable(
                name: "RollBackTransferBetweenBankDeposits");

            migrationBuilder.DropTable(
                name: "SpecialistAddedMoney");

            migrationBuilder.DropTable(
                name: "SpecialistSendClients");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Credit");

            migrationBuilder.DropTable(
                name: "InstallmentPlan");

            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "BankDeposit");

            migrationBuilder.DropTable(
                name: "Transfers");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Specialists");

            migrationBuilder.DropTable(
                name: "Operators");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
