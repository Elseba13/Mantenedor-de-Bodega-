using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mantenedor_de_bodega.Migrations
{
    /// <inheritdoc />
    public partial class migracion33 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticulosBodega");

            migrationBuilder.DropColumn(
                name: "StockActual",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "StockInicial",
                table: "Articulos");

            migrationBuilder.AddColumn<int>(
                name: "InventarioCodigoBodega",
                table: "MovimientosInventarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InventarioIdArticulos",
                table: "MovimientosInventarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Inventarios",
                columns: table => new
                {
                    IdArticulos = table.Column<int>(type: "int", nullable: false),
                    CodigoBodega = table.Column<int>(type: "int", nullable: false),
                    StockInicial = table.Column<int>(type: "int", nullable: false),
                    StockActual = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventarios", x => new { x.IdArticulos, x.CodigoBodega });
                    table.ForeignKey(
                        name: "FK_Inventarios_Articulos_CodigoBodega",
                        column: x => x.CodigoBodega,
                        principalTable: "Articulos",
                        principalColumn: "IdArticulo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventarios_Bodegas_IdArticulos",
                        column: x => x.IdArticulos,
                        principalTable: "Bodegas",
                        principalColumn: "CodigoBodega",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosInventarios_InventarioIdArticulos_InventarioCodigoBodega",
                table: "MovimientosInventarios",
                columns: new[] { "InventarioIdArticulos", "InventarioCodigoBodega" });

            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_CodigoBodega",
                table: "Inventarios",
                column: "CodigoBodega");

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosInventarios_Inventarios_InventarioIdArticulos_InventarioCodigoBodega",
                table: "MovimientosInventarios",
                columns: new[] { "InventarioIdArticulos", "InventarioCodigoBodega" },
                principalTable: "Inventarios",
                principalColumns: new[] { "IdArticulos", "CodigoBodega" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosInventarios_Inventarios_InventarioIdArticulos_InventarioCodigoBodega",
                table: "MovimientosInventarios");

            migrationBuilder.DropTable(
                name: "Inventarios");

            migrationBuilder.DropIndex(
                name: "IX_MovimientosInventarios_InventarioIdArticulos_InventarioCodigoBodega",
                table: "MovimientosInventarios");

            migrationBuilder.DropColumn(
                name: "InventarioCodigoBodega",
                table: "MovimientosInventarios");

            migrationBuilder.DropColumn(
                name: "InventarioIdArticulos",
                table: "MovimientosInventarios");

            migrationBuilder.AddColumn<int>(
                name: "StockActual",
                table: "Articulos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockInicial",
                table: "Articulos",
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
    }
}
