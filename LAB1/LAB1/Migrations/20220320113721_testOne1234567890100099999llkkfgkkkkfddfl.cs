using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class testOne1234567890100099999llkkfgkkkkfddfl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManagerId1",
                table: "Clients",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ManagerId1",
                table: "Clients",
                column: "ManagerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Managers_ManagerId1",
                table: "Clients",
                column: "ManagerId1",
                principalTable: "Managers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Managers_ManagerId1",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ManagerId1",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ManagerId1",
                table: "Clients");
        }
    }
}
