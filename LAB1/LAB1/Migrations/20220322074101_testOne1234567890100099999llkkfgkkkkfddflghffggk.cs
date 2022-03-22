using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class testOne1234567890100099999llkkfgkkkkfddflghffggk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfMoneyBack",
                table: "InstallmentPlan",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HowMuchMonthsLasts",
                table: "InstallmentPlan",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfMoneyBack",
                table: "Credit",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HowMuchLasts",
                table: "Credit",
                type: "INTEGER",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfMoneyBack",
                table: "InstallmentPlan");

            migrationBuilder.DropColumn(
                name: "HowMuchMonthsLasts",
                table: "InstallmentPlan");

            migrationBuilder.DropColumn(
                name: "DateOfMoneyBack",
                table: "Credit");

            migrationBuilder.DropColumn(
                name: "HowMuchLasts",
                table: "Credit");
        }
    }
}
