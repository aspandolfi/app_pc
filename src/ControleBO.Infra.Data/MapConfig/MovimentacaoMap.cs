using ControleBO.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleBO.Infra.Data.MapConfig
{
    public class MovimentacaoMap : IEntityTypeConfiguration<Movimentacao>
    {
        public void Configure(EntityTypeBuilder<Movimentacao> builder)
        {
            builder.ToTable("Movimentacoes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Destino)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Data)
                .IsRequired();

            builder.HasOne(x => x.Procedimento)
                .WithMany(y => y.HistoricoMovimentacoes)
                .IsRequired();
        }
    }
}
