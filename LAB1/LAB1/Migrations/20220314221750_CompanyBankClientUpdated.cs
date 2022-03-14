using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class CompanyBankClientUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmountOfAdministrators",
                table: "Banks",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AmountOfClients",
                table: "Banks",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AmountOfManagers",
                table: "Banks",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AmountOfMoney",
                table: "Banks",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AmountOfOperators",
                table: "Banks",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankIdentificationCode",
                table: "Banks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalAddress",
                table: "Banks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LegalName",
                table: "Banks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PayerAccountNumber",
                table: "Banks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Banks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BankId = table.Column<int>(type: "INTEGER", nullable: true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccount_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BankAccount_Users_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_BankId",
                table: "BankAccount",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_ClientId",
                table: "BankAccount",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.DropColumn(
                name: "AmountOfAdministrators",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "AmountOfClients",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "AmountOfManagers",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "AmountOfMoney",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "AmountOfOperators",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "BankIdentificationCode",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "LegalAddress",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "LegalName",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "PayerAccountNumber",
                table: "Banks");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Banks");
        }
    }
}
