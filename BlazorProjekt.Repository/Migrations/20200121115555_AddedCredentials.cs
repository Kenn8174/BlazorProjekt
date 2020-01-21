using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorProjekt.Repository.Migrations
{
    public partial class AddedCredentials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FKCredentialId",
                table: "Owners",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Credentials",
                columns: table => new
                {
                    CredentialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HashedUsername = table.Column<string>(nullable: true),
                    HashedPassword = table.Column<string>(nullable: true),
                    FKOwnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credentials", x => x.CredentialId);
                    table.ForeignKey(
                        name: "FK_Credentials_Owners_FKOwnerId",
                        column: x => x.FKOwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Credentials_FKOwnerId",
                table: "Credentials",
                column: "FKOwnerId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Credentials");

            migrationBuilder.DropColumn(
                name: "FKCredentialId",
                table: "Owners");
        }
    }
}
