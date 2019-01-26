using ControleBO.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleBO.Infra.Data.MapConfig
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.NomeMae)
                .HasColumnType("varchar")
                .HasMaxLength(250);

            builder.Property(x => x.NomePai)
                .HasColumnType("varchar")
                .HasMaxLength(250);

            builder.Property(x => x.Telefone)
                .HasColumnType("varchar")
                .HasMaxLength(20);

            builder.HasOne(x => x.Naturalidade)
                .WithMany();
        }
    }
}
