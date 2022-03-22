using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class testOne1234567890100099999llkkfgkkkkfddflghffggkhblfkfdgkfdfl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "BankIdentificationCode", "LegalAddress", "LegalName", "PayerAccountNumber", "SalaryForWorkers", "Type" },
                values: new object[] { 3, "1234567890", "Palmyra", "Vagner Group", "123456789", 10000.0, "OPG" });
        }
    }
}
