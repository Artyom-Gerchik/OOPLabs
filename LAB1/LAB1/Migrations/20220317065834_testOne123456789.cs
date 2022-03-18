using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class testOne123456789 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BankId",
                table: "Clients",
                newName: "CurrentBankId");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Banks",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Banks_ClientId",
                table: "Banks",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Banks_Clients_ClientId",
                table: "Banks",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banks_Clients_ClientId",
                table: "Banks");

            migrationBuilder.DropIndex(
                name: "IX_Banks_ClientId",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Banks");

            migrationBuilder.RenameColumn(
                name: "CurrentBankId",
                table: "Clients",
                newName: "BankId");
        }
    }
}
