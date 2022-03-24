using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class ClientUpdatedAgainllfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<bool>(
                name: "Hidden",
                table: "InstallmentPlan",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Hidden",
                table: "BankAccount",
                type: "INTEGER",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Blocked",
                table: "InstallmentPlan");

            migrationBuilder.DropColumn(
                name: "Frozen",
                table: "InstallmentPlan");

            migrationBuilder.DropColumn(
                name: "Hidden",
                table: "InstallmentPlan");

            migrationBuilder.DropColumn(
                name: "Hidden",
                table: "BankAccount");
        }
    }
}
