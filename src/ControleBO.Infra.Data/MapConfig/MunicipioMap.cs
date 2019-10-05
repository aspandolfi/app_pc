using ControleBO.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleBO.Infra.Data.MapConfig
{
    public class MunicipioMap : IEntityTypeConfiguration<Municipio>
    {
        public void Configure(EntityTypeBuilder<Municipio> builder)
        {
            builder.ToTable("Municipios");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("varchar(200)")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.CEP)
                .HasColumnType("varchar(9)")
                .HasMaxLength(9)
                .IsRequired();

            builder.Property(x => x.UF)
                .HasColumnType("varchar(2)")
                .HasMaxLength(2)
                .IsRequired();
        }
    }
}
