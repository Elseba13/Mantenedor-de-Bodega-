using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mantenedor_de_bodega.Migrations
{
    /// <inheritdoc />
    public partial class migracion21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_MovimientosInventarios_MovimientosInventarioIdMovimiento",
                table: "Articulos");

            migrationBuilder.DropForeignKey(
                name: "FK_Bodegas_MovimientosInventarios_MovimientosInventarioIdMovimiento",
                table: "Bodegas");

            migrationBuilder.DropForeignKey(
                name: "FK_Motivos_MovimientosInventarios_MovimientosInventarioIdMovimiento",
                table: "Motivos");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_MovimientosInventarios_MovimientosInventarioIdMovimiento",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Inventarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_MovimientosInventarioIdMovimiento",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Motivos_MovimientosInventarioIdMovimiento",
                table: "Motivos");

            migrationBuilder.DropIndex(
                name: "IX_Bodegas_MovimientosInventarioIdMovimiento",
                table: "Bodegas");

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
                name: "MovimientosInventarioIdMovimiento",
                table: "Bodegas");

            migrationBuilder.DropColumn(
                name: "MovimientosInventarioIdMovimiento",
                table: "Articulos");

            migrationBuilder.AddColumn<int>(
                name: "ArticuloIdArticulo",
                table: "MovimientosInventarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BodegaDeOrigenCodigoBodega",
                table: "MovimientosInventarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BodegaDestinoCodigoBodega",
                table: "MovimientosInventarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MotivoIdMotivo",
                table: "MovimientosInventarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioIdUsuario",
                table: "MovimientosInventarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BodegaCodigoBodega",
                table: "Articulos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockActual",
                table: "Articulos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockInical",
                table: "Articulos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosInventarios_ArticuloIdArticulo",
                table: "MovimientosInventarios",
                column: "ArticuloIdArticulo");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosInventarios_BodegaDeOrigenCodigoBodega",
                table: "MovimientosInventarios",
                column: "BodegaDeOrigenCodigoBodega");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosInventarios_BodegaDestinoCodigoBodega",
                table: "MovimientosInventarios",
                column: "BodegaDestinoCodigoBodega");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosInventarios_MotivoIdMotivo",
                table: "MovimientosInventarios",
                column: "MotivoIdMotivo");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosInventarios_UsuarioIdUsuario",
                table: "MovimientosInventarios",
                column: "UsuarioIdUsuario");

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

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosInventarios_Articulos_ArticuloIdArticulo",
                table: "MovimientosInventarios",
                column: "ArticuloIdArticulo",
                principalTable: "Articulos",
                principalColumn: "IdArticulo",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosInventarios_Bodegas_BodegaDeOrigenCodigoBodega",
                table: "MovimientosInventarios",
                column: "BodegaDeOrigenCodigoBodega",
                principalTable: "Bodegas",
                principalColumn: "CodigoBodega",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosInventarios_Bodegas_BodegaDestinoCodigoBodega",
                table: "MovimientosInventarios",
                column: "BodegaDestinoCodigoBodega",
                principalTable: "Bodegas",
                principalColumn: "CodigoBodega",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosInventarios_Motivos_MotivoIdMotivo",
                table: "MovimientosInventarios",
                column: "MotivoIdMotivo",
                principalTable: "Motivos",
                principalColumn: "IdMotivo",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosInventarios_Usuarios_UsuarioIdUsuario",
                table: "MovimientosInventarios",
                column: "UsuarioIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Bodegas_BodegaCodigoBodega",
                table: "Articulos");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosInventarios_Articulos_ArticuloIdArticulo",
                table: "MovimientosInventarios");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosInventarios_Bodegas_BodegaDeOrigenCodigoBodega",
                table: "MovimientosInventarios");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosInventarios_Bodegas_BodegaDestinoCodigoBodega",
                table: "MovimientosInventarios");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosInventarios_Motivos_MotivoIdMotivo",
                table: "MovimientosInventarios");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosInventarios_Usuarios_UsuarioIdUsuario",
                table: "MovimientosInventarios");

            migrationBuilder.DropIndex(
                name: "IX_MovimientosInventarios_ArticuloIdArticulo",
                table: "MovimientosInventarios");

            migrationBuilder.DropIndex(
                name: "IX_MovimientosInventarios_BodegaDeOrigenCodigoBodega",
                table: "MovimientosInventarios");

            migrationBuilder.DropIndex(
                name: "IX_MovimientosInventarios_BodegaDestinoCodigoBodega",
                table: "MovimientosInventarios");

            migrationBuilder.DropIndex(
                name: "IX_MovimientosInventarios_MotivoIdMotivo",
                table: "MovimientosInventarios");

            migrationBuilder.DropIndex(
                name: "IX_MovimientosInventarios_UsuarioIdUsuario",
                table: "MovimientosInventarios");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_BodegaCodigoBodega",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "ArticuloIdArticulo",
                table: "MovimientosInventarios");

            migrationBuilder.DropColumn(
                name: "BodegaDeOrigenCodigoBodega",
                table: "MovimientosInventarios");

            migrationBuilder.DropColumn(
                name: "BodegaDestinoCodigoBodega",
                table: "MovimientosInventarios");

            migrationBuilder.DropColumn(
                name: "MotivoIdMotivo",
                table: "MovimientosInventarios");

            migrationBuilder.DropColumn(
                name: "UsuarioIdUsuario",
                table: "MovimientosInventarios");

            migrationBuilder.DropColumn(
                name: "BodegaCodigoBodega",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "StockActual",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "StockInical",
                table: "Articulos");

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
                name: "MovimientosInventarioIdMovimiento",
                table: "Bodegas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovimientosInventarioIdMovimiento",
                table: "Articulos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Inventarios",
                columns: table => new
                {
                    IdInventario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bodegaCodigoBodega = table.Column<int>(type: "int", nullable: false),
                    ArticulosIdArticulo = table.Column<int>(type: "int", nullable: true),
                    StockActual = table.Column<int>(type: "int", nullable: false),
                    StockInicial = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventarios", x => x.IdInventario);
                    table.ForeignKey(
                        name: "FK_Inventarios_Articulos_ArticulosIdArticulo",
                        column: x => x.ArticulosIdArticulo,
                        principalTable: "Articulos",
                        principalColumn: "IdArticulo");
                    table.ForeignKey(
                        name: "FK_Inventarios_Bodegas_bodegaCodigoBodega",
                        column: x => x.bodegaCodigoBodega,
                        principalTable: "Bodegas",
                        principalColumn: "CodigoBodega",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_MovimientosInventarioIdMovimiento",
                table: "Usuarios",
                column: "MovimientosInventarioIdMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_Motivos_MovimientosInventarioIdMovimiento",
                table: "Motivos",
                column: "MovimientosInventarioIdMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_Bodegas_MovimientosInventarioIdMovimiento",
                table: "Bodegas",
                column: "MovimientosInventarioIdMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_MovimientosInventarioIdMovimiento",
                table: "Articulos",
                column: "MovimientosInventarioIdMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_ArticulosIdArticulo",
                table: "Inventarios",
                column: "ArticulosIdArticulo");

            migrationBuilder.CreateIndex(
                name: "IX_Inventarios_bodegaCodigoBodega",
                table: "Inventarios",
                column: "bodegaCodigoBodega");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_MovimientosInventarios_MovimientosInventarioIdMovimiento",
                table: "Articulos",
                column: "MovimientosInventarioIdMovimiento",
                principalTable: "MovimientosInventarios",
                principalColumn: "IdMovimiento");

            migrationBuilder.AddForeignKey(
                name: "FK_Bodegas_MovimientosInventarios_MovimientosInventarioIdMovimiento",
                table: "Bodegas",
                column: "MovimientosInventarioIdMovimiento",
                principalTable: "MovimientosInventarios",
                principalColumn: "IdMovimiento");

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
    }
}
