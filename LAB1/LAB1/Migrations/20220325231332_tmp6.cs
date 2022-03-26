using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class tmp6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hidden",
                table: "InstallmentPlanApproves");

            migrationBuilder.AddColumn<bool>(
                name: "Hidden",
                table: "Credit",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RollBackOpennedCredit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreditId = table.Column<int>(type: "INTEGER", nullable: true),
                    AdministratorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RollBackOpennedCredit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RollBackOpennedCredit_Administrators_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackOpennedCredit_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackOpennedCredit_Credit_CreditId",
                        column: x => x.CreditId,
                        principalTable: "Credit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RollBackOpennedCredit_AdministratorId",
                table: "RollBackOpennedCredit",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackOpennedCredit_ClientId",
                table: "RollBackOpennedCredit",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackOpennedCredit_CreditId",
                table: "RollBackOpennedCredit",
                column: "CreditId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RollBackOpennedCredit");

            migrationBuilder.DropColumn(
                name: "Hidden",
                table: "Credit");

            migrationBuilder.AddColumn<bool>(
                name: "Hidden",
                table: "InstallmentPlanApproves",
                type: "INTEGER",
                nullable: true);
        }
    }
}
