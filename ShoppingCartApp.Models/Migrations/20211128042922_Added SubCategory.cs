using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCartApp.Models.Migrations
{
    public partial class AddedSubCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubCategory",
                schema: "Product",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    SubCategoryName = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    FKCategoryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategory_Category_FKCategoryId",
                        column: x => x.FKCategoryId,
                        principalSchema: "Product",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_FKCategoryId",
                schema: "Product",
                table: "SubCategory",
                column: "FKCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubCategory",
                schema: "Product");
        }
    }
}
