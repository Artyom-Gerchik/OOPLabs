using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class testOne1234567890100099999llkkfgkkkkfddflghffggkhblf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationInMonths",
                table: "InstallmentPlan");

            migrationBuilder.DropColumn(
                name: "DurationInMonths",
                table: "Credit");

            migrationBuilder.RenameColumn(
                name: "HowMuchMonthsLasts",
                table: "InstallmentPlan",
                newName: "HowMuchLasts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HowMuchLasts",
                table: "InstallmentPlan",
                newName: "HowMuchMonthsLasts");

            migrationBuilder.AddColumn<int>(
                name: "DurationInMonths",
                table: "InstallmentPlan",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DurationInMonths",
                table: "Credit",
                type: "INTEGER",
                nullable: true);
        }
    }
}
