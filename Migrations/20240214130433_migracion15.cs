using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mantenedor_de_bodega.Migrations
{
    /// <inheritdoc />
    public partial class migracion15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bodegas_Inventarios_InventarioIdInventario",
                table: "Bodegas");

            migrationBuilder.DropIndex(
                name: "IX_Bodegas_InventarioIdInventario",
                table: "Bodegas");

            migrationBuilder.DropColumn(
                name: "InventarioIdInventario",
                table: "Bodegas");

            migrationBuilder.AddColumn<int>(
                name: "CodigoBodega",
                table: "Inventarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "bodegaCodigoBodega",
                table: "Inventarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CodigoBodega",
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

            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_bodegaCodigoBodega",
                table: "Inventarios",
                column: "bodegaCodigoBodega");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventarios_Bodegas_bodegaCodigoBodega",
                table: "Inventarios",
                column: "bodegaCodigoBodega",
                principalTable: "Bodegas",
                principalColumn: "CodigoBodega",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventarios_Bodegas_bodegaCodigoBodega",
                table: "Inventarios");

            migrationBuilder.DropIndex(
                name: "IX_Inventarios_bodegaCodigoBodega",
                table: "Inventarios");

            migrationBuilder.DropColumn(
                name: "CodigoBodega",
                table: "Inventarios");

            migrationBuilder.DropColumn(
                name: "bodegaCodigoBodega",
                table: "Inventarios");

            migrationBuilder.DropColumn(
                name: "CodigoBodega",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "StockInicial",
                table: "Articulos");

            migrationBuilder.AddColumn<int>(
                name: "InventarioIdInventario",
                table: "Bodegas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bodegas_InventarioIdInventario",
                table: "Bodegas",
                column: "InventarioIdInventario");

            migrationBuilder.AddForeignKey(
                name: "FK_Bodegas_Inventarios_InventarioIdInventario",
                table: "Bodegas",
                column: "InventarioIdInventario",
                principalTable: "Inventarios",
                principalColumn: "IdInventario");
        }
    }
}
