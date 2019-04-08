using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ControleBO.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artigos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    ModificadoEm = table.Column<DateTime>(nullable: false),
                    RemovidoEm = table.Column<DateTime>(nullable: true),
                    Versao = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artigos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assuntos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    ModificadoEm = table.Column<DateTime>(nullable: false),
                    RemovidoEm = table.Column<DateTime>(nullable: true),
                    Versao = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assuntos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    ModificadoEm = table.Column<DateTime>(nullable: false),
                    RemovidoEm = table.Column<DateTime>(nullable: true),
                    Versao = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(type: "varchar", maxLength: 200, nullable: false),
                    UF = table.Column<string>(type: "varchar", maxLength: 2, nullable: false),
                    CEP = table.Column<string>(type: "varchar", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Situacoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    ModificadoEm = table.Column<DateTime>(nullable: false),
                    RemovidoEm = table.Column<DateTime>(nullable: true),
                    Versao = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Situacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposProcedimento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    ModificadoEm = table.Column<DateTime>(nullable: false),
                    RemovidoEm = table.Column<DateTime>(nullable: true),
                    Versao = table.Column<int>(nullable: false),
                    Sigla = table.Column<string>(type: "varchar", maxLength: 10, nullable: true),
                    Descricao = table.Column<string>(type: "varchar", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposProcedimento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnidadesPolicia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    ModificadoEm = table.Column<DateTime>(nullable: false),
                    RemovidoEm = table.Column<DateTime>(nullable: true),
                    Versao = table.Column<int>(nullable: false),
                    Codigo = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    Sigla = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    Descricao = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    CodigoCargoQO = table.Column<string>(type: "varchar", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesPolicia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VarasCriminais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    ModificadoEm = table.Column<DateTime>(nullable: false),
                    RemovidoEm = table.Column<DateTime>(nullable: true),
                    Versao = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VarasCriminais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposSituacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    ModificadoEm = table.Column<DateTime>(nullable: false),
                    RemovidoEm = table.Column<DateTime>(nullable: true),
                    Versao = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    SituacaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposSituacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiposSituacao_Situacoes_SituacaoId",
                        column: x => x.SituacaoId,
                        principalTable: "Situacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Procedimentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    ModificadoEm = table.Column<DateTime>(nullable: false),
                    RemovidoEm = table.Column<DateTime>(nullable: true),
                    Versao = table.Column<int>(nullable: false),
                    BoletimUnificado = table.Column<string>(type: "varchar", maxLength: 30, nullable: false),
                    BoletimOcorrencia = table.Column<string>(type: "varchar", maxLength: 30, nullable: false),
                    NumeroProcessual = table.Column<string>(type: "varchar", maxLength: 30, nullable: false),
                    Gampes = table.Column<string>(type: "varchar", maxLength: 30, nullable: false),
                    Anexos = table.Column<string>(type: "varchar", nullable: true),
                    LocalFato = table.Column<string>(type: "varchar", maxLength: 30, nullable: false),
                    DataFato = table.Column<DateTime>(nullable: false),
                    DataInstauracao = table.Column<DateTime>(nullable: true),
                    TipoCriminal = table.Column<string>(type: "varchar", maxLength: 100, nullable: true),
                    AndamentoProcessual = table.Column<string>(type: "varchar", maxLength: 100, nullable: true),
                    TipoProcedimentoId = table.Column<int>(nullable: false),
                    VaraCriminalId = table.Column<int>(nullable: false),
                    ComarcaId = table.Column<int>(nullable: false),
                    AssuntoId = table.Column<int>(nullable: false),
                    ArtigoId = table.Column<int>(nullable: false),
                    DelegaciaOrigemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Procedimentos_Artigos_ArtigoId",
                        column: x => x.ArtigoId,
                        principalTable: "Artigos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Procedimentos_Assuntos_AssuntoId",
                        column: x => x.AssuntoId,
                        principalTable: "Assuntos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Procedimentos_Municipios_ComarcaId",
                        column: x => x.ComarcaId,
                        principalTable: "Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Procedimentos_UnidadesPolicia_DelegaciaOrigemId",
                        column: x => x.DelegaciaOrigemId,
                        principalTable: "UnidadesPolicia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Procedimentos_TiposProcedimento_TipoProcedimentoId",
                        column: x => x.TipoProcedimentoId,
                        principalTable: "TiposProcedimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Procedimentos_VarasCriminais_VaraCriminalId",
                        column: x => x.VaraCriminalId,
                        principalTable: "VarasCriminais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoSituacaoProcedimentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    ModificadoEm = table.Column<DateTime>(nullable: false),
                    RemovidoEm = table.Column<DateTime>(nullable: true),
                    Versao = table.Column<int>(nullable: false),
                    ProcedimentoId = table.Column<int>(nullable: false),
                    SituacaoId = table.Column<int>(nullable: false),
                    SituacaoTipoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoSituacaoProcedimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricoSituacaoProcedimentos_Procedimentos_ProcedimentoId",
                        column: x => x.ProcedimentoId,
                        principalTable: "Procedimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoSituacaoProcedimentos_Situacoes_SituacaoId",
                        column: x => x.SituacaoId,
                        principalTable: "Situacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricoSituacaoProcedimentos_TiposSituacao_SituacaoTipoId",
                        column: x => x.SituacaoTipoId,
                        principalTable: "TiposSituacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Indiciados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    ModificadoEm = table.Column<DateTime>(nullable: false),
                    RemovidoEm = table.Column<DateTime>(nullable: true),
                    Versao = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    NomePai = table.Column<string>(nullable: true),
                    NomeMae = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: true),
                    Idade = table.Column<int>(nullable: true),
                    MenorIdade = table.Column<bool>(nullable: false),
                    Telefone = table.Column<string>(nullable: true),
                    NaturalidadeId = table.Column<int>(nullable: true),
                    Apelido = table.Column<string>(type: "varchar", maxLength: 100, nullable: true),
                    ProcedimentoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indiciados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Indiciados_Municipios_NaturalidadeId",
                        column: x => x.NaturalidadeId,
                        principalTable: "Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Indiciados_Procedimentos_ProcedimentoId",
                        column: x => x.ProcedimentoId,
                        principalTable: "Procedimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Movimentacoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    ModificadoEm = table.Column<DateTime>(nullable: false),
                    RemovidoEm = table.Column<DateTime>(nullable: true),
                    Versao = table.Column<int>(nullable: false),
                    Destino = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    RetornouEm = table.Column<DateTime>(nullable: true),
                    ProcedimentoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Procedimentos_ProcedimentoId",
                        column: x => x.ProcedimentoId,
                        principalTable: "Procedimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ObjetosApreendidos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    ModificadoEm = table.Column<DateTime>(nullable: false),
                    RemovidoEm = table.Column<DateTime>(nullable: true),
                    Versao = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(type: "varchar", maxLength: 250, nullable: false),
                    Local = table.Column<string>(type: "varchar", maxLength: 250, nullable: true),
                    ProcedimentoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjetosApreendidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjetosApreendidos_Procedimentos_ProcedimentoId",
                        column: x => x.ProcedimentoId,
                        principalTable: "Procedimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vitimas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    ModificadoEm = table.Column<DateTime>(nullable: false),
                    RemovidoEm = table.Column<DateTime>(nullable: true),
                    Versao = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    NomePai = table.Column<string>(nullable: true),
                    NomeMae = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: true),
                    Idade = table.Column<int>(nullable: true),
                    MenorIdade = table.Column<bool>(nullable: false),
                    Telefone = table.Column<string>(nullable: true),
                    NaturalidadeId = table.Column<int>(nullable: true),
                    Email = table.Column<string>(type: "varchar", maxLength: 100, nullable: true),
                    ProcedimentoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vitimas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vitimas_Municipios_NaturalidadeId",
                        column: x => x.NaturalidadeId,
                        principalTable: "Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vitimas_Procedimentos_ProcedimentoId",
                        column: x => x.ProcedimentoId,
                        principalTable: "Procedimentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoSituacaoProcedimentos_ProcedimentoId",
                table: "HistoricoSituacaoProcedimentos",
                column: "ProcedimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoSituacaoProcedimentos_SituacaoId",
                table: "HistoricoSituacaoProcedimentos",
                column: "SituacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoSituacaoProcedimentos_SituacaoTipoId",
                table: "HistoricoSituacaoProcedimentos",
                column: "SituacaoTipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Indiciados_NaturalidadeId",
                table: "Indiciados",
                column: "NaturalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Indiciados_ProcedimentoId",
                table: "Indiciados",
                column: "ProcedimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_ProcedimentoId",
                table: "Movimentacoes",
                column: "ProcedimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjetosApreendidos_ProcedimentoId",
                table: "ObjetosApreendidos",
                column: "ProcedimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedimentos_ArtigoId",
                table: "Procedimentos",
                column: "ArtigoId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedimentos_AssuntoId",
                table: "Procedimentos",
                column: "AssuntoId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedimentos_ComarcaId",
                table: "Procedimentos",
                column: "ComarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedimentos_DelegaciaOrigemId",
                table: "Procedimentos",
                column: "DelegaciaOrigemId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedimentos_TipoProcedimentoId",
                table: "Procedimentos",
                column: "TipoProcedimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Procedimentos_VaraCriminalId",
                table: "Procedimentos",
                column: "VaraCriminalId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposSituacao_SituacaoId",
                table: "TiposSituacao",
                column: "SituacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vitimas_NaturalidadeId",
                table: "Vitimas",
                column: "NaturalidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Vitimas_ProcedimentoId",
                table: "Vitimas",
                column: "ProcedimentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoricoSituacaoProcedimentos");

            migrationBuilder.DropTable(
                name: "Indiciados");

            migrationBuilder.DropTable(
                name: "Movimentacoes");

            migrationBuilder.DropTable(
                name: "ObjetosApreendidos");

            migrationBuilder.DropTable(
                name: "Vitimas");

            migrationBuilder.DropTable(
                name: "TiposSituacao");

            migrationBuilder.DropTable(
                name: "Procedimentos");

            migrationBuilder.DropTable(
                name: "Situacoes");

            migrationBuilder.DropTable(
                name: "Artigos");

            migrationBuilder.DropTable(
                name: "Assuntos");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "UnidadesPolicia");

            migrationBuilder.DropTable(
                name: "TiposProcedimento");

            migrationBuilder.DropTable(
                name: "VarasCriminais");
        }
    }
}
