using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mantenedor_de_bodega.Migrations
{
    /// <inheritdoc />
    public partial class migracion35 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosInventarios_Inventarios_InventarioIdArticulos_InventarioCodigoBodega",
                table: "MovimientosInventarios");

            migrationBuilder.DropIndex(
                name: "IX_MovimientosInventarios_InventarioIdArticulos_InventarioCodigoBodega",
                table: "MovimientosInventarios");

            migrationBuilder.DropColumn(
                name: "InventarioCodigoBodega",
                table: "MovimientosInventarios");

            migrationBuilder.DropColumn(
                name: "InventarioIdArticulos",
                table: "MovimientosInventarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosInventarios_InventarioIdArticulos_InventarioCodigoBodega",
                table: "MovimientosInventarios",
                columns: new[] { "InventarioIdArticulos", "InventarioCodigoBodega" });

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosInventarios_Inventarios_InventarioIdArticulos_InventarioCodigoBodega",
                table: "MovimientosInventarios",
                columns: new[] { "InventarioIdArticulos", "InventarioCodigoBodega" },
                principalTable: "Inventarios",
                principalColumns: new[] { "IdArticulos", "CodigoBodega" });
        }
    }
}
