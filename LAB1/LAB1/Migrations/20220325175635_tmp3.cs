using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class tmp3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RollBackTransferBetweenBankDeposits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BankDepositWhereWithdrawedId = table.Column<int>(type: "INTEGER", nullable: true),
                    BankDepositToDepositedId = table.Column<int>(type: "INTEGER", nullable: true),
                    TransferId = table.Column<double>(type: "REAL", nullable: true),
                    AdministratorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RollBackTransferBetweenBankDeposits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RollBackTransferBetweenBankDeposits_Administrators_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackTransferBetweenBankDeposits_BankDeposit_BankDepositToDepositedId",
                        column: x => x.BankDepositToDepositedId,
                        principalTable: "BankDeposit",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackTransferBetweenBankDeposits_BankDeposit_BankDepositWhereWithdrawedId",
                        column: x => x.BankDepositWhereWithdrawedId,
                        principalTable: "BankDeposit",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackTransferBetweenBankDeposits_Transfers_TransferId",
                        column: x => x.TransferId,
                        principalTable: "Transfers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RollBackTransferBetweenBankDeposits_AdministratorId",
                table: "RollBackTransferBetweenBankDeposits",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackTransferBetweenBankDeposits_BankDepositToDepositedId",
                table: "RollBackTransferBetweenBankDeposits",
                column: "BankDepositToDepositedId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackTransferBetweenBankDeposits_BankDepositWhereWithdrawedId",
                table: "RollBackTransferBetweenBankDeposits",
                column: "BankDepositWhereWithdrawedId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackTransferBetweenBankDeposits_TransferId",
                table: "RollBackTransferBetweenBankDeposits",
                column: "TransferId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RollBackTransferBetweenBankDeposits");
        }
    }
}
