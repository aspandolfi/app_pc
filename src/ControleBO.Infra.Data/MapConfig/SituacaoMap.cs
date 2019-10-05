using ControleBO.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleBO.Infra.Data.MapConfig
{
    public class SituacaoMap : IEntityTypeConfiguration<Situacao>
    {
        public void Configure(EntityTypeBuilder<Situacao> builder)
        {
            builder.ToTable("Situacoes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
