using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorProjekt.Repository.Migrations
{
    public partial class Initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    AccountTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Interrest = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    MinimumAge = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.AccountTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Sexes",
                columns: table => new
                {
                    SexId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexes", x => x.SexId);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    OwnerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Admin = table.Column<bool>(nullable: false),
                    FKSexId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.OwnerId);
                    table.ForeignKey(
                        name: "FK_Owners_Sexes_FKSexId",
                        column: x => x.FKSexId,
                        principalTable: "Sexes",
                        principalColumn: "SexId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    FKOwnerId = table.Column<int>(nullable: false),
                    FKAccountTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountTypes_FKAccountTypeId",
                        column: x => x.FKAccountTypeId,
                        principalTable: "AccountTypes",
                        principalColumn: "AccountTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Owners_FKOwnerId",
                        column: x => x.FKOwnerId,
                        principalTable: "Owners",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "AccountTypeId", "Interrest", "MinimumAge", "Name" },
                values: new object[,]
                {
                    { 1, 0.05m, 18, "CheckingsAccount" },
                    { 2, 0.07m, 0, "SavingsAccount" },
                    { 3, 0.09m, 13, "YouthAccount" }
                });

            migrationBuilder.InsertData(
                table: "Sexes",
                columns: new[] { "SexId", "Name" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" },
                    { 3, "Transsexual Male" },
                    { 4, "Transsexual Female" }
                });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "OwnerId", "Admin", "Age", "FKSexId", "Name" },
                values: new object[] { 1, false, 20, 1, "Jimmy Elkjer" });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "OwnerId", "Admin", "Age", "FKSexId", "Name" },
                values: new object[] { 2, false, 22, 1, "Kenneth Jessen" });

            migrationBuilder.InsertData(
                table: "Owners",
                columns: new[] { "OwnerId", "Admin", "Age", "FKSexId", "Name" },
                values: new object[] { 3, false, 20, 3, "Kristian Biehl Kuhrt" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "Balance", "FKAccountTypeId", "FKOwnerId" },
                values: new object[] { 1, 100000.5m, 1, 1 });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "Balance", "FKAccountTypeId", "FKOwnerId" },
                values: new object[] { 2, 1000000m, 2, 2 });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountId", "Balance", "FKAccountTypeId", "FKOwnerId" },
                values: new object[] { 3, 1000.1m, 3, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_FKAccountTypeId",
                table: "Accounts",
                column: "FKAccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_FKOwnerId",
                table: "Accounts",
                column: "FKOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_FKSexId",
                table: "Owners",
                column: "FKSexId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "Sexes");
        }
    }
}
