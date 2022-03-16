using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class testOne1234567 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Managers_ManagerWhoApprovesId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ManagerWhoApprovesId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ManagerWhoApprovesId",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Clients",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ManagerId",
                table: "Clients",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Managers_ManagerId",
                table: "Clients",
                column: "ManagerId",
                principalTable: "Managers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Managers_ManagerId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ManagerId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "ManagerWhoApprovesId",
                table: "Clients",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ManagerWhoApprovesId",
                table: "Clients",
                column: "ManagerWhoApprovesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Managers_ManagerWhoApprovesId",
                table: "Clients",
                column: "ManagerWhoApprovesId",
                principalTable: "Managers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
