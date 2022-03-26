using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class tmp5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Approves_Banks_BankId",
                table: "Approves");

            migrationBuilder.DropForeignKey(
                name: "FK_Approves_Clients_ClientId",
                table: "Approves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Approves",
                table: "Approves");

            migrationBuilder.RenameTable(
                name: "Approves",
                newName: "BankApproves");

            migrationBuilder.RenameIndex(
                name: "IX_Approves_ClientId",
                table: "BankApproves",
                newName: "IX_BankApproves_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Approves_BankId",
                table: "BankApproves",
                newName: "IX_BankApproves_BankId");

            migrationBuilder.AddColumn<bool>(
                name: "Hidden",
                table: "InstallmentPlanApproves",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankApproves",
                table: "BankApproves",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "RollBackDeletedInstallmentPlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true),
                    InstallmentPlanId = table.Column<int>(type: "INTEGER", nullable: true),
                    TransferId = table.Column<double>(type: "REAL", nullable: true),
                    AdministratorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RollBackDeletedInstallmentPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RollBackDeletedInstallmentPlan_Administrators_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackDeletedInstallmentPlan_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackDeletedInstallmentPlan_InstallmentPlan_InstallmentPlanId",
                        column: x => x.InstallmentPlanId,
                        principalTable: "InstallmentPlan",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackDeletedInstallmentPlan_Transfers_TransferId",
                        column: x => x.TransferId,
                        principalTable: "Transfers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RollBackDeletedInstallmentPlan_AdministratorId",
                table: "RollBackDeletedInstallmentPlan",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackDeletedInstallmentPlan_ClientId",
                table: "RollBackDeletedInstallmentPlan",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackDeletedInstallmentPlan_InstallmentPlanId",
                table: "RollBackDeletedInstallmentPlan",
                column: "InstallmentPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackDeletedInstallmentPlan_TransferId",
                table: "RollBackDeletedInstallmentPlan",
                column: "TransferId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankApproves_Banks_BankId",
                table: "BankApproves",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankApproves_Clients_ClientId",
                table: "BankApproves",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankApproves_Banks_BankId",
                table: "BankApproves");

            migrationBuilder.DropForeignKey(
                name: "FK_BankApproves_Clients_ClientId",
                table: "BankApproves");

            migrationBuilder.DropTable(
                name: "RollBackDeletedInstallmentPlan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankApproves",
                table: "BankApproves");

            migrationBuilder.DropColumn(
                name: "Hidden",
                table: "InstallmentPlanApproves");

            migrationBuilder.RenameTable(
                name: "BankApproves",
                newName: "Approves");

            migrationBuilder.RenameIndex(
                name: "IX_BankApproves_ClientId",
                table: "Approves",
                newName: "IX_Approves_ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_BankApproves_BankId",
                table: "Approves",
                newName: "IX_Approves_BankId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Approves",
                table: "Approves",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Approves_Banks_BankId",
                table: "Approves",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Approves_Clients_ClientId",
                table: "Approves",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");
        }
    }
}
