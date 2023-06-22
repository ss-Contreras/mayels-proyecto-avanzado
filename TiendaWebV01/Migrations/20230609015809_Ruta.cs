using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TiendaWebV01.Migrations
{
    public partial class Ruta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ruta",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ruta",
                table: "Productos");
        }
    }
}
