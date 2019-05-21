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
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.BoletimOcorrencia)
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.NumeroProcessual)
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.Gampes)
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.Anexos)
                .HasColumnType("varchar");

            builder.Property(x => x.LocalFato)
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(x => x.DataFato)
                .IsRequired();

            builder.Property(x => x.TipoCriminal)
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.Property(x => x.AndamentoProcessual)
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.HasOne(x => x.TipoProcedimento)
                .WithMany()
                .HasForeignKey(x => x.TipoProcedimentoId)
                .IsRequired();

            builder.HasOne(x => x.VaraCriminal)
                .WithMany()
                .HasForeignKey(x => x.VaraCriminalId)
                .IsRequired();

            builder.HasOne(x => x.Comarca)
                .WithMany()
                .HasForeignKey(x => x.ComarcaId)
                .IsRequired();

            builder.HasOne(x => x.Assunto)
                .WithMany()
                .HasForeignKey(x => x.AssuntoId)
                .IsRequired();

            builder.HasOne(x => x.Artigo)
                .WithMany()
                .HasForeignKey(x => x.ArtigoId)
                .IsRequired();

            builder.HasOne(x => x.DelegaciaOrigem)
                .WithMany()
                .HasForeignKey(x => x.DelegaciaOrigemId)
                .IsRequired();
        }
    }
}
