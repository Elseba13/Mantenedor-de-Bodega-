using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mantenedor_de_bodega.Migrations
{
    /// <inheritdoc />
    public partial class migracion34 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventarios_Articulos_CodigoBodega",
                table: "Inventarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventarios_Bodegas_IdArticulos",
                table: "Inventarios");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventarios_Articulos_IdArticulos",
                table: "Inventarios",
                column: "IdArticulos",
                principalTable: "Articulos",
                principalColumn: "IdArticulo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventarios_Bodegas_CodigoBodega",
                table: "Inventarios",
                column: "CodigoBodega",
                principalTable: "Bodegas",
                principalColumn: "CodigoBodega",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventarios_Articulos_IdArticulos",
                table: "Inventarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventarios_Bodegas_CodigoBodega",
                table: "Inventarios");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventarios_Articulos_CodigoBodega",
                table: "Inventarios",
                column: "CodigoBodega",
                principalTable: "Articulos",
                principalColumn: "IdArticulo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventarios_Bodegas_IdArticulos",
                table: "Inventarios",
                column: "IdArticulos",
                principalTable: "Bodegas",
                principalColumn: "CodigoBodega",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
