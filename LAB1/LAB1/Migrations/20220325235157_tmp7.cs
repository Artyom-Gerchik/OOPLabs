using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class tmp7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RollBackDeletedCredit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreditId = table.Column<int>(type: "INTEGER", nullable: true),
                    TransferId = table.Column<double>(type: "REAL", nullable: true),
                    AdministratorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RollBackDeletedCredit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RollBackDeletedCredit_Administrators_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackDeletedCredit_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackDeletedCredit_Credit_CreditId",
                        column: x => x.CreditId,
                        principalTable: "Credit",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackDeletedCredit_Transfers_TransferId",
                        column: x => x.TransferId,
                        principalTable: "Transfers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RollBackDeletedCredit_AdministratorId",
                table: "RollBackDeletedCredit",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackDeletedCredit_ClientId",
                table: "RollBackDeletedCredit",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackDeletedCredit_CreditId",
                table: "RollBackDeletedCredit",
                column: "CreditId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackDeletedCredit_TransferId",
                table: "RollBackDeletedCredit",
                column: "TransferId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RollBackDeletedCredit");
        }
    }
}
