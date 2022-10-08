using Microsoft.EntityFrameworkCore.Migrations;

namespace MSStoreWebApp.Migrations
{
    public partial class cvbngfdfghjkhgfghj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Best_products_ProductId",
                table: "Best");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Best",
                table: "Best");

            migrationBuilder.RenameTable(
                name: "Best",
                newName: "bests");

            migrationBuilder.RenameIndex(
                name: "IX_Best_ProductId",
                table: "bests",
                newName: "IX_bests_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bests",
                table: "bests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_bests_products_ProductId",
                table: "bests",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bests_products_ProductId",
                table: "bests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bests",
                table: "bests");

            migrationBuilder.RenameTable(
                name: "bests",
                newName: "Best");

            migrationBuilder.RenameIndex(
                name: "IX_bests_ProductId",
                table: "Best",
                newName: "IX_Best_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Best",
                table: "Best",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Best_products_ProductId",
                table: "Best",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
