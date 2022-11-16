using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCartApp.Models.Migrations
{
    public partial class AddedCategoryanddtinProductsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Products",
                type: "VARCHAR(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(500)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Products",
                type: "VARCHAR(500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)");
        }
    }
}
