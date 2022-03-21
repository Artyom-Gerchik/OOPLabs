using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class testOne1234567890100099999llkkfgkkkkfddf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AmountOfMoney",
                table: "InstallmentPlan",
                type: "REAL",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountOfMoney",
                table: "InstallmentPlan");
        }
    }
}
