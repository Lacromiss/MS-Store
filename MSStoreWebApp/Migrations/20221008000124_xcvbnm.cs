using Microsoft.EntityFrameworkCore.Migrations;

namespace MSStoreWebApp.Migrations
{
    public partial class xcvbnm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColorrId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorrId",
                table: "products");
        }
    }
}
