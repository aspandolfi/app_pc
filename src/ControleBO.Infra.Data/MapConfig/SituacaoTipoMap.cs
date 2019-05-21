using ControleBO.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleBO.Infra.Data.MapConfig
{
    public class SituacaoTipoMap : IEntityTypeConfiguration<SituacaoTipo>
    {
        public void Configure(EntityTypeBuilder<SituacaoTipo> builder)
        {
            builder.ToTable("TiposSituacao");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(x => x.Situacao)
                .WithMany(y => y.Tipos)
                .HasForeignKey(x => x.SituacaoId)
                .IsRequired();
        }
    }
}
