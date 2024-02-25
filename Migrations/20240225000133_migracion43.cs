using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mantenedor_de_bodega.Migrations
{
    /// <inheritdoc />
    public partial class migracion43 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventarios_Articulos_IdArticulos",
                table: "Inventarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventarios_Bodegas_CodigoBodega",
                table: "Inventarios");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosInventarios_Articulos_ArticuloIdArticulo",
                table: "MovimientosInventarios");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudDePedidos_Articulos_ArticuloIdArticulo",
                table: "SolicitudDePedidos");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.RenameColumn(
                name: "ArticuloIdArticulo",
                table: "SolicitudDePedidos",
                newName: "centroCodigoCentroSalud");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitudDePedidos_ArticuloIdArticulo",
                table: "SolicitudDePedidos",
                newName: "IX_SolicitudDePedidos_centroCodigoCentroSalud");

            migrationBuilder.RenameColumn(
                name: "ArticuloIdArticulo",
                table: "MovimientosInventarios",
                newName: "ArancelId");

            migrationBuilder.RenameIndex(
                name: "IX_MovimientosInventarios_ArticuloIdArticulo",
                table: "MovimientosInventarios",
                newName: "IX_MovimientosInventarios_ArancelId");

            migrationBuilder.RenameColumn(
                name: "IdArticulos",
                table: "Inventarios",
                newName: "IdArancel");

            migrationBuilder.AddColumn<int>(
                name: "arancelCentroId",
                table: "SolicitudDePedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaDeMovimiento",
                table: "MovimientosInventarios",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ArancelCentros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripción = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    centroDeSaludCodigoCentroSalud = table.Column<int>(type: "int", nullable: false),
                    EstaActivo = table.Column<bool>(type: "bit", nullable: false),
                    IdGrupo = table.Column<int>(type: "int", nullable: false),
                    IdSubGrupo = table.Column<int>(type: "int", nullable: false),
                    NombreFantasia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoArancel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArancelCentros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArancelCentros_CentroDeSaluds_centroDeSaludCodigoCentroSalud",
                        column: x => x.centroDeSaludCodigoCentroSalud,
                        principalTable: "CentroDeSaluds",
                        principalColumn: "CodigoCentroSalud",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudDePedidos_arancelCentroId",
                table: "SolicitudDePedidos",
                column: "arancelCentroId");

            migrationBuilder.CreateIndex(
                name: "IX_ArancelCentros_centroDeSaludCodigoCentroSalud",
                table: "ArancelCentros",
                column: "centroDeSaludCodigoCentroSalud");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventarios_ArancelCentros_IdArancel",
                table: "Inventarios",
                column: "IdArancel",
                principalTable: "ArancelCentros",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventarios_Bodegas_CodigoBodega",
                table: "Inventarios",
                column: "CodigoBodega",
                principalTable: "Bodegas",
                principalColumn: "CodigoBodega",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosInventarios_ArancelCentros_ArancelId",
                table: "MovimientosInventarios",
                column: "ArancelId",
                principalTable: "ArancelCentros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudDePedidos_ArancelCentros_arancelCentroId",
                table: "SolicitudDePedidos",
                column: "arancelCentroId",
                principalTable: "ArancelCentros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudDePedidos_CentroDeSaluds_centroCodigoCentroSalud",
                table: "SolicitudDePedidos",
                column: "centroCodigoCentroSalud",
                principalTable: "CentroDeSaluds",
                principalColumn: "CodigoCentroSalud",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventarios_ArancelCentros_IdArancel",
                table: "Inventarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventarios_Bodegas_CodigoBodega",
                table: "Inventarios");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosInventarios_ArancelCentros_ArancelId",
                table: "MovimientosInventarios");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudDePedidos_ArancelCentros_arancelCentroId",
                table: "SolicitudDePedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudDePedidos_CentroDeSaluds_centroCodigoCentroSalud",
                table: "SolicitudDePedidos");

            migrationBuilder.DropTable(
                name: "ArancelCentros");

            migrationBuilder.DropIndex(
                name: "IX_SolicitudDePedidos_arancelCentroId",
                table: "SolicitudDePedidos");

            migrationBuilder.DropColumn(
                name: "arancelCentroId",
                table: "SolicitudDePedidos");

            migrationBuilder.RenameColumn(
                name: "centroCodigoCentroSalud",
                table: "SolicitudDePedidos",
                newName: "ArticuloIdArticulo");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitudDePedidos_centroCodigoCentroSalud",
                table: "SolicitudDePedidos",
                newName: "IX_SolicitudDePedidos_ArticuloIdArticulo");

            migrationBuilder.RenameColumn(
                name: "ArancelId",
                table: "MovimientosInventarios",
                newName: "ArticuloIdArticulo");

            migrationBuilder.RenameIndex(
                name: "IX_MovimientosInventarios_ArancelId",
                table: "MovimientosInventarios",
                newName: "IX_MovimientosInventarios_ArticuloIdArticulo");

            migrationBuilder.RenameColumn(
                name: "IdArancel",
                table: "Inventarios",
                newName: "IdArticulos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaDeMovimiento",
                table: "MovimientosInventarios",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    IdArticulo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClasificacioArticulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreArticulo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.IdArticulo);
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosInventarios_Articulos_ArticuloIdArticulo",
                table: "MovimientosInventarios",
                column: "ArticuloIdArticulo",
                principalTable: "Articulos",
                principalColumn: "IdArticulo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudDePedidos_Articulos_ArticuloIdArticulo",
                table: "SolicitudDePedidos",
                column: "ArticuloIdArticulo",
                principalTable: "Articulos",
                principalColumn: "IdArticulo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
