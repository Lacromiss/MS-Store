using Microsoft.EntityFrameworkCore.Migrations;

namespace MSStoreWebApp.Migrations
{
    public partial class step7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "stellers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_stellers_ProductId",
                table: "stellers",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_stellers_products_ProductId",
                table: "stellers",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stellers_products_ProductId",
                table: "stellers");

            migrationBuilder.DropIndex(
                name: "IX_stellers_ProductId",
                table: "stellers");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "stellers");
        }
    }
}
