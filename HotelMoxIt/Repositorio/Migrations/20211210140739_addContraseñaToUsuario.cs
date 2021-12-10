using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositorio.Migrations
{
    public partial class addContraseñaToUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contraseña",
                table: "Usuario",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contraseña",
                table: "Usuario");
        }
    }
}
