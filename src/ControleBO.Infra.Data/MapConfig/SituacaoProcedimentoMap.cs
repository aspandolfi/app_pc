using ControleBO.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleBO.Infra.Data.MapConfig
{
    public class SituacaoProcedimentoMap : IEntityTypeConfiguration<SituacaoProcedimento>
    {
        public void Configure(EntityTypeBuilder<SituacaoProcedimento> builder)
        {
            builder.ToTable("HistoricoSituacaoProcedimentos");

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Procedimento)
                .WithMany(y => y.HistoricoSituacoes)
                .IsRequired();

            builder.HasOne(x => x.Situacao)
                .WithMany()
                .IsRequired();

            builder.HasOne(x => x.SituacaoTipo)
                .WithMany();
        }
    }
}
