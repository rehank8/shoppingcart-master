using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCartApp.Models.Migrations
{
    public partial class addedbrandstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                schema: "Product",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    FKSubCategoryId = table.Column<string>(nullable: true),
                    FKCategoryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brands",
                schema: "Product");
        }
    }
}
