using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCartApp.Models.Migrations
{
    public partial class updateduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IPAddress",
                schema: "User",
                table: "User",
                type: "VARCHAR(500)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(500)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IPAddress",
                schema: "User",
                table: "User",
                type: "VARCHAR(500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(500)",
                oldNullable: true);
        }
    }
}
