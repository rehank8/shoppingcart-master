using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCartApp.Models.Migrations
{
    public partial class AddedFKtoCartItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FKUserId",
                table: "CartItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_FKUserId",
                table: "CartItems",
                column: "FKUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_User_FKUserId",
                table: "CartItems",
                column: "FKUserId",
                principalSchema: "User",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_User_FKUserId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_FKUserId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "FKUserId",
                table: "CartItems");
        }
    }
}
