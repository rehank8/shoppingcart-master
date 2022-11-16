using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCartApp.Models.Migrations
{
    public partial class AddedIpone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<bool>(
                name: "IsSecurityQuestions",
                schema: "User",
                table: "User",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IPAddress",
                schema: "User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsSecurityQuestions",
                schema: "User",
                table: "User");
        }
    }
}
