using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCartApp.Models.Migrations
{
    public partial class AddedsubTypess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubCategoryTypes",
                schema: "Product",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    SubCategoryTypeName = table.Column<string>(type: "VARCHAR(500)", nullable: false),
                    FKSubCategoryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoryTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategoryTypes_SubCategory_FKSubCategoryId",
                        column: x => x.FKSubCategoryId,
                        principalSchema: "Product",
                        principalTable: "SubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryTypes_FKSubCategoryId",
                schema: "Product",
                table: "SubCategoryTypes",
                column: "FKSubCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubCategoryTypes",
                schema: "Product");
        }
    }
}
