using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiLibrary.Migrations
{
    public partial class FloatPromedio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "PromedioCalificacion",
                table: "Libros",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PromedioCalificacion",
                table: "Libros",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }
    }
}
