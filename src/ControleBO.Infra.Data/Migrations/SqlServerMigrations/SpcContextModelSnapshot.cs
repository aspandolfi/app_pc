﻿// <auto-generated />
using System;
using ControleBO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControleBO.Infra.Data.Migrations.SqlServerMigrations
{
    [DbContext(typeof(SpcContext))]
    partial class SpcContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ControleBO.Domain.Models.Artigo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CriadoEm");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("ModificadoEm");

                    b.Property<DateTime?>("RemovidoEm");

                    b.Property<int>("Versao");

                    b.HasKey("Id");

                    b.ToTable("Artigos");
                });

            modelBuilder.Entity("ControleBO.Domain.Models.Assunto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CriadoEm");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("ModificadoEm");

                    b.Property<DateTime?>("RemovidoEm");

                    b.Property<int>("Versao");

                    b.HasKey("Id");

                    b.ToTable("Assuntos");
                });

            modelBuilder.Entity("ControleBO.Domain.Models.Indiciado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apelido")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("CriadoEm");

                    b.Property<DateTime?>("DataNascimento");

                    b.Property<int?>("Idade");

                    b.Property<bool>("MenorIdade");

                    b.Property<DateTime>("ModificadoEm");

                    b.Property<int?>("NaturalidadeId");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("NomeMae")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("NomePai")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("ProcedimentoId");

                    b.Property<DateTime?>("RemovidoEm");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("Versao");

                    b.HasKey("Id");

                    b.HasIndex("NaturalidadeId");

                    b.HasIndex("Nome");

                    b.HasIndex("ProcedimentoId");

                    b.ToTable("Indiciados");
                });

            modelBuilder.Entity("ControleBO.Domain.Models.Movimentacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CriadoEm");

                    b.Property<DateTime>("Data");

                    b.Property<string>("Destino")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("ModificadoEm");

                    b.Property<int>("ProcedimentoId");

                    b.Property<DateTime?>("RemovidoEm");

                    b.Property<DateTime?>("RetornouEm");

                    b.Property<int>("Versao");

                    b.HasKey("Id");

                    b.HasIndex("ProcedimentoId");

                    b.ToTable("Movimentacoes");
                });

            modelBuilder.Entity("ControleBO.Domain.Models.Municipio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CEP")
                        .HasColumnType("varchar(9)")
                        .HasMaxLength(9);

                    b.Property<DateTime>("CriadoEm");

                    b.Property<DateTime>("ModificadoEm");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime?>("RemovidoEm");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("varchar(2)")
                        .HasMaxLength(2);

                    b.Property<int>("Versao");

                    b.HasKey("Id");

                    b.ToTable("Municipios");
                });

            modelBuilder.Entity("ControleBO.Domain.Models.ObjetoApreendido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CriadoEm");

                    b.Property<DateTime?>("DataApreensao");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Local")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<DateTime>("ModificadoEm");

                    b.Property<int>("ProcedimentoId");

                    b.Property<DateTime?>("RemovidoEm");

                    b.Property<int>("Versao");

                    b.HasKey("Id");

                    b.HasIndex("ProcedimentoId");

                    b.ToTable("ObjetosApreendidos");
                });

            modelBuilder.Entity("ControleBO.Domain.Models.Procedimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AndamentoProcessual")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Anexos")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<int?>("ArtigoId");

                    b.Property<int?>("AssuntoId");

                    b.Property<string>("BoletimOcorrencia")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("BoletimUnificado")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<int?>("ComarcaId");

                    b.Property<DateTime>("CriadoEm");

                    b.Property<DateTime?>("DataFato");

                    b.Property<DateTime?>("DataInstauracao");

                    b.Property<int?>("DelegaciaOrigemId");

                    b.Property<string>("Gampes")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("LocalFato")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<DateTime>("ModificadoEm");

                    b.Property<string>("NumeroProcessual")
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30);

                    b.Property<DateTime?>("RemovidoEm");

                    b.Property<int>("SituacaoAtualId");

                    b.Property<int?>("TipoProcedimentoId");

                    b.Property<int?>("VaraCriminalId");

                    b.Property<int>("Versao");

                    b.HasKey("Id");

                    b.HasIndex("ArtigoId");

                    b.HasIndex("AssuntoId");

                    b.HasIndex("ComarcaId");

                    b.HasIndex("DelegaciaOrigemId");

                    b.HasIndex("SituacaoAtualId");

                    b.HasIndex("TipoProcedimentoId");

                    b.HasIndex("VaraCriminalId");

                    b.ToTable("Procedimentos");
                });

            modelBuilder.Entity("ControleBO.Domain.Models.ProcedimentoTipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CriadoEm");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("ModificadoEm");

                    b.Property<DateTime?>("RemovidoEm");

                    b.Property<string>("Sigla")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10);

                    b.Property<int>("Versao");

                    b.HasKey("Id");

                    b.ToTable("TiposProcedimento");
                });

            modelBuilder.Entity("ControleBO.Domain.Models.Situacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<DateTime>("CriadoEm");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("ModificadoEm");

                    b.Property<DateTime?>("RemovidoEm");

                    b.Property<int>("Versao");

                    b.HasKey("Id");

                    b.ToTable("Situacoes");
                });

            modelBuilder.Entity("ControleBO.Domain.Models.SituacaoProcedimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CriadoEm");

                    b.Property<DateTime?>("DataRelatorio");

                    b.Property<DateTime>("ModificadoEm");

                    b.Property<string>("Observacao")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("ProcedimentoId");

                    b.Property<DateTime?>("RemovidoEm");

                    b.Property<int>("SituacaoId");

                    b.Property<int?>("SituacaoTipoId");

                    b.Property<int>("Versao");

                    b.HasKey("Id");

                    b.HasIndex("ProcedimentoId");

                    b.HasIndex("SituacaoId");

                    b.HasIndex("SituacaoTipoId");

                    b.ToTable("HistoricoSituacaoProcedimentos");
                });

            modelBuilder.Entity("ControleBO.Domain.Models.SituacaoTipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CriadoEm");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("ModificadoEm");

                    b.Property<DateTime?>("RemovidoEm");

                    b.Property<int>("SituacaoId");

                    b.Property<int>("Versao");

                    b.HasKey("Id");

                    b.HasIndex("SituacaoId");

                    b.ToTable("TiposSituacao");
                });

            modelBuilder.Entity("ControleBO.Domain.Models.UnidadePolicial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CodigoCargoQO")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("CriadoEm");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("ModificadoEm");

                    b.Property<DateTime?>("RemovidoEm");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("Versao");

                    b.HasKey("Id");

                    b.ToTable("UnidadesPolicia");
                });

            modelBuilder.Entity("ControleBO.Domain.Models.VaraCriminal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CriadoEm");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("ModificadoEm");

                    b.Property<DateTime?>("RemovidoEm");

                    b.Property<int>("Versao");

                    b.HasKey("Id");

                    b.ToTable("VarasCriminais");
                });

            modelBuilder.Entity("ControleBO.Domain.Models.Vitima", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CriadoEm");

                    b.Property<DateTime?>("DataNascimento");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<int?>("Idade");

                    b.Property<bool>("MenorIdade");

                    b.Property<DateTime>("ModificadoEm");

                    b.Property<int?>("NaturalidadeId");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("NomeMae")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("NomePai")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("ProcedimentoId");

                    b.Property<DateTime?>("RemovidoEm");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("Versao");

                    b.HasKey("Id");

                    b.HasIndex("NaturalidadeId");

                    b.HasIndex("Nome");

                    b.HasIndex("ProcedimentoId");

                    b.ToTable("Vitimas");
                });

            modelBuilder.Entity("ControleBO.Domain.Models.Indiciado", b =>
                {
                    b.HasOne("ControleBO.Domain.Models.Municipio", "Naturalidade")
                        .WithMany()
                        .HasForeignKey("NaturalidadeId");

                    b.HasOne("ControleBO.Domain.Models.Procedimento", "Procedimento")
                        .WithMany("Autores")
                        .HasForeignKey("ProcedimentoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ControleBO.Domain.Models.Movimentacao", b =>
                {
                    b.HasOne("ControleBO.Domain.Models.Procedimento", "Procedimento")
                        .WithMany("HistoricoMovimentacoes")
                        .HasForeignKey("ProcedimentoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ControleBO.Domain.Models.ObjetoApreendido", b =>
                {
                    b.HasOne("ControleBO.Domain.Models.Procedimento", "Procedimento")
                        .WithMany("ObjetosApreendidos")
                        .HasForeignKey("ProcedimentoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ControleBO.Domain.Models.Procedimento", b =>
                {
                    b.HasOne("ControleBO.Domain.Models.Artigo", "Artigo")
                        .WithMany()
                        .HasForeignKey("ArtigoId");

                    b.HasOne("ControleBO.Domain.Models.Assunto", "Assunto")
                        .WithMany()
                        .HasForeignKey("AssuntoId");

                    b.HasOne("ControleBO.Domain.Models.Municipio", "Comarca")
                        .WithMany()
                        .HasForeignKey("ComarcaId");

                    b.HasOne("ControleBO.Domain.Models.UnidadePolicial", "DelegaciaOrigem")
                        .WithMany()
                        .HasForeignKey("DelegaciaOrigemId");

                    b.HasOne("ControleBO.Domain.Models.Situacao", "SituacaoAtual")
                        .WithMany()
                        .HasForeignKey("SituacaoAtualId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ControleBO.Domain.Models.ProcedimentoTipo", "TipoProcedimento")
                        .WithMany()
                        .HasForeignKey("TipoProcedimentoId");

                    b.HasOne("ControleBO.Domain.Models.VaraCriminal", "VaraCriminal")
                        .WithMany()
                        .HasForeignKey("VaraCriminalId");
                });

            modelBuilder.Entity("ControleBO.Domain.Models.SituacaoProcedimento", b =>
                {
                    b.HasOne("ControleBO.Domain.Models.Procedimento", "Procedimento")
                        .WithMany("HistoricoSituacoes")
                        .HasForeignKey("ProcedimentoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ControleBO.Domain.Models.Situacao", "Situacao")
                        .WithMany()
                        .HasForeignKey("SituacaoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ControleBO.Domain.Models.SituacaoTipo", "SituacaoTipo")
                        .WithMany()
                        .HasForeignKey("SituacaoTipoId");
                });

            modelBuilder.Entity("ControleBO.Domain.Models.SituacaoTipo", b =>
                {
                    b.HasOne("ControleBO.Domain.Models.Situacao", "Situacao")
                        .WithMany("Tipos")
                        .HasForeignKey("SituacaoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ControleBO.Domain.Models.Vitima", b =>
                {
                    b.HasOne("ControleBO.Domain.Models.Municipio", "Naturalidade")
                        .WithMany()
                        .HasForeignKey("NaturalidadeId");

                    b.HasOne("ControleBO.Domain.Models.Procedimento", "Procedimento")
                        .WithMany("Vitimas")
                        .HasForeignKey("ProcedimentoId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
