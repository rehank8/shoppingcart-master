using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCartApp.Models.Migrations
{
    public partial class AddedIP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
               name: "IPAddress",
               schema: "User",
               table: "User",
               type: "VARCHAR(500)",
               nullable: false,
               defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IPAddress",
                schema: "User",
                table: "User",
                type: "VARCHAR(500)",
                nullable: false,
                defaultValue: "");
        }
    }
}
