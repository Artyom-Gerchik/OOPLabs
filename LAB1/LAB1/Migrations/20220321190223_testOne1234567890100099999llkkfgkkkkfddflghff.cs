using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class testOne1234567890100099999llkkfgkkkkfddflghff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManagerId2",
                table: "Clients",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Credit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BankId = table.Column<int>(type: "INTEGER", nullable: true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true),
                    DurationInMonths = table.Column<int>(type: "INTEGER", nullable: true),
                    Percent = table.Column<double>(type: "REAL", nullable: true),
                    AmountOfMoney = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditsAndApproves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BankId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreditId = table.Column<int>(type: "INTEGER", nullable: true),
                    Approved = table.Column<bool>(type: "INTEGER", nullable: true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditsAndApproves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditsAndApproves_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CreditsAndApproves_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CreditsAndApproves_Credit_CreditId",
                        column: x => x.CreditId,
                        principalTable: "Credit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ManagerId2",
                table: "Clients",
                column: "ManagerId2");

            migrationBuilder.CreateIndex(
                name: "IX_CreditsAndApproves_BankId",
                table: "CreditsAndApproves",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditsAndApproves_ClientId",
                table: "CreditsAndApproves",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditsAndApproves_CreditId",
                table: "CreditsAndApproves",
                column: "CreditId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Managers_ManagerId2",
                table: "Clients",
                column: "ManagerId2",
                principalTable: "Managers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Managers_ManagerId2",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "CreditsAndApproves");

            migrationBuilder.DropTable(
                name: "Credit");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ManagerId2",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ManagerId2",
                table: "Clients");
        }
    }
}
