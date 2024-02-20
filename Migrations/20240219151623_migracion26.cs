using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mantenedor_de_bodega.Migrations
{
    /// <inheritdoc />
    public partial class migracion26 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Bodegas_BodegaCodigoBodega",
                table: "Articulos");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_BodegaCodigoBodega",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "BodegaCodigoBodega",
                table: "Articulos");

            migrationBuilder.AddColumn<int>(
                name: "stockTotalEnBodega",
                table: "Bodegas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ArticulosBodega",
                columns: table => new
                {
                    BodegaCodigoBodega = table.Column<int>(type: "int", nullable: false),
                    articulosIdArticulo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticulosBodega", x => new { x.BodegaCodigoBodega, x.articulosIdArticulo });
                    table.ForeignKey(
                        name: "FK_ArticulosBodega_Articulos_articulosIdArticulo",
                        column: x => x.articulosIdArticulo,
                        principalTable: "Articulos",
                        principalColumn: "IdArticulo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticulosBodega_Bodegas_BodegaCodigoBodega",
                        column: x => x.BodegaCodigoBodega,
                        principalTable: "Bodegas",
                        principalColumn: "CodigoBodega",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticulosBodega_articulosIdArticulo",
                table: "ArticulosBodega",
                column: "articulosIdArticulo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticulosBodega");

            migrationBuilder.DropColumn(
                name: "stockTotalEnBodega",
                table: "Bodegas");

            migrationBuilder.AddColumn<int>(
                name: "BodegaCodigoBodega",
                table: "Articulos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_BodegaCodigoBodega",
                table: "Articulos",
                column: "BodegaCodigoBodega");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_Bodegas_BodegaCodigoBodega",
                table: "Articulos",
                column: "BodegaCodigoBodega",
                principalTable: "Bodegas",
                principalColumn: "CodigoBodega",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
