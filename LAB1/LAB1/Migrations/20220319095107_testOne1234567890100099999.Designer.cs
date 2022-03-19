﻿// <auto-generated />
using System;
using LAB1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LAB1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220319095107_testOne1234567890100099999")]
    partial class testOne1234567890100099999
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("LAB1.Entities.Bank", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

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

                    b.Property<string>("BankIdentificationCode")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LegalAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("LegalName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PayerAccountNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Banks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AmountOfAdministrators = 0,
                            AmountOfClients = 0,
                            AmountOfManagers = 0,
                            AmountOfMoney = 100500.0,
                            AmountOfOperators = 0,
                            BankIdentificationCode = "1234567890",
                            LegalAddress = "Dzerzhinskogo District",
                            LegalName = "firstBank",
                            PayerAccountNumber = "123456789",
                            Type = "OOO"
                        });
                });

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

            modelBuilder.Entity("LAB1.Entities.UserCategories.Client", b =>
                {
                    b.HasBaseType("LAB1.Entities.UserCategories.User");

                    b.Property<double?>("BankBalance")
                        .HasColumnType("REAL");

                    b.Property<int?>("CurrentBankId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("IdentificationNumber")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PassportNumberAndSeries")
                        .HasColumnType("TEXT");

                    b.HasIndex("ManagerId");

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

            modelBuilder.Entity("LAB1.Entities.Bank", b =>
                {
                    b.HasOne("LAB1.Entities.UserCategories.Client", null)
                        .WithMany("Banks")
                        .HasForeignKey("ClientId");
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

            modelBuilder.Entity("LAB1.Entities.UserCategories.Client", b =>
                {
                    b.HasOne("LAB1.Entities.UserCategories.User", null)
                        .WithOne()
                        .HasForeignKey("LAB1.Entities.UserCategories.Client", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LAB1.Entities.UserCategories.Manager", null)
                        .WithMany("WaitingForRegistrationApprove")
                        .HasForeignKey("ManagerId");
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

            modelBuilder.Entity("LAB1.Entities.Bank", b =>
                {
                    b.Navigation("OpennedBankAccounts");
                });

            modelBuilder.Entity("LAB1.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("LAB1.Entities.UserCategories.Client", b =>
                {
                    b.Navigation("Banks");

                    b.Navigation("BanksAndApproves");

                    b.Navigation("OpennedBankAccounts");
                });

            modelBuilder.Entity("LAB1.Entities.UserCategories.Manager", b =>
                {
                    b.Navigation("WaitingForRegistrationApprove");
                });
#pragma warning restore 612, 618
        }
    }
}
