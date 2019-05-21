using ControleBO.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleBO.Infra.Data.MapConfig
{
    public class ObjetoApreendidoMap : IEntityTypeConfiguration<ObjetoApreendido>
    {
        public void Configure(EntityTypeBuilder<ObjetoApreendido> builder)
        {
            builder.ToTable("ObjetosApreendidos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Descricao)
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Local)
                .HasColumnType("varchar")
                .HasMaxLength(250);

            builder.HasOne(x => x.Procedimento)
                .WithMany(y => y.ObjetosApreendidos)
                .HasForeignKey(x => x.ProcedimentoId)
                .IsRequired();
        }
    }
}
