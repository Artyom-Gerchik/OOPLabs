using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class testOne1234567890100099999llkkfgkkkk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InstallmentPlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BankId = table.Column<int>(type: "INTEGER", nullable: true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: true),
                    DurationInMonths = table.Column<int>(type: "INTEGER", nullable: true),
                    Percent = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstallmentPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstallmentPlan_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InstallmentPlan_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstallmentPlan_BankId",
                table: "InstallmentPlan",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_InstallmentPlan_ClientId",
                table: "InstallmentPlan",
                column: "ClientId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstallmentPlan");
        }
    }
}
