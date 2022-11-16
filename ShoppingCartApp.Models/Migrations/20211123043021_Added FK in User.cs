using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCartApp.Models.Migrations
{
    public partial class AddedFKinUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FKQuestionId",
                schema: "User",
                table: "User",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_FKQuestionId",
                schema: "User",
                table: "User",
                column: "FKQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_SecurityQuestions_FKQuestionId",
                schema: "User",
                table: "User",
                column: "FKQuestionId",
                principalSchema: "User",
                principalTable: "SecurityQuestions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_SecurityQuestions_FKQuestionId",
                schema: "User",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_FKQuestionId",
                schema: "User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FKQuestionId",
                schema: "User",
                table: "User");
        }
    }
}
