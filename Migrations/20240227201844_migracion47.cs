using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mantenedor_de_bodega.Migrations
{
    /// <inheritdoc />
    public partial class migracion47 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripción",
                table: "ArancelCentros");

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "ArancelCentros",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "ArancelCentros");

            migrationBuilder.AddColumn<string>(
                name: "Descripción",
                table: "ArancelCentros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
