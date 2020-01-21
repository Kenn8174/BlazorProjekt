using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorProjekt.Repository.Migrations
{
    public partial class RemovedFKCredentialIdFromOwnersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FKCredentialId",
                table: "Owners");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FKCredentialId",
                table: "Owners",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
