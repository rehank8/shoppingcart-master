using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCartApp.Models.Migrations
{
    public partial class AddedFKProductinCartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FKProductId",
                table: "CartItems",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_FKProductId",
                table: "CartItems",
                column: "FKProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_FKProductId",
                table: "CartItems",
                column: "FKProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_FKProductId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_FKProductId",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "FKProductId",
                table: "CartItems");
        }
    }
}
