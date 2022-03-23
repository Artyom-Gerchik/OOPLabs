using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LAB1.Migrations
{
    public partial class ClientUpdatedAgainllf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OperatorId",
                table: "Clients",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_OperatorId",
                table: "Clients",
                column: "OperatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Operators_OperatorId",
                table: "Clients",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Operators_OperatorId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_OperatorId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "OperatorId",
                table: "Clients");
        }
    }
}
