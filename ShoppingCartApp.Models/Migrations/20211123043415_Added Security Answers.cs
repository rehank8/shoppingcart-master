using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCartApp.Models.Migrations
{
    public partial class AddedSecurityAnswers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SecurityAnswers",
                schema: "User",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Answers = table.Column<string>(type: "VARCHAR(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityAnswers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecurityAnswers",
                schema: "User");
        }
    }
}
