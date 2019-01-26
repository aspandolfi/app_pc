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
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Sigla)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Descricao)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.CodigoCargoQO)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
