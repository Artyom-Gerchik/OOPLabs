using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class tmp9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OperatorId",
                table: "RollBackTransferBetweenBankAccounts",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RollBackTransferBetweenBankAccounts_OperatorId",
                table: "RollBackTransferBetweenBankAccounts",
                column: "OperatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_RollBackTransferBetweenBankAccounts_Operators_OperatorId",
                table: "RollBackTransferBetweenBankAccounts",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RollBackTransferBetweenBankAccounts_Operators_OperatorId",
                table: "RollBackTransferBetweenBankAccounts");

            migrationBuilder.DropIndex(
                name: "IX_RollBackTransferBetweenBankAccounts_OperatorId",
                table: "RollBackTransferBetweenBankAccounts");

            migrationBuilder.DropColumn(
                name: "OperatorId",
                table: "RollBackTransferBetweenBankAccounts");
        }
    }
}
