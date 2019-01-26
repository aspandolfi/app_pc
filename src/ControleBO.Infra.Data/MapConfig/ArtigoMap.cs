using ControleBO.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleBO.Infra.Data.MapConfig
{
    public class ArtigoMap : IEntityTypeConfiguration<Artigo>
    {
        public void Configure(EntityTypeBuilder<Artigo> builder)
        {
            builder.ToTable("Artigos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
