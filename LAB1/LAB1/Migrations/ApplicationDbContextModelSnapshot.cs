﻿// <auto-generated />
using System;
using LAB1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LAB1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("LAB1.Entities.BankAccount", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double?>("AmountOfMoney")
                        .HasColumnType("REAL");

                    b.Property<int?>("BankId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("ClientId");

                    b.ToTable("BankAccount");
                });

            modelBuilder.Entity("LAB1.Entities.BankApproves", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("Approved")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BankId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClientId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("ClientId");

                    b.ToTable("Approves");
                });

            modelBuilder.Entity("LAB1.Entities.BankDeposit", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double?>("AmountOfMoney")
                        .HasColumnType("REAL");

                    b.Property<int?>("BankId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DateOfDeal")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfMoneyBack")
                        .HasColumnType("TEXT");

                    b.Property<int?>("HowMuchLasts")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double?>("Percent")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("ClientId");

                    b.ToTable("BankDeposit");
                });

            modelBuilder.Entity("LAB1.Entities.Company", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BankIdentificationCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LegalAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("LegalName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PayerAccountNumber")
                        .HasColumnType("TEXT");

                    b.Property<double?>("SalaryForWorkers")
                        .HasColumnType("REAL");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Company");
                });

            modelBuilder.Entity("LAB1.Entities.Credit", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double?>("AmountOfMoney")
                        .HasColumnType("REAL");

                    b.Property<int?>("BankId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfDeal")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateToPay")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DurationInMonths")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("HowMuchLasts")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Percent")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.ToTable("Credit");
                });

            modelBuilder.Entity("LAB1.Entities.CreditsAndApproves", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("Approved")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BankId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CreditId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("ClientId");

                    b.HasIndex("CreditId");

                    b.ToTable("CreditsAndApproves");
                });

            modelBuilder.Entity("LAB1.Entities.InstallmentPlan", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double?>("AmountOfMoney")
                        .HasColumnType("REAL");

                    b.Property<int?>("BankId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfDeal")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateToPay")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DurationInMonths")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("HowMuchLasts")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.ToTable("InstallmentPlan");
                });

            modelBuilder.Entity("LAB1.Entities.InstallmentPlanApproves", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("Approved")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BankId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("InstallmentPlanId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("ClientId");

                    b.HasIndex("InstallmentPlanId");

                    b.ToTable("InstallmentPlanApproves");
                });

            modelBuilder.Entity("LAB1.Entities.Role", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "administrator"
                        },
                        new
                        {
                            Id = 2,
                            Name = "user"
                        },
                        new
                        {
                            Id = 3,
                            Name = "client"
                        },
                        new
                        {
                            Id = 4,
                            Name = "foreignClient"
                        },
                        new
                        {
                            Id = 5,
                            Name = "specialist"
                        },
                        new
                        {
                            Id = 6,
                            Name = "manager"
                        },
                        new
                        {
                            Id = 7,
                            Name = "operator"
                        });
                });

            modelBuilder.Entity("LAB1.Entities.UserCategories.User", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Patronymic")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RoleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("LAB1.Entities.Bank", b =>
                {
                    b.HasBaseType("LAB1.Entities.Company");

                    b.Property<int?>("AmountOfAdministrators")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AmountOfClients")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AmountOfManagers")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("AmountOfMoney")
                        .HasColumnType("REAL");

                    b.Property<int?>("AmountOfOperators")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClientId")
                        .HasColumnType("INTEGER");

                    b.HasIndex("ClientId");

                    b.ToTable("Companies");

                    b.HasDiscriminator().HasValue("Bank");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BankIdentificationCode = "1234567890",
                            LegalAddress = "Dzerzhinskogo District",
                            LegalName = "firstBank",
                            PayerAccountNumber = "123456789",
                            Type = "OOO",
                            AmountOfAdministrators = 0,
                            AmountOfClients = 0,
                            AmountOfManagers = 0,
                            AmountOfMoney = 100500.0,
                            AmountOfOperators = 0
                        },
                        new
                        {
                            Id = 2,
                            BankIdentificationCode = "1234557890",
                            LegalAddress = "Dzerzhinskogo District 88",
                            LegalName = "secondBank",
                            PayerAccountNumber = "123456787",
                            Type = "OAO",
                            AmountOfAdministrators = 0,
                            AmountOfClients = 0,
                            AmountOfManagers = 0,
                            AmountOfMoney = 1005005.0,
                            AmountOfOperators = 0
                        });
                });

            modelBuilder.Entity("LAB1.Entities.UserCategories.Client", b =>
                {
                    b.HasBaseType("LAB1.Entities.UserCategories.User");

                    b.Property<double?>("BankBalance")
                        .HasColumnType("REAL");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CurrentBankId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("IdentificationNumber")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ManagerId1")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ManagerId2")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PassportNumberAndSeries")
                        .HasColumnType("TEXT");

                    b.Property<double?>("Salary")
                        .HasColumnType("REAL");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("ManagerId1");

                    b.HasIndex("ManagerId2");

                    b.ToTable("Clients", (string)null);
                });

            modelBuilder.Entity("LAB1.Entities.UserCategories.Operator", b =>
                {
                    b.HasBaseType("LAB1.Entities.UserCategories.User");

                    b.Property<int?>("BankId")
                        .HasColumnType("INTEGER");

                    b.ToTable("Operators", (string)null);
                });

            modelBuilder.Entity("LAB1.Entities.UserCategories.Manager", b =>
                {
                    b.HasBaseType("LAB1.Entities.UserCategories.Operator");

                    b.ToTable("Managers", (string)null);
                });

            modelBuilder.Entity("LAB1.Entities.BankAccount", b =>
                {
                    b.HasOne("LAB1.Entities.Bank", null)
                        .WithMany("OpennedBankAccounts")
                        .HasForeignKey("BankId");

                    b.HasOne("LAB1.Entities.UserCategories.Client", null)
                        .WithMany("OpennedBankAccounts")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("LAB1.Entities.BankApproves", b =>
                {
                    b.HasOne("LAB1.Entities.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId");

                    b.HasOne("LAB1.Entities.UserCategories.Client", null)
                        .WithMany("BanksAndApproves")
                        .HasForeignKey("ClientId");

                    b.Navigation("Bank");
                });

            modelBuilder.Entity("LAB1.Entities.BankDeposit", b =>
                {
                    b.HasOne("LAB1.Entities.Bank", null)
                        .WithMany("OpennedBankDeposits")
                        .HasForeignKey("BankId");

                    b.HasOne("LAB1.Entities.UserCategories.Client", null)
                        .WithMany("OpennedBankDeposits")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("LAB1.Entities.Credit", b =>
                {
                    b.HasOne("LAB1.Entities.Bank", null)
                        .WithMany("OpennedCredits")
                        .HasForeignKey("BankId");
                });

            modelBuilder.Entity("LAB1.Entities.CreditsAndApproves", b =>
                {
                    b.HasOne("LAB1.Entities.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId");

                    b.HasOne("LAB1.Entities.UserCategories.Client", null)
                        .WithMany("CreditsAndApproves")
                        .HasForeignKey("ClientId");

                    b.HasOne("LAB1.Entities.Credit", "Credit")
                        .WithMany()
                        .HasForeignKey("CreditId");

                    b.Navigation("Bank");

                    b.Navigation("Credit");
                });

            modelBuilder.Entity("LAB1.Entities.InstallmentPlan", b =>
                {
                    b.HasOne("LAB1.Entities.Bank", null)
                        .WithMany("OpennedInstallmentPlans")
                        .HasForeignKey("BankId");
                });

            modelBuilder.Entity("LAB1.Entities.InstallmentPlanApproves", b =>
                {
                    b.HasOne("LAB1.Entities.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId");

                    b.HasOne("LAB1.Entities.UserCategories.Client", null)
                        .WithMany("InstallmentPlansAndApproves")
                        .HasForeignKey("ClientId");

                    b.HasOne("LAB1.Entities.InstallmentPlan", "InstallmentPlan")
                        .WithMany()
                        .HasForeignKey("InstallmentPlanId");

                    b.Navigation("Bank");

                    b.Navigation("InstallmentPlan");
                });

            modelBuilder.Entity("LAB1.Entities.UserCategories.User", b =>
                {
                    b.HasOne("LAB1.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LAB1.Entities.Bank", b =>
                {
                    b.HasOne("LAB1.Entities.UserCategories.Client", null)
                        .WithMany("Banks")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("LAB1.Entities.UserCategories.Client", b =>
                {
                    b.HasOne("LAB1.Entities.Company", null)
                        .WithMany("Workers")
                        .HasForeignKey("CompanyId");

                    b.HasOne("LAB1.Entities.UserCategories.User", null)
                        .WithOne()
                        .HasForeignKey("LAB1.Entities.UserCategories.Client", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LAB1.Entities.UserCategories.Manager", null)
                        .WithMany("WaitingForCreditApprove")
                        .HasForeignKey("ManagerId");

                    b.HasOne("LAB1.Entities.UserCategories.Manager", null)
                        .WithMany("WaitingForInstallmentPlanApprove")
                        .HasForeignKey("ManagerId1");

                    b.HasOne("LAB1.Entities.UserCategories.Manager", null)
                        .WithMany("WaitingForRegistrationApprove")
                        .HasForeignKey("ManagerId2");
                });

            modelBuilder.Entity("LAB1.Entities.UserCategories.Operator", b =>
                {
                    b.HasOne("LAB1.Entities.UserCategories.User", null)
                        .WithOne()
                        .HasForeignKey("LAB1.Entities.UserCategories.Operator", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LAB1.Entities.UserCategories.Manager", b =>
                {
                    b.HasOne("LAB1.Entities.UserCategories.Operator", null)
                        .WithOne()
                        .HasForeignKey("LAB1.Entities.UserCategories.Manager", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LAB1.Entities.Company", b =>
                {
                    b.Navigation("Workers");
                });

            modelBuilder.Entity("LAB1.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("LAB1.Entities.Bank", b =>
                {
                    b.Navigation("OpennedBankAccounts");

                    b.Navigation("OpennedBankDeposits");

                    b.Navigation("OpennedCredits");

                    b.Navigation("OpennedInstallmentPlans");
                });

            modelBuilder.Entity("LAB1.Entities.UserCategories.Client", b =>
                {
                    b.Navigation("Banks");

                    b.Navigation("BanksAndApproves");

                    b.Navigation("CreditsAndApproves");

                    b.Navigation("InstallmentPlansAndApproves");

                    b.Navigation("OpennedBankAccounts");

                    b.Navigation("OpennedBankDeposits");
                });

            modelBuilder.Entity("LAB1.Entities.UserCategories.Manager", b =>
                {
                    b.Navigation("WaitingForCreditApprove");

                    b.Navigation("WaitingForInstallmentPlanApprove");

                    b.Navigation("WaitingForRegistrationApprove");
                });
#pragma warning restore 612, 618
        }
    }
}
