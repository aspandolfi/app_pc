using ControleBO.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleBO.Infra.Data.MapConfig
{
    public class VaraCriminalMap : IEntityTypeConfiguration<VaraCriminal>
    {
        public void Configure(EntityTypeBuilder<VaraCriminal> builder)
        {
            builder.ToTable("VarasCriminais");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
