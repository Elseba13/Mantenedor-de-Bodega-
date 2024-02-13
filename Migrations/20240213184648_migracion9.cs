using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mantenedor_de_bodega.Migrations
{
    /// <inheritdoc />
    public partial class migracion9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Inventarios_InventarioIdInventario",
                table: "Articulos");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_InventarioIdInventario",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "InventarioIdInventario",
                table: "Articulos");

            migrationBuilder.AddColumn<int>(
                name: "ArticulosIdArticulo",
                table: "Inventarios",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_ArticulosIdArticulo",
                table: "Inventarios",
                column: "ArticulosIdArticulo");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventarios_Articulos_ArticulosIdArticulo",
                table: "Inventarios",
                column: "ArticulosIdArticulo",
                principalTable: "Articulos",
                principalColumn: "IdArticulo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventarios_Articulos_ArticulosIdArticulo",
                table: "Inventarios");

            migrationBuilder.DropIndex(
                name: "IX_Inventarios_ArticulosIdArticulo",
                table: "Inventarios");

            migrationBuilder.DropColumn(
                name: "ArticulosIdArticulo",
                table: "Inventarios");

            migrationBuilder.AddColumn<int>(
                name: "InventarioIdInventario",
                table: "Articulos",
                type: "int",
                nullable: true);

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
        }
    }
}
