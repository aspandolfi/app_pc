using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleBO.Infra.Data.Migrations.SqlServerMigrations
{
    public partial class AdicionadoViewToProcedimentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"
                            CREATE VIEW ProcedimentosListView
                            AS
                            SELECT P.ID
	                              ,P.BoletimUnificado
	                              ,P.BoletimOcorrencia
	                              ,P.NumeroProcessual
	                              ,P.CriadoEm as DataInsercao
	                              ,TP.Descricao as TipoProcedimento
	                              ,C.Nome as Comarca
	                              ,(SELECT TOP(1) M.Destino 
		                            FROM Movimentacoes AS M 
		                            WHERE M.ProcedimentoId = P.Id 
		                            ORDER BY M.ModificadoEm DESC) AS AndamentoProcessual
	                              ,SUBSTRING(
		                            (SELECT ', ' + NOME FROM VITIMAS WHERE P.ID = VITIMAS.PROCEDIMENTOID
		                            ORDER BY PROCEDIMENTOID, NOME
		                            FOR XML PATH('')), 3, 4000) AS Vitimas
                            FROM PROCEDIMENTOS AS P
                            LEFT JOIN TiposProcedimento AS TP on TP.Id = P.TipoProcedimentoId
                            LEFT JOIN Municipios AS C on C.Id = P.ComarcaId;";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sql = @"DROP VIEW IF EXISTS [dbo].[ProcedimentosListView];";

            migrationBuilder.Sql(sql);
        }
    }
}
