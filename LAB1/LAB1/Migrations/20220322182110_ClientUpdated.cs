using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class ClientUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Companies_CompanyId",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Clients",
                newName: "WorkId");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_CompanyId",
                table: "Clients",
                newName: "IX_Clients_WorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Companies_WorkId",
                table: "Clients",
                column: "WorkId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Companies_WorkId",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "WorkId",
                table: "Clients",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Clients_WorkId",
                table: "Clients",
                newName: "IX_Clients_CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Companies_CompanyId",
                table: "Clients",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }
    }
}
