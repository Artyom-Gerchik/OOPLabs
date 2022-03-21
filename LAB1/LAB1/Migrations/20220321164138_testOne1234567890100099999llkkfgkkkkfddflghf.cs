using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class testOne1234567890100099999llkkfgkkkkfddflghf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstallmentPlan_Clients_ClientId",
                table: "InstallmentPlan");

            migrationBuilder.DropIndex(
                name: "IX_InstallmentPlan_ClientId",
                table: "InstallmentPlan");

            migrationBuilder.CreateTable(
                name: "InstallmentPlanApproves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BankId = table.Column<int>(type: "INTEGER", nullable: true),
                    InstallmentPlanId = table.Column<int>(type: "INTEGER", nullable: true),
                    Approved = table.Column<bool>(type: "INTEGER", nullable: true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstallmentPlanApproves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstallmentPlanApproves_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstallmentPlanApproves_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstallmentPlanApproves_InstallmentPlan_InstallmentPlanId",
                        column: x => x.InstallmentPlanId,
                        principalTable: "InstallmentPlan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstallmentPlanApproves_BankId",
                table: "InstallmentPlanApproves",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_InstallmentPlanApproves_ClientId",
                table: "InstallmentPlanApproves",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_InstallmentPlanApproves_InstallmentPlanId",
                table: "InstallmentPlanApproves",
                column: "InstallmentPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstallmentPlanApproves");

            migrationBuilder.CreateIndex(
                name: "IX_InstallmentPlan_ClientId",
                table: "InstallmentPlan",
                column: "ClientId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InstallmentPlan_Clients_ClientId",
                table: "InstallmentPlan",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }
    }
}
