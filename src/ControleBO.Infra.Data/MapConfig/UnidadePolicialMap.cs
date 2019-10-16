using ControleBO.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleBO.Infra.Data.MapConfig
{
    public class UnidadePolicialMap : IEntityTypeConfiguration<UnidadePolicial>
    {
        public void Configure(EntityTypeBuilder<UnidadePolicial> builder)
        {
            builder.ToTable("UnidadesPolicia");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Codigo)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Property(x => x.Sigla)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.CodigoCargoQO)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);
        }
    }
}
