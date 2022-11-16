using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCartApp.Models.Migrations
{
    public partial class addedbrandstableaddedfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "FKSubCategoryId",
                schema: "Product",
                table: "Brands",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FKCategoryId",
                schema: "Product",
                table: "Brands",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FKBrandId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brands_FKCategoryId",
                schema: "Product",
                table: "Brands",
                column: "FKCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_FKSubCategoryId",
                schema: "Product",
                table: "Brands",
                column: "FKSubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FKBrandId",
                table: "Products",
                column: "FKBrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_FKBrandId",
                table: "Products",
                column: "FKBrandId",
                principalSchema: "Product",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Category_FKCategoryId",
                schema: "Product",
                table: "Brands",
                column: "FKCategoryId",
                principalSchema: "Product",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_SubCategory_FKSubCategoryId",
                schema: "Product",
                table: "Brands",
                column: "FKSubCategoryId",
                principalSchema: "Product",
                principalTable: "SubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_FKBrandId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Category_FKCategoryId",
                schema: "Product",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Brands_SubCategory_FKSubCategoryId",
                schema: "Product",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Brands_FKCategoryId",
                schema: "Product",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Brands_FKSubCategoryId",
                schema: "Product",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Products_FKBrandId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FKBrandId",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "FKSubCategoryId",
                schema: "Product",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FKCategoryId",
                schema: "Product",
                table: "Brands",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
