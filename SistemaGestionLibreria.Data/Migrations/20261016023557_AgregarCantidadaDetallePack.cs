using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaGestionLibreria.Data.Migrations
{
    /// <inheritdoc />
    public partial class AgregarCantidadaDetallePack : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "DetallesPack",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "DetallesPack");
        }
    }
}
