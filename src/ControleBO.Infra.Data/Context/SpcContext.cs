using ControleBO.Domain.Models;
using ControleBO.Infra.Data.MapConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

namespace ControleBO.Infra.Data.Context
{
    public class SpcContext : DbContext
    {
        public SpcContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureDeleted();
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<ProcedimentoTipo> TiposProcedimento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArtigoMap());
            modelBuilder.ApplyConfiguration(new AssuntoMap());
            modelBuilder.ApplyConfiguration(new IndiciadoMap());
            modelBuilder.ApplyConfiguration(new MovimentacaoMap());
            modelBuilder.ApplyConfiguration(new MunicipioMap());
            modelBuilder.ApplyConfiguration(new ObjetoApreendidoMap());
            modelBuilder.ApplyConfiguration(new PessoaMap());
            modelBuilder.ApplyConfiguration(new ProcedimentoMap());
            modelBuilder.ApplyConfiguration(new ProcedimentoTipoMap());
            modelBuilder.ApplyConfiguration(new SituacaoMap());
            modelBuilder.ApplyConfiguration(new SituacaoProcedimentoMap());
            modelBuilder.ApplyConfiguration(new SituacaoTipoMap());
            modelBuilder.ApplyConfiguration(new UnidadePolicialMap());
            modelBuilder.ApplyConfiguration(new VaraCriminalMap());
            modelBuilder.ApplyConfiguration(new ProcedimentoTipoMap());
            modelBuilder.ApplyConfiguration(new VitimaMap());

            DisableCascade(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // define the database to use
            optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));
        }

        private void DisableCascade(ModelBuilder modelBuilder)
        {
            var cascadeFks = modelBuilder.Model.GetEntityTypes()
                            .SelectMany(x => x.GetForeignKeys())
                            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFks)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
