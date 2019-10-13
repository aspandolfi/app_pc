using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleBO.Infra.Data.Migrations.SqlServerMigrations
{
    public partial class AdicionadoIndexVitimasIndiciados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Vitimas_Nome",
                table: "Vitimas",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_Indiciados_Nome",
                table: "Indiciados",
                column: "Nome");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vitimas_Nome",
                table: "Vitimas");

            migrationBuilder.DropIndex(
                name: "IX_Indiciados_Nome",
                table: "Indiciados");
        }
    }
}
