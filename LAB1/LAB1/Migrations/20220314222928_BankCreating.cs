using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class BankCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "AmountOfAdministrators", "AmountOfClients", "AmountOfManagers", "AmountOfMoney", "AmountOfOperators", "BankIdentificationCode", "LegalAddress", "LegalName", "PayerAccountNumber", "Type" },
                values: new object[] { 1, 0, 0, 0, 100500.0, 0, "1234567890", "Dzerzhinskogo District", "firstBank", "123456789", "OOO" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
