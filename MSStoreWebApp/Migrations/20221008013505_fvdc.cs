using Microsoft.EntityFrameworkCore.Migrations;

namespace MSStoreWebApp.Migrations
{
    public partial class fvdc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "siks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_siks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sikGots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SikId = table.Column<int>(type: "int", nullable: false),
                    GotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sikGots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sikGots_gots_GotId",
                        column: x => x.GotId,
                        principalTable: "gots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sikGots_siks_SikId",
                        column: x => x.SikId,
                        principalTable: "siks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_sikGots_GotId",
                table: "sikGots",
                column: "GotId");

            migrationBuilder.CreateIndex(
                name: "IX_sikGots_SikId",
                table: "sikGots",
                column: "SikId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sikGots");

            migrationBuilder.DropTable(
                name: "gots");

            migrationBuilder.DropTable(
                name: "siks");
        }
    }
}
