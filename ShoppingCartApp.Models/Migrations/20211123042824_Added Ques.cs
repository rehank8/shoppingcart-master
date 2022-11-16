using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCartApp.Models.Migrations
{
    public partial class AddedQues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SecurityQuestions");

            migrationBuilder.CreateTable(
                name: "User",
                schema: "SecurityQuestions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Questions = table.Column<string>(type: "VARCHAR(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User",
                schema: "SecurityQuestions");
        }
    }
}
