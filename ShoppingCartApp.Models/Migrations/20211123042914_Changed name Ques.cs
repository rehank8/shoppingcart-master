using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCartApp.Models.Migrations
{
    public partial class ChangednameQues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "SecurityQuestions",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "SecurityQuestions",
                newName: "SecurityQuestions",
                newSchema: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SecurityQuestions",
                schema: "User",
                table: "SecurityQuestions",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SecurityQuestions",
                schema: "User",
                table: "SecurityQuestions");

            migrationBuilder.EnsureSchema(
                name: "SecurityQuestions");

            migrationBuilder.RenameTable(
                name: "SecurityQuestions",
                schema: "User",
                newName: "User",
                newSchema: "SecurityQuestions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "SecurityQuestions",
                table: "User",
                column: "Id");
        }
    }
}
