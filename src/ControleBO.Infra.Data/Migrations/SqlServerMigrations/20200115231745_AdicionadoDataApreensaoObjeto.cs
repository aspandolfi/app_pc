using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleBO.Infra.Data.Migrations.SqlServerMigrations
{
    public partial class AdicionadoDataApreensaoObjeto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataApreensao",
                table: "ObjetosApreendidos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataApreensao",
                table: "ObjetosApreendidos");
        }
    }
}
