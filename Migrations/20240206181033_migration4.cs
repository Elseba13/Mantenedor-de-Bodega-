using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mantenedor_de_bodega.Migrations
{
    /// <inheritdoc />
    public partial class migration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovimientosInventarioIdMovimiento",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovimientosInventarioIdMovimiento",
                table: "Motivos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BodegaCodigoBodega",
                table: "CentroDeSaluds",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InventarioCodigoBodega",
                table: "Bodegas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InventarioIdArticulo",
                table: "Bodegas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovimientosInventarioIdMovimiento",
                table: "Bodegas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InventarioCodigoBodega",
                table: "Articulos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InventarioIdArticulo",
                table: "Articulos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovimientosInventarioIdMovimiento",
                table: "Articulos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_MovimientosInventarioIdMovimiento",
                table: "Usuarios",
                column: "MovimientosInventarioIdMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_Motivos_MovimientosInventarioIdMovimiento",
                table: "Motivos",
                column: "MovimientosInventarioIdMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_CentroDeSaluds_BodegaCodigoBodega",
                table: "CentroDeSaluds",
                column: "BodegaCodigoBodega");

            migrationBuilder.CreateIndex(
                name: "IX_Bodegas_InventarioCodigoBodega_InventarioIdArticulo",
                table: "Bodegas",
                columns: new[] { "InventarioCodigoBodega", "InventarioIdArticulo" });

            migrationBuilder.CreateIndex(
                name: "IX_Bodegas_MovimientosInventarioIdMovimiento",
                table: "Bodegas",
                column: "MovimientosInventarioIdMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_InventarioCodigoBodega_InventarioIdArticulo",
                table: "Articulos",
                columns: new[] { "InventarioCodigoBodega", "InventarioIdArticulo" });

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_MovimientosInventarioIdMovimiento",
                table: "Articulos",
                column: "MovimientosInventarioIdMovimiento");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_Inventarios_InventarioCodigoBodega_InventarioIdArticulo",
                table: "Articulos",
                columns: new[] { "InventarioCodigoBodega", "InventarioIdArticulo" },
                principalTable: "Inventarios",
                principalColumns: new[] { "CodigoBodega", "IdArticulo" });

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_MovimientosInventarios_MovimientosInventarioIdMovimiento",
                table: "Articulos",
                column: "MovimientosInventarioIdMovimiento",
                principalTable: "MovimientosInventarios",
                principalColumn: "IdMovimiento");

            migrationBuilder.AddForeignKey(
                name: "FK_Bodegas_Inventarios_InventarioCodigoBodega_InventarioIdArticulo",
                table: "Bodegas",
                columns: new[] { "InventarioCodigoBodega", "InventarioIdArticulo" },
                principalTable: "Inventarios",
                principalColumns: new[] { "CodigoBodega", "IdArticulo" });

            migrationBuilder.AddForeignKey(
                name: "FK_Bodegas_MovimientosInventarios_MovimientosInventarioIdMovimiento",
                table: "Bodegas",
                column: "MovimientosInventarioIdMovimiento",
                principalTable: "MovimientosInventarios",
                principalColumn: "IdMovimiento");

            migrationBuilder.AddForeignKey(
                name: "FK_CentroDeSaluds_Bodegas_BodegaCodigoBodega",
                table: "CentroDeSaluds",
                column: "BodegaCodigoBodega",
                principalTable: "Bodegas",
                principalColumn: "CodigoBodega");

            migrationBuilder.AddForeignKey(
                name: "FK_Motivos_MovimientosInventarios_MovimientosInventarioIdMovimiento",
                table: "Motivos",
                column: "MovimientosInventarioIdMovimiento",
                principalTable: "MovimientosInventarios",
                principalColumn: "IdMovimiento");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_MovimientosInventarios_MovimientosInventarioIdMovimiento",
                table: "Usuarios",
                column: "MovimientosInventarioIdMovimiento",
                principalTable: "MovimientosInventarios",
                principalColumn: "IdMovimiento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Inventarios_InventarioCodigoBodega_InventarioIdArticulo",
                table: "Articulos");

            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_MovimientosInventarios_MovimientosInventarioIdMovimiento",
                table: "Articulos");

            migrationBuilder.DropForeignKey(
                name: "FK_Bodegas_Inventarios_InventarioCodigoBodega_InventarioIdArticulo",
                table: "Bodegas");

            migrationBuilder.DropForeignKey(
                name: "FK_Bodegas_MovimientosInventarios_MovimientosInventarioIdMovimiento",
                table: "Bodegas");

            migrationBuilder.DropForeignKey(
                name: "FK_CentroDeSaluds_Bodegas_BodegaCodigoBodega",
                table: "CentroDeSaluds");

            migrationBuilder.DropForeignKey(
                name: "FK_Motivos_MovimientosInventarios_MovimientosInventarioIdMovimiento",
                table: "Motivos");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_MovimientosInventarios_MovimientosInventarioIdMovimiento",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_MovimientosInventarioIdMovimiento",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Motivos_MovimientosInventarioIdMovimiento",
                table: "Motivos");

            migrationBuilder.DropIndex(
                name: "IX_CentroDeSaluds_BodegaCodigoBodega",
                table: "CentroDeSaluds");

            migrationBuilder.DropIndex(
                name: "IX_Bodegas_InventarioCodigoBodega_InventarioIdArticulo",
                table: "Bodegas");

            migrationBuilder.DropIndex(
                name: "IX_Bodegas_MovimientosInventarioIdMovimiento",
                table: "Bodegas");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_InventarioCodigoBodega_InventarioIdArticulo",
                table: "Articulos");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_MovimientosInventarioIdMovimiento",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "MovimientosInventarioIdMovimiento",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "MovimientosInventarioIdMovimiento",
                table: "Motivos");

            migrationBuilder.DropColumn(
                name: "BodegaCodigoBodega",
                table: "CentroDeSaluds");

            migrationBuilder.DropColumn(
                name: "InventarioCodigoBodega",
                table: "Bodegas");

            migrationBuilder.DropColumn(
                name: "InventarioIdArticulo",
                table: "Bodegas");

            migrationBuilder.DropColumn(
                name: "MovimientosInventarioIdMovimiento",
                table: "Bodegas");

            migrationBuilder.DropColumn(
                name: "InventarioCodigoBodega",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "InventarioIdArticulo",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "MovimientosInventarioIdMovimiento",
                table: "Articulos");
        }
    }
}
