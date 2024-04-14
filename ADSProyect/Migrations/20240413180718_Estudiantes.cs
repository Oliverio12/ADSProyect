﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADSProyect.Migrations
{
    /// <inheritdoc />
    public partial class Estudiantes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudiante",
                columns: table => new
                {
                    IdEstudiante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstudiante = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApellidoEstudiante = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CodigoEstudiante = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CorreoEstudiante = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiante", x => x.IdEstudiante);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estudiante");
        }
    }
}