using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mantenedor_de_bodega.Migrations
{
    /// <inheritdoc />
    public partial class migracion30 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bodegas_Articulos_ArticulosIdArticulo",
                table: "Bodegas");

            migrationBuilder.DropIndex(
                name: "IX_Bodegas_ArticulosIdArticulo",
                table: "Bodegas");

            migrationBuilder.DropColumn(
                name: "ArticulosIdArticulo",
                table: "Bodegas");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "ArticulosIdArticulo",
                table: "Bodegas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "stockTotalEnBodega",
                table: "Bodegas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bodegas_ArticulosIdArticulo",
                table: "Bodegas",
                column: "ArticulosIdArticulo");

            migrationBuilder.AddForeignKey(
                name: "FK_Bodegas_Articulos_ArticulosIdArticulo",
                table: "Bodegas",
                column: "ArticulosIdArticulo",
                principalTable: "Articulos",
                principalColumn: "IdArticulo");
        }
    }
}
