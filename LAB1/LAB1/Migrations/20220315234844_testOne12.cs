using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class testOne12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Banks_Client_BankId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Client_BankId",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_Client_BankId",
                table: "Users",
                column: "Client_BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Banks_Client_BankId",
                table: "Users",
                column: "Client_BankId",
                principalTable: "Banks",
                principalColumn: "Id");
        }
    }
}
