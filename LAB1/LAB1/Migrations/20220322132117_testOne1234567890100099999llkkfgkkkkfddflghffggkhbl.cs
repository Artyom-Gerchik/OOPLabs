using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class testOne1234567890100099999llkkfgkkkkfddflghffggkhbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfMoneyBack",
                table: "InstallmentPlan",
                newName: "DateToPay");

            migrationBuilder.RenameColumn(
                name: "DateOfMoneyBack",
                table: "Credit",
                newName: "DateToPay");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfDeal",
                table: "InstallmentPlan",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfDeal",
                table: "Credit",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfDeal",
                table: "InstallmentPlan");

            migrationBuilder.DropColumn(
                name: "DateOfDeal",
                table: "Credit");

            migrationBuilder.RenameColumn(
                name: "DateToPay",
                table: "InstallmentPlan",
                newName: "DateOfMoneyBack");

            migrationBuilder.RenameColumn(
                name: "DateToPay",
                table: "Credit",
                newName: "DateOfMoneyBack");
        }
    }
}
