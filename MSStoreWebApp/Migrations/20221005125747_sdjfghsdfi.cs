using Microsoft.EntityFrameworkCore.Migrations;

namespace MSStoreWebApp.Migrations
{
    public partial class sdjfghsdfi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Best",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Best", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Best_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Best_ProductId",
                table: "Best",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Best");

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
    }
}
