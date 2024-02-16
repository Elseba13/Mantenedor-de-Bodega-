using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mantenedor_de_bodega.Migrations
{
    /// <inheritdoc />
    public partial class migracion24 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosInventarios_Bodegas_BodegaDestinoCodigoBodega",
                table: "MovimientosInventarios");

            migrationBuilder.AlterColumn<int>(
                name: "BodegaDestinoCodigoBodega",
                table: "MovimientosInventarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosInventarios_Bodegas_BodegaDestinoCodigoBodega",
                table: "MovimientosInventarios",
                column: "BodegaDestinoCodigoBodega",
                principalTable: "Bodegas",
                principalColumn: "CodigoBodega");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosInventarios_Bodegas_BodegaDestinoCodigoBodega",
                table: "MovimientosInventarios");

            migrationBuilder.AlterColumn<int>(
                name: "BodegaDestinoCodigoBodega",
                table: "MovimientosInventarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosInventarios_Bodegas_BodegaDestinoCodigoBodega",
                table: "MovimientosInventarios",
                column: "BodegaDestinoCodigoBodega",
                principalTable: "Bodegas",
                principalColumn: "CodigoBodega",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
