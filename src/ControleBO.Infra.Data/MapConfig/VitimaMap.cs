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
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.HasOne(x => x.Procedimento)
                .WithMany(y => y.Vitimas)
                .HasForeignKey(x => x.ProcedimentoId)
                .IsRequired();

            builder.HasOne(x => x.Naturalidade)
                .WithMany()
                .HasForeignKey(x => x.NaturalidadeId)
                .IsRequired(false);
        }
    }
}
