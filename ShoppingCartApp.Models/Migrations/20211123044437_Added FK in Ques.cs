using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCartApp.Models.Migrations
{
    public partial class AddedFKinQues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FKUserId",
                schema: "User",
                table: "SecurityQuestions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SecurityQuestions_FKUserId",
                schema: "User",
                table: "SecurityQuestions",
                column: "FKUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityQuestions_User_FKUserId",
                schema: "User",
                table: "SecurityQuestions",
                column: "FKUserId",
                principalSchema: "User",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SecurityQuestions_User_FKUserId",
                schema: "User",
                table: "SecurityQuestions");

            migrationBuilder.DropIndex(
                name: "IX_SecurityQuestions_FKUserId",
                schema: "User",
                table: "SecurityQuestions");

            migrationBuilder.DropColumn(
                name: "FKUserId",
                schema: "User",
                table: "SecurityQuestions");
        }
    }
}
