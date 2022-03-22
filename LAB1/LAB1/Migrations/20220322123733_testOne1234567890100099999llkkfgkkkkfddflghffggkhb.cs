using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class testOne1234567890100099999llkkfgkkkkfddflghffggkhb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Credit_BankId",
                table: "Credit",
                column: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Credit_Banks_BankId",
                table: "Credit",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Credit_Banks_BankId",
                table: "Credit");

            migrationBuilder.DropIndex(
                name: "IX_Credit_BankId",
                table: "Credit");
        }
    }
}
