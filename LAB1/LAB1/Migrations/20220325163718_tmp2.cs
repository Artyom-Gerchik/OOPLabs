using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class tmp2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Hidden",
                table: "BankDeposit",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RollBackClosedDeposit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true),
                    BankDepositId = table.Column<int>(type: "INTEGER", nullable: true),
                    AdministratorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RollBackClosedDeposit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RollBackClosedDeposit_Administrators_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackClosedDeposit_BankDeposit_BankDepositId",
                        column: x => x.BankDepositId,
                        principalTable: "BankDeposit",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RollBackClosedDeposit_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RollBackClosedDeposit_AdministratorId",
                table: "RollBackClosedDeposit",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackClosedDeposit_BankDepositId",
                table: "RollBackClosedDeposit",
                column: "BankDepositId");

            migrationBuilder.CreateIndex(
                name: "IX_RollBackClosedDeposit_ClientId",
                table: "RollBackClosedDeposit",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RollBackClosedDeposit");

            migrationBuilder.DropColumn(
                name: "Hidden",
                table: "BankDeposit");
        }
    }
}
