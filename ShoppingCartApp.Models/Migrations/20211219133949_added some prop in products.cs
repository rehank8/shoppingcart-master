using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCartApp.Models.Migrations
{
    public partial class addedsomepropinproducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Condition",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Features",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailability",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Condition",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Features",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsAvailability",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Products");
        }
    }
}
