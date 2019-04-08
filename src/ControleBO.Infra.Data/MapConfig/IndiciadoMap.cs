using ControleBO.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleBO.Infra.Data.MapConfig
{
    public class IndiciadoMap : IEntityTypeConfiguration<Indiciado>
    {
        public void Configure(EntityTypeBuilder<Indiciado> builder)
        {
            builder.ToTable("Indiciados");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Apelido)
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.HasOne(x => x.Procedimento)
                .WithMany(y => y.Autores)
                .IsRequired();
        }
    }
}
