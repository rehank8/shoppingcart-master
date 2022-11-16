using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCartApp.Models.Migrations
{
    public partial class AddedFKtoAnswers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "FKUserId",
                schema: "User",
                table: "SecurityAnswers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SecurityAnswers_FKUserId",
                schema: "User",
                table: "SecurityAnswers",
                column: "FKUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityAnswers_User_FKUserId",
                schema: "User",
                table: "SecurityAnswers",
                column: "FKUserId",
                principalSchema: "User",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SecurityAnswers_User_FKUserId",
                schema: "User",
                table: "SecurityAnswers");

            migrationBuilder.DropIndex(
                name: "IX_SecurityAnswers_FKUserId",
                schema: "User",
                table: "SecurityAnswers");

            migrationBuilder.DropColumn(
                name: "FKUserId",
                schema: "User",
                table: "SecurityAnswers");

            migrationBuilder.AddColumn<string>(
                name: "FKUserId",
                schema: "User",
                table: "SecurityQuestions",
                type: "nvarchar(450)",
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
    }
}
