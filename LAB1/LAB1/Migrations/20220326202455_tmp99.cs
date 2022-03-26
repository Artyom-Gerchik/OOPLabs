using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class tmp99 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_SpecialistSendClients_SpecialistSendClientsId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_SpecialistSendClientsId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "SpecialistSendClientsId",
                table: "Clients");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "SpecialistSendClients",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SpecialistSendClients_ClientId",
                table: "SpecialistSendClients",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialistSendClients_Clients_ClientId",
                table: "SpecialistSendClients",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecialistSendClients_Clients_ClientId",
                table: "SpecialistSendClients");

            migrationBuilder.DropIndex(
                name: "IX_SpecialistSendClients_ClientId",
                table: "SpecialistSendClients");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "SpecialistSendClients");

            migrationBuilder.AddColumn<int>(
                name: "SpecialistSendClientsId",
                table: "Clients",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_SpecialistSendClientsId",
                table: "Clients",
                column: "SpecialistSendClientsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_SpecialistSendClients_SpecialistSendClientsId",
                table: "Clients",
                column: "SpecialistSendClientsId",
                principalTable: "SpecialistSendClients",
                principalColumn: "Id");
        }
    }
}
