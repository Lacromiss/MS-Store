using Microsoft.EntityFrameworkCore.Migrations;

namespace MSStoreWebApp.Migrations
{
    public partial class asgas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BestId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_products_BestId",
                table: "products",
                column: "BestId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_bests_BestId",
                table: "products",
                column: "BestId",
                principalTable: "bests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_bests_BestId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_BestId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "BestId",
                table: "products");
        }
    }
}
