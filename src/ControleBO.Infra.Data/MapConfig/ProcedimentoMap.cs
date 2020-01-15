using ControleBO.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleBO.Infra.Data.MapConfig
{
    public class ProcedimentoMap : IEntityTypeConfiguration<Procedimento>
    {
        public void Configure(EntityTypeBuilder<Procedimento> builder)
        {
            builder.ToTable("Procedimentos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.BoletimUnificado)
                .HasColumnType("varchar(30)")
                .HasMaxLength(30);

            builder.Property(x => x.BoletimOcorrencia)
                .HasColumnType("varchar(30)")
                .HasMaxLength(30);

            builder.Property(x => x.NumeroProcessual)
                .HasColumnType("varchar(30)")
                .HasMaxLength(30)
                .IsRequired(false);

            builder.Property(x => x.Gampes)
                .HasColumnType("varchar(30)")
                .HasMaxLength(30);

            builder.Property(x => x.LocalFato)
                .HasColumnType("varchar(30)")
                .HasMaxLength(30);

            builder.Property(x => x.DataFato);

            builder.Property(x => x.AndamentoProcessual)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.HasOne(x => x.TipoProcedimento)
                .WithMany()
                .HasForeignKey(x => x.TipoProcedimentoId)
                .IsRequired(false);

            builder.HasOne(x => x.VaraCriminal)
                .WithMany()
                .HasForeignKey(x => x.VaraCriminalId)
                .IsRequired(false);

            builder.HasOne(x => x.Comarca)
                .WithMany()
                .HasForeignKey(x => x.ComarcaId)
                .IsRequired(false);

            builder.HasOne(x => x.Assunto)
                .WithMany()
                .HasForeignKey(x => x.AssuntoId)
                .IsRequired(false);

            builder.HasOne(x => x.Artigo)
                .WithMany()
                .HasForeignKey(x => x.ArtigoId)
                .IsRequired(false);

            builder.HasOne(x => x.DelegaciaOrigem)
                .WithMany()
                .HasForeignKey(x => x.DelegaciaOrigemId)
                .IsRequired(false);

            builder.HasOne(x => x.SituacaoAtual)
                .WithMany()
                .HasForeignKey(x => x.SituacaoAtualId)
                .IsRequired();
        }
    }
}
