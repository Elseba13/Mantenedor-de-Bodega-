using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mantenedor_de_bodega.Migrations
{
    /// <inheritdoc />
    public partial class Migracion6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Inventarios_InventarioCodigoBodega_InventarioIdArticulo",
                table: "Articulos");

            migrationBuilder.DropForeignKey(
                name: "FK_Bodegas_Inventarios_InventarioCodigoBodega_InventarioIdArticulo",
                table: "Bodegas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventarios",
                table: "Inventarios");

            migrationBuilder.DropIndex(
                name: "IX_Bodegas_InventarioCodigoBodega_InventarioIdArticulo",
                table: "Bodegas");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_InventarioCodigoBodega_InventarioIdArticulo",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "CodigoBodega",
                table: "MovimientosInventarios");

            migrationBuilder.DropColumn(
                name: "IdArticulo",
                table: "MovimientosInventarios");

            migrationBuilder.DropColumn(
                name: "IdMotivo",
                table: "MovimientosInventarios");

            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "MovimientosInventarios");

            migrationBuilder.DropColumn(
                name: "CodigoBodega",
                table: "Inventarios");

            migrationBuilder.DropColumn(
                name: "IdArticulo",
                table: "Inventarios");

            migrationBuilder.DropColumn(
                name: "CodigoCentroSalud",
                table: "Bodegas");

            migrationBuilder.DropColumn(
                name: "InventarioCodigoBodega",
                table: "Bodegas");

            migrationBuilder.DropColumn(
                name: "InventarioCodigoBodega",
                table: "Articulos");

            migrationBuilder.RenameColumn(
                name: "InventarioIdArticulo",
                table: "Bodegas",
                newName: "InventarioIdInventario");

            migrationBuilder.RenameColumn(
                name: "InventarioIdArticulo",
                table: "Articulos",
                newName: "InventarioIdInventario");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaDeMovimiento",
                table: "MovimientosInventarios",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.DropColumn(
                     name: "IdInventario",
                     table: "Inventarios");

            migrationBuilder.AddColumn<int>(
                name: "IdInventario",
                table: "Inventarios",
                nullable: false)
                .Annotation("SqlServer:Identity", true);
         

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventarios",
                table: "Inventarios",
                column: "IdInventario");

            migrationBuilder.CreateIndex(
                name: "IX_Bodegas_InventarioIdInventario",
                table: "Bodegas",
                column: "InventarioIdInventario");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_InventarioIdInventario",
                table: "Articulos",
                column: "InventarioIdInventario");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_Inventarios_InventarioIdInventario",
                table: "Articulos",
                column: "InventarioIdInventario",
                principalTable: "Inventarios",
                principalColumn: "IdInventario");

            migrationBuilder.AddForeignKey(
                name: "FK_Bodegas_Inventarios_InventarioIdInventario",
                table: "Bodegas",
                column: "InventarioIdInventario",
                principalTable: "Inventarios",
                principalColumn: "IdInventario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Inventarios_InventarioIdInventario",
                table: "Articulos");

            migrationBuilder.DropForeignKey(
                name: "FK_Bodegas_Inventarios_InventarioIdInventario",
                table: "Bodegas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventarios",
                table: "Inventarios");

            migrationBuilder.DropIndex(
                name: "IX_Bodegas_InventarioIdInventario",
                table: "Bodegas");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_InventarioIdInventario",
                table: "Articulos");

            migrationBuilder.RenameColumn(
                name: "InventarioIdInventario",
                table: "Bodegas",
                newName: "InventarioIdArticulo");

            migrationBuilder.RenameColumn(
                name: "InventarioIdInventario",
                table: "Articulos",
                newName: "InventarioIdArticulo");

            migrationBuilder.AlterColumn<string>(
                name: "FechaDeMovimiento",
                table: "MovimientosInventarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CodigoBodega",
                table: "MovimientosInventarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdArticulo",
                table: "MovimientosInventarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdMotivo",
                table: "MovimientosInventarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdUsuario",
                table: "MovimientosInventarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "IdInventario",
                table: "Inventarios",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CodigoBodega",
                table: "Inventarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdArticulo",
                table: "Inventarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CodigoCentroSalud",
                table: "Bodegas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "InventarioCodigoBodega",
                table: "Bodegas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InventarioCodigoBodega",
                table: "Articulos",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventarios",
                table: "Inventarios",
                columns: new[] { "CodigoBodega", "IdArticulo" });

            migrationBuilder.CreateIndex(
                name: "IX_Bodegas_InventarioCodigoBodega_InventarioIdArticulo",
                table: "Bodegas",
                columns: new[] { "InventarioCodigoBodega", "InventarioIdArticulo" });

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_InventarioCodigoBodega_InventarioIdArticulo",
                table: "Articulos",
                columns: new[] { "InventarioCodigoBodega", "InventarioIdArticulo" });

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_Inventarios_InventarioCodigoBodega_InventarioIdArticulo",
                table: "Articulos",
                columns: new[] { "InventarioCodigoBodega", "InventarioIdArticulo" },
                principalTable: "Inventarios",
                principalColumns: new[] { "CodigoBodega", "IdArticulo" });

            migrationBuilder.AddForeignKey(
                name: "FK_Bodegas_Inventarios_InventarioCodigoBodega_InventarioIdArticulo",
                table: "Bodegas",
                columns: new[] { "InventarioCodigoBodega", "InventarioIdArticulo" },
                principalTable: "Inventarios",
                principalColumns: new[] { "CodigoBodega", "IdArticulo" });
        }
    }
}
