using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class testOne1234567890100099999llkkfgkkkkfddflghffggkhblfkfdgk : Migration
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
                name: "FK_Banks_Clients_ClientId",
                table: "Banks");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Banks",
                table: "Banks");

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Banks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "Banks",
                newName: "Companies");

            migrationBuilder.RenameIndex(
                name: "IX_Banks_ClientId",
                table: "Companies",
                newName: "IX_Companies_ClientId");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Clients",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Companies",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "SalaryForWorkers",
                table: "Companies",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "AmountOfAdministrators", "AmountOfClients", "AmountOfManagers", "AmountOfMoney", "AmountOfOperators", "BankIdentificationCode", "ClientId", "Discriminator", "LegalAddress", "LegalName", "PayerAccountNumber", "SalaryForWorkers", "Type" },
                values: new object[] { 1, 0, 0, 0, 100500.0, 0, "1234567890", null, "Bank", "Dzerzhinskogo District", "firstBank", "123456789", null, "OOO" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "AmountOfAdministrators", "AmountOfClients", "AmountOfManagers", "AmountOfMoney", "AmountOfOperators", "BankIdentificationCode", "ClientId", "Discriminator", "LegalAddress", "LegalName", "PayerAccountNumber", "SalaryForWorkers", "Type" },
                values: new object[] { 2, 0, 0, 0, 1005005.0, 0, "1234557890", null, "Bank", "Dzerzhinskogo District 88", "secondBank", "123456787", null, "OAO" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "BankIdentificationCode", "Discriminator", "LegalAddress", "LegalName", "PayerAccountNumber", "SalaryForWorkers", "Type" },
                values: new object[] { 3, "1234567890", "Company", "Palmyra", "Vagner Group", "123456789", 10000.0, "OPG" });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CompanyId",
                table: "Clients",
                column: "CompanyId");

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
                name: "FK_Clients_Companies_CompanyId",
                table: "Clients",
                column: "CompanyId",
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
                name: "FK_Clients_Companies_CompanyId",
                table: "Clients");

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
                name: "IX_Clients_CompanyId",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "SalaryForWorkers",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Banks");

            migrationBuilder.RenameIndex(
                name: "IX_Companies_ClientId",
                table: "Banks",
                newName: "IX_Banks_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Banks",
                table: "Banks",
                column: "Id");

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
                name: "FK_Banks_Clients_ClientId",
                table: "Banks",
                column: "ClientId",
                principalTable: "Clients",
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
