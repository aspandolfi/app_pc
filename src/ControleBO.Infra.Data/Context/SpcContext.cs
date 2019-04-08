using ControleBO.Domain.Models;
using ControleBO.Infra.Data.MapConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace ControleBO.Infra.Data.Context
{
    public class SpcContext : DbContext
    {
        public SpcContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
            //this.Seed();
        }

        public DbSet<Artigo> Artigos { get; set; }
        public DbSet<Assunto> Assuntos { get; set; }
        public DbSet<Indiciado> Indiciados { get; set; }
        public DbSet<Movimentacao> HistoricoMivimentacao { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<ObjetoApreendido> ObjetosApreendidos { get; set; }
        public DbSet<Procedimento> Procedimentos { get; set; }
        public DbSet<ProcedimentoTipo> TiposProcedimento { get; set; }
        public DbSet<Situacao> Situacoes { get; set; }
        public DbSet<SituacaoProcedimento> SituacaoProcedimentos { get; set; }
        public DbSet<SituacaoTipo> TiposSituacao { get; set; }
        public DbSet<UnidadePolicial> UnidadesPolicia { get; set; }
        public DbSet<VaraCriminal> VarasCriminais { get; set; }
        public DbSet<Vitima> Vitimas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.DisableCascade();
            modelBuilder.SetColumnTypeOfString();

            modelBuilder.ApplyConfiguration(new ArtigoMap());
            modelBuilder.ApplyConfiguration(new AssuntoMap());
            modelBuilder.ApplyConfiguration(new IndiciadoMap());
            modelBuilder.ApplyConfiguration(new MovimentacaoMap());
            modelBuilder.ApplyConfiguration(new MunicipioMap());
            modelBuilder.ApplyConfiguration(new ObjetoApreendidoMap());
            modelBuilder.ApplyConfiguration(new ProcedimentoMap());
            modelBuilder.ApplyConfiguration(new ProcedimentoTipoMap());
            modelBuilder.ApplyConfiguration(new SituacaoMap());
            modelBuilder.ApplyConfiguration(new SituacaoProcedimentoMap());
            modelBuilder.ApplyConfiguration(new SituacaoTipoMap());
            modelBuilder.ApplyConfiguration(new UnidadePolicialMap());
            modelBuilder.ApplyConfiguration(new VaraCriminalMap());
            modelBuilder.ApplyConfiguration(new ProcedimentoTipoMap());
            modelBuilder.ApplyConfiguration(new VitimaMap());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CriadoEm") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CriadoEm").CurrentValue = DateTime.Now;
                    entry.Property("ModificadoEm").CurrentValue = DateTime.Now;
                    entry.Property("Versao").CurrentValue = 0;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("ModificadoEm") != null))
            {
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CriadoEm").IsModified = false;
                    entry.Property("ModificadoEm").CurrentValue = DateTime.Now;
                    entry.Property("Versao").CurrentValue = (int)entry.Property("Versao").CurrentValue + 1;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("RemovidoEm") != null))
            {
                if (entry.State == EntityState.Deleted)
                {
                    entry.Property("CriadoEm").IsModified = false;
                    entry.Property("ModificadoEm").CurrentValue = DateTime.Now;
                    entry.Property("RemovidoEm").CurrentValue = DateTime.Now;
                    entry.Property("Versao").IsModified = false;
                }
            }

            return base.SaveChanges();
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
    }
}
