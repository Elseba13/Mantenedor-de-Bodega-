using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mantenedor_de_bodega.Migrations
{
    /// <inheritdoc />
    public partial class migracion36 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StockFinalBodegaDestino",
                table: "MovimientosInventarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockFinalBodegaOrigen",
                table: "MovimientosInventarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockInicialBodegaDestino",
                table: "MovimientosInventarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockInicialBodegaOrigen",
                table: "MovimientosInventarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockFinalBodegaDestino",
                table: "MovimientosInventarios");

            migrationBuilder.DropColumn(
                name: "StockFinalBodegaOrigen",
                table: "MovimientosInventarios");

            migrationBuilder.DropColumn(
                name: "StockInicialBodegaDestino",
                table: "MovimientosInventarios");

            migrationBuilder.DropColumn(
                name: "StockInicialBodegaOrigen",
                table: "MovimientosInventarios");
        }
    }
}
