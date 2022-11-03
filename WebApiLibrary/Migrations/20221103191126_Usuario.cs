using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiLibrary.Migrations
{
    public partial class Usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AutorUsuario",
                columns: table => new
                {
                    SuscripcionesId = table.Column<int>(type: "int", nullable: false),
                    UsuariosSuscritosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorUsuario", x => new { x.SuscripcionesId, x.UsuariosSuscritosId });
                    table.ForeignKey(
                        name: "FK_AutorUsuario_Autores_SuscripcionesId",
                        column: x => x.SuscripcionesId,
                        principalTable: "Autores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutorUsuario_Usuarios_UsuariosSuscritosId",
                        column: x => x.UsuariosSuscritosId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutorUsuario_UsuariosSuscritosId",
                table: "AutorUsuario",
                column: "UsuariosSuscritosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutorUsuario");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
