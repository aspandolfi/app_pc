using ControleBO.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleBO.Infra.Data.MapConfig
{
    public class VitimaMap : IEntityTypeConfiguration<Vitima>
    {
        public void Configure(EntityTypeBuilder<Vitima> builder)
        {
            builder.ToTable("Vitimas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email)
                .HasColumnType("varchar")
                .HasMaxLength(100);

            builder.HasOne(x => x.Pessoa)
                .WithOne()
                .HasPrincipalKey<Pessoa>()
                .IsRequired();

            builder.HasOne(x => x.Procedimento)
                .WithMany(y => y.Vitimas)
                .IsRequired();
        }
    }
}
