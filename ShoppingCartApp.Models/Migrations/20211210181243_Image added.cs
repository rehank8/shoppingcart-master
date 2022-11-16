using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCartApp.Models.Migrations
{
    public partial class Imageadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Products",
                type: "VARCHAR(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Products",
                type: "VARCHAR(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(MAX)",
                oldNullable: true);
        }
    }
}
