using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mantenedor_de_bodega.Migrations
{
    /// <inheritdoc />
    public partial class migracion8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sucursal",
                table: "Bodegas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sucursal",
                table: "Bodegas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
