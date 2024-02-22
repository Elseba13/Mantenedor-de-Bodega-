using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mantenedor_de_bodega.Migrations
{
    /// <inheritdoc />
    public partial class migracion41 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudDePedido_Articulos_ArticuloIdArticulo",
                table: "SolicitudDePedido");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudDePedido_Usuarios_UsuarioIdUsuario",
                table: "SolicitudDePedido");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolicitudDePedido",
                table: "SolicitudDePedido");

            migrationBuilder.RenameTable(
                name: "SolicitudDePedido",
                newName: "SolicitudDePedidos");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitudDePedido_UsuarioIdUsuario",
                table: "SolicitudDePedidos",
                newName: "IX_SolicitudDePedidos_UsuarioIdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitudDePedido_ArticuloIdArticulo",
                table: "SolicitudDePedidos",
                newName: "IX_SolicitudDePedidos_ArticuloIdArticulo");

            migrationBuilder.AddColumn<string>(
                name: "TipoDeSolicitud",
                table: "SolicitudDePedidos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolicitudDePedidos",
                table: "SolicitudDePedidos",
                column: "IdPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudDePedidos_Articulos_ArticuloIdArticulo",
                table: "SolicitudDePedidos",
                column: "ArticuloIdArticulo",
                principalTable: "Articulos",
                principalColumn: "IdArticulo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudDePedidos_Usuarios_UsuarioIdUsuario",
                table: "SolicitudDePedidos",
                column: "UsuarioIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudDePedidos_Articulos_ArticuloIdArticulo",
                table: "SolicitudDePedidos");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudDePedidos_Usuarios_UsuarioIdUsuario",
                table: "SolicitudDePedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolicitudDePedidos",
                table: "SolicitudDePedidos");

            migrationBuilder.DropColumn(
                name: "TipoDeSolicitud",
                table: "SolicitudDePedidos");

            migrationBuilder.RenameTable(
                name: "SolicitudDePedidos",
                newName: "SolicitudDePedido");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitudDePedidos_UsuarioIdUsuario",
                table: "SolicitudDePedido",
                newName: "IX_SolicitudDePedido_UsuarioIdUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_SolicitudDePedidos_ArticuloIdArticulo",
                table: "SolicitudDePedido",
                newName: "IX_SolicitudDePedido_ArticuloIdArticulo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolicitudDePedido",
                table: "SolicitudDePedido",
                column: "IdPedido");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudDePedido_Articulos_ArticuloIdArticulo",
                table: "SolicitudDePedido",
                column: "ArticuloIdArticulo",
                principalTable: "Articulos",
                principalColumn: "IdArticulo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudDePedido_Usuarios_UsuarioIdUsuario",
                table: "SolicitudDePedido",
                column: "UsuarioIdUsuario",
                principalTable: "Usuarios",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
