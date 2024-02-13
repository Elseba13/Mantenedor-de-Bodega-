using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mantenedor_de_bodega.Migrations
{
    /// <inheritdoc />
    public partial class migration13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CentroDeSaluds_Bodegas_BodegaCodigoBodega",
                table: "CentroDeSaluds");

            migrationBuilder.DropIndex(
                name: "IX_CentroDeSaluds_BodegaCodigoBodega",
                table: "CentroDeSaluds");

            migrationBuilder.DropColumn(
                name: "BodegaCodigoBodega",
                table: "CentroDeSaluds");

            migrationBuilder.AddColumn<int>(
                name: "CentroDeSalud",
                table: "Bodegas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CentroDeSaludsCodigoCentroSalud",
                table: "Bodegas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bodegas_CentroDeSaludsCodigoCentroSalud",
                table: "Bodegas",
                column: "CentroDeSaludsCodigoCentroSalud");

            migrationBuilder.AddForeignKey(
                name: "FK_Bodegas_CentroDeSaluds_CentroDeSaludsCodigoCentroSalud",
                table: "Bodegas",
                column: "CentroDeSaludsCodigoCentroSalud",
                principalTable: "CentroDeSaluds",
                principalColumn: "CodigoCentroSalud",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bodegas_CentroDeSaluds_CentroDeSaludsCodigoCentroSalud",
                table: "Bodegas");

            migrationBuilder.DropIndex(
                name: "IX_Bodegas_CentroDeSaludsCodigoCentroSalud",
                table: "Bodegas");

            migrationBuilder.DropColumn(
                name: "CentroDeSalud",
                table: "Bodegas");

            migrationBuilder.DropColumn(
                name: "CentroDeSaludsCodigoCentroSalud",
                table: "Bodegas");

            migrationBuilder.AddColumn<int>(
                name: "BodegaCodigoBodega",
                table: "CentroDeSaluds",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CentroDeSaluds_BodegaCodigoBodega",
                table: "CentroDeSaluds",
                column: "BodegaCodigoBodega");

            migrationBuilder.AddForeignKey(
                name: "FK_CentroDeSaluds_Bodegas_BodegaCodigoBodega",
                table: "CentroDeSaluds",
                column: "BodegaCodigoBodega",
                principalTable: "Bodegas",
                principalColumn: "CodigoBodega");
        }
    }
}
