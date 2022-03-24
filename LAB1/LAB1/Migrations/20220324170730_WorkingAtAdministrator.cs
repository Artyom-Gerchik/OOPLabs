using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class WorkingAtAdministrator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BankId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrators_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeletedBankAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true),
                    BankAccountId = table.Column<int>(type: "INTEGER", nullable: true),
                    AdministratorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeletedBankAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeletedBankAccount_Administrators_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeletedBankAccount_BankAccount_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DeletedBankAccount_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OpennedBankAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true),
                    BankAccountId = table.Column<int>(type: "INTEGER", nullable: true),
                    AdministratorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpennedBankAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpennedBankAccount_Administrators_AdministratorId",
                        column: x => x.AdministratorId,
                        principalTable: "Administrators",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OpennedBankAccount_BankAccount_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OpennedBankAccount_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeletedBankAccount_AdministratorId",
                table: "DeletedBankAccount",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_DeletedBankAccount_BankAccountId",
                table: "DeletedBankAccount",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_DeletedBankAccount_ClientId",
                table: "DeletedBankAccount",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_OpennedBankAccount_AdministratorId",
                table: "OpennedBankAccount",
                column: "AdministratorId");

            migrationBuilder.CreateIndex(
                name: "IX_OpennedBankAccount_BankAccountId",
                table: "OpennedBankAccount",
                column: "BankAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_OpennedBankAccount_ClientId",
                table: "OpennedBankAccount",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeletedBankAccount");

            migrationBuilder.DropTable(
                name: "OpennedBankAccount");

            migrationBuilder.DropTable(
                name: "Administrators");
        }
    }
}
