using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class tmp4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RollBackOpennedInstallmentPlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true),
                    InstallmentPlanId = table.Column<int>(type: "INTEGER", nullable: true),
                    AdministratorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RollBackOpennedInstallmentPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RollBackOpennedInstallmentPlan_Administrators_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackOpennedInstallmentPlan_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackOpennedInstallmentPlan_InstallmentPlan_InstallmentPlanId",
                        column: x => x.InstallmentPlanId,
                        principalTable: "InstallmentPlan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RollBackOpennedInstallmentPlan_AdministratorId",
                table: "RollBackOpennedInstallmentPlan",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackOpennedInstallmentPlan_ClientId",
                table: "RollBackOpennedInstallmentPlan",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackOpennedInstallmentPlan_InstallmentPlanId",
                table: "RollBackOpennedInstallmentPlan",
                column: "InstallmentPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RollBackOpennedInstallmentPlan");
        }
    }
}
