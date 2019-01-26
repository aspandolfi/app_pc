using ControleBO.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleBO.Infra.Data.MapConfig
{
    class ProcedimentoTipoMap : IEntityTypeConfiguration<ProcedimentoTipo>
    {
        public void Configure(EntityTypeBuilder<ProcedimentoTipo> builder)
        {
            builder.ToTable("TiposProcedimento");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Sigla)
                .HasColumnType("varchar")
                .HasMaxLength(10);
        }
    }
}
