using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class tmp0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpecialistSendClientsId",
                table: "Clients",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SpecialistSendClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ManagerId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialistSendClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialistSendClients_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_SpecialistSendClientsId",
                table: "Clients",
                column: "SpecialistSendClientsId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialistSendClients_ManagerId",
                table: "SpecialistSendClients",
                column: "ManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_SpecialistSendClients_SpecialistSendClientsId",
                table: "Clients",
                column: "SpecialistSendClientsId",
                principalTable: "SpecialistSendClients",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_SpecialistSendClients_SpecialistSendClientsId",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "SpecialistSendClients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_SpecialistSendClientsId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "SpecialistSendClientsId",
                table: "Clients");
        }
    }
}
