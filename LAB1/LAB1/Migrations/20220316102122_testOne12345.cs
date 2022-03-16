using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class testOne12345 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdsOfClientsWaitingForRegistrationApprove_Capacity",
                table: "Managers");

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
                name: "IdsOfClientsWaitingForRegistrationApprove_Capacity",
                table: "Managers",
                type: "INTEGER",
                nullable: true);
        }
    }
}
