using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class testOne1234567890100099999l : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "AmountOfAdministrators", "AmountOfClients", "AmountOfManagers", "AmountOfMoney", "AmountOfOperators", "BankIdentificationCode", "ClientId", "LegalAddress", "LegalName", "PayerAccountNumber", "Type" },
                values: new object[] { 2, 0, 0, 0, 1005005.0, 0, "1234557890", null, "Dzerzhinskogo District 88", "secondBank", "123456787", "OAO" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
