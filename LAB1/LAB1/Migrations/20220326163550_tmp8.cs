using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class tmp8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Blocked",
                table: "InstallmentPlan");

            migrationBuilder.DropColumn(
                name: "Frozen",
                table: "InstallmentPlan");

            migrationBuilder.AddColumn<bool>(
                name: "Blocked",
                table: "BankDeposit",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Frozen",
                table: "BankDeposit",
                type: "INTEGER",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Blocked",
                table: "BankDeposit");

            migrationBuilder.DropColumn(
                name: "Frozen",
                table: "BankDeposit");

            migrationBuilder.AddColumn<bool>(
                name: "Blocked",
                table: "InstallmentPlan",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Frozen",
                table: "InstallmentPlan",
                type: "INTEGER",
                nullable: true);
        }
    }
}
