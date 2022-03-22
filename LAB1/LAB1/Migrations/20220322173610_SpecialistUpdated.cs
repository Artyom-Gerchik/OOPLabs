using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class SpecialistUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpecialistId",
                table: "Clients",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_SpecialistId",
                table: "Clients",
                column: "SpecialistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Specialists_SpecialistId",
                table: "Clients",
                column: "SpecialistId",
                principalTable: "Specialists",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Specialists_SpecialistId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_SpecialistId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "SpecialistId",
                table: "Clients");
        }
    }
}
