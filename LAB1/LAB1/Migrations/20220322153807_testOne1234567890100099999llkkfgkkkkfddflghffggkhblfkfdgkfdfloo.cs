using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class testOne1234567890100099999llkkfgkkkkfddflghffggkhblfkfdgkfdfloo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Approves_Banks_BankId",
                table: "Approves");

            migrationBuilder.DropForeignKey(
                name: "FK_BankAccount_Banks_BankId",
                table: "BankAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_BankDeposit_Banks_BankId",
                table: "BankDeposit");

            migrationBuilder.DropForeignKey(
                name: "FK_Credit_Banks_BankId",
                table: "Credit");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditsAndApproves_Banks_BankId",
                table: "CreditsAndApproves");

            migrationBuilder.DropForeignKey(
                name: "FK_InstallmentPlan_Banks_BankId",
                table: "InstallmentPlan");

            migrationBuilder.DropForeignKey(
                name: "FK_InstallmentPlanApproves_Banks_BankId",
                table: "InstallmentPlanApproves");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "AmountOfAdministrators",
                table: "Companies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AmountOfClients",
                table: "Companies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AmountOfManagers",
                table: "Companies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "AmountOfMoney",
                table: "Companies",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AmountOfOperators",
                table: "Companies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Companies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Companies",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "AmountOfAdministrators", "AmountOfClients", "AmountOfManagers", "AmountOfMoney", "AmountOfOperators", "BankIdentificationCode", "ClientId", "Discriminator", "LegalAddress", "LegalName", "PayerAccountNumber", "SalaryForWorkers", "Type" },
                values: new object[] { 1, 0, 0, 0, 100500.0, 0, "1234567890", null, "Bank", "Dzerzhinskogo District", "firstBank", "123456789", null, "OOO" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "AmountOfAdministrators", "AmountOfClients", "AmountOfManagers", "AmountOfMoney", "AmountOfOperators", "BankIdentificationCode", "ClientId", "Discriminator", "LegalAddress", "LegalName", "PayerAccountNumber", "SalaryForWorkers", "Type" },
                values: new object[] { 2, 0, 0, 0, 1005005.0, 0, "1234557890", null, "Bank", "Dzerzhinskogo District 88", "secondBank", "123456787", null, "OAO" });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ClientId",
                table: "Companies",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Approves_Companies_BankId",
                table: "Approves",
                column: "BankId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccount_Companies_BankId",
                table: "BankAccount",
                column: "BankId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankDeposit_Companies_BankId",
                table: "BankDeposit",
                column: "BankId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Clients_ClientId",
                table: "Companies",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Credit_Companies_BankId",
                table: "Credit",
                column: "BankId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditsAndApproves_Companies_BankId",
                table: "CreditsAndApproves",
                column: "BankId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstallmentPlan_Companies_BankId",
                table: "InstallmentPlan",
                column: "BankId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstallmentPlanApproves_Companies_BankId",
                table: "InstallmentPlanApproves",
                column: "BankId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Approves_Companies_BankId",
                table: "Approves");

            migrationBuilder.DropForeignKey(
                name: "FK_BankAccount_Companies_BankId",
                table: "BankAccount");

            migrationBuilder.DropForeignKey(
                name: "FK_BankDeposit_Companies_BankId",
                table: "BankDeposit");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Clients_ClientId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Credit_Companies_BankId",
                table: "Credit");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditsAndApproves_Companies_BankId",
                table: "CreditsAndApproves");

            migrationBuilder.DropForeignKey(
                name: "FK_InstallmentPlan_Companies_BankId",
                table: "InstallmentPlan");

            migrationBuilder.DropForeignKey(
                name: "FK_InstallmentPlanApproves_Companies_BankId",
                table: "InstallmentPlanApproves");

            migrationBuilder.DropIndex(
                name: "IX_Companies_ClientId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "AmountOfAdministrators",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "AmountOfClients",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "AmountOfManagers",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "AmountOfMoney",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "AmountOfOperators",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Companies");

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AmountOfAdministrators = table.Column<int>(type: "INTEGER", nullable: true),
                    AmountOfClients = table.Column<int>(type: "INTEGER", nullable: true),
                    AmountOfManagers = table.Column<int>(type: "INTEGER", nullable: true),
                    AmountOfMoney = table.Column<double>(type: "REAL", nullable: true),
                    AmountOfOperators = table.Column<int>(type: "INTEGER", nullable: true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Banks_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Banks_Companies_Id",
                        column: x => x.Id,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "AmountOfAdministrators", "AmountOfClients", "AmountOfManagers", "AmountOfMoney", "AmountOfOperators" },
                values: new object[] { 1, 0, 0, 0, 100500.0, 0 });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "AmountOfAdministrators", "AmountOfClients", "AmountOfManagers", "AmountOfMoney", "AmountOfOperators" },
                values: new object[] { 2, 0, 0, 0, 1005005.0, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Banks_ClientId",
                table: "Banks",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Approves_Banks_BankId",
                table: "Approves",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccount_Banks_BankId",
                table: "BankAccount",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankDeposit_Banks_BankId",
                table: "BankDeposit",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Credit_Banks_BankId",
                table: "Credit",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CreditsAndApproves_Banks_BankId",
                table: "CreditsAndApproves",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstallmentPlan_Banks_BankId",
                table: "InstallmentPlan",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstallmentPlanApproves_Banks_BankId",
                table: "InstallmentPlanApproves",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id");
        }
    }
}
