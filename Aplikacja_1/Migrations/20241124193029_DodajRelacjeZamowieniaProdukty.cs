using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aplikacja_1.Migrations
{
    /// <inheritdoc />
    public partial class DodajRelacjeZamowieniaProdukty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produkty_Zamowienia_ZamowienieId",
                table: "Produkty");

            migrationBuilder.DropIndex(
                name: "IX_Produkty_ZamowienieId",
                table: "Produkty");

            migrationBuilder.DropColumn(
                name: "ZamowienieId",
                table: "Produkty");

            migrationBuilder.CreateTable(
                name: "ZamowieniaProdukty",
                columns: table => new
                {
                    ProduktyId = table.Column<int>(type: "int", nullable: false),
                    ZamowieniaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZamowieniaProdukty", x => new { x.ProduktyId, x.ZamowieniaId });
                    table.ForeignKey(
                        name: "FK_ZamowieniaProdukty_Produkty_ProduktyId",
                        column: x => x.ProduktyId,
                        principalTable: "Produkty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZamowieniaProdukty_Zamowienia_ZamowieniaId",
                        column: x => x.ZamowieniaId,
                        principalTable: "Zamowienia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ZamowieniaProdukty_ZamowieniaId",
                table: "ZamowieniaProdukty",
                column: "ZamowieniaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ZamowieniaProdukty");

            migrationBuilder.AddColumn<int>(
                name: "ZamowienieId",
                table: "Produkty",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produkty_ZamowienieId",
                table: "Produkty",
                column: "ZamowienieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produkty_Zamowienia_ZamowienieId",
                table: "Produkty",
                column: "ZamowienieId",
                principalTable: "Zamowienia",
                principalColumn: "Id");
        }
    }
}
