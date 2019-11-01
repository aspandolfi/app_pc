using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ControleBO.Infra.Data.Migrations.SqlServerMigrations
{
    public partial class AdicionadoSituacaoOutros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Situacoes",
                new string[] { "CriadoEm", "ModificadoEm", "Versao", "Descricao" },
                new object[] { DateTime.Now, DateTime.Now, 0, "Outros" },
                "dbo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData("Situacoes", "Id", 4, "dbo");
        }
    }
}
