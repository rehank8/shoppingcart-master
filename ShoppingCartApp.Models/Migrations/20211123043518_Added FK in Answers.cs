using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCartApp.Models.Migrations
{
    public partial class AddedFKinAnswers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FKQuestionId",
                schema: "User",
                table: "SecurityAnswers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SecurityAnswers_FKQuestionId",
                schema: "User",
                table: "SecurityAnswers",
                column: "FKQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SecurityAnswers_SecurityQuestions_FKQuestionId",
                schema: "User",
                table: "SecurityAnswers",
                column: "FKQuestionId",
                principalSchema: "User",
                principalTable: "SecurityQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SecurityAnswers_SecurityQuestions_FKQuestionId",
                schema: "User",
                table: "SecurityAnswers");

            migrationBuilder.DropIndex(
                name: "IX_SecurityAnswers_FKQuestionId",
                schema: "User",
                table: "SecurityAnswers");

            migrationBuilder.DropColumn(
                name: "FKQuestionId",
                schema: "User",
                table: "SecurityAnswers");
        }
    }
}
