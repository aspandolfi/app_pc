using ControleBO.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace ControleBO.Infra.Data.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this SpcContext context)
        {
            SeedMunicipios(context);
            SeedUnidadesPolicial(context);
            SeedAssuntos(context);
            SeedArtigos(context);
            SeedVarasCriminais(context);
            SeedTiposProcedimento(context);
            SeedSituacoes(context);
        }

        private static void SeedMunicipios(SpcContext context)
        {
            if (!context.Municipios.Any())
            {
                context.Municipios.AddRange(GetMunicipiosFromXml());
                context.SaveChanges();
            }
        }

        private static void SeedUnidadesPolicial(SpcContext context)
        {
            if (!context.UnidadesPolicia.Any())
            {
                context.UnidadesPolicia.AddRange(GetUnidadePolicialFromXml());
                context.SaveChanges();
            }
        }

        private static void SeedAssuntos(SpcContext context)
        {
            if (!context.Assuntos.Any())
            {
                context.Assuntos.AddRange(GetAssuntosFromXml());
                context.SaveChanges();
            }
        }

        private static void SeedArtigos(SpcContext context)
        {
            if (!context.Artigos.Any())
            {
                context.Artigos.AddRange(GetArtigosFromXml());
                context.SaveChanges();
            }
        }

        private static void SeedVarasCriminais(SpcContext context)
        {
            if (!context.VarasCriminais.Any())
            {
                context.VarasCriminais.AddRange(
                    new VaraCriminal("1ª"),
                    new VaraCriminal("2ª"),
                    new VaraCriminal("3ª"),
                    new VaraCriminal("4ª"),
                    new VaraCriminal("5ª"),
                    new VaraCriminal("6ª"),
                    new VaraCriminal("7ª"),
                    new VaraCriminal("8ª"),
                    new VaraCriminal("9ª"),
                    new VaraCriminal("10ª"),
                    new VaraCriminal("11ª"));

                context.SaveChanges();
            }
        }

        private static void SeedTiposProcedimento(SpcContext context)
        {
            if (!context.TiposProcedimento.Any())
            {
                context.TiposProcedimento.AddRange(GetProcedimentoTiposFromXml());
                context.SaveChanges();
            }
        }

        private static void SeedSituacoes(SpcContext context)
        {
            if (!context.Situacoes.Any())
            {
                var situacao1 = new Situacao(1, "Procedimento se encontra em andamento na Delegacia");
                var situacao2 = new Situacao(2, "Procedimento se encontra na justiça");
                var situacao3 = new Situacao(3, "Procedimento relatado");

                context.Situacoes.AddRange(
                    situacao1,
                    situacao2,
                    situacao3);

                #region Tipos: Procedimento se encontra na justiça
                context.TiposSituacao.AddRange(
                            new SituacaoTipo("Representação para quebra de dados", situacao2),
                            new SituacaoTipo("Representação por prisão", situacao2),
                            new SituacaoTipo("Representação por mandato de busca e apreensão", situacao2),
                            new SituacaoTipo("Representação por intervenção telefônica", situacao2),
                            new SituacaoTipo("Representação por quebra de sigilo de dados", situacao2),
                            new SituacaoTipo("Representação por quebra de sigilo telemáticos", situacao2),
                            new SituacaoTipo("Solicitação de prazo", situacao2));
                #endregion

                #region Tipos: Procedimento relatado
                context.TiposSituacao.AddRange(
                            new SituacaoTipo("Ausência de representação", situacao3),
                            new SituacaoTipo("Autor inimputável", situacao3),
                            new SituacaoTipo("Decadência/Prescrição", situacao3),
                            new SituacaoTipo("Falta de materialidade", situacao3),
                            new SituacaoTipo("Fato atípico", situacao3),
                            new SituacaoTipo("Morte do autor", situacao3),
                            new SituacaoTipo("Renúncia ao direito de queixa", situacao3),
                            new SituacaoTipo("Renúncia ao direito de representação", situacao3),
                            new SituacaoTipo("Sem autoria", situacao3),
                            new SituacaoTipo("Suicídio", situacao3));
                #endregion

                context.SaveChanges();
            }
        }

        private static IEnumerable<UnidadePolicial> GetUnidadePolicialFromXml()
        {
            //string dataDirectory = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();

            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{assemblyName}.Xmls.dbo_UniPol.xml");

            var unidades = new List<UnidadePolicial>();

            using (stream)
            {
                XElement root = XElement.Load(stream);

                foreach (var item in root.Elements())
                {
                    string codigoCargo = item.Element(XName.Get("CodigoCargoQO"))?.Value.Trim();

                    unidades.Add(new UnidadePolicial(item.Element(XName.Get("CodigoUniPol")).Value.Trim(),
                                                       item.Element(XName.Get("Sigla")).Value.Trim(),
                                                       item.Element(XName.Get("UnidadePolicial")).Value.Trim(),
                                                       codigoCargo));
                }
            }

            return unidades;
        }

        private static IEnumerable<Municipio> GetMunicipiosFromXml()
        {
            //string dataDirectory = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();

            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{assemblyName}.Xmls.dbo_Municipio.xml");

            var municipios = new List<Municipio>();

            using (stream)
            {
                XElement root = XElement.Load(stream);

                foreach (var item in root.Elements())
                {
                    municipios.Add(new Municipio(/*Convert.ToInt32(item.Element(XName.Get("Id_Municipio")).Value),*/
                                               item.Element(XName.Get("MunicNome")).Value.Trim(),
                                               item.Element(XName.Get("MunicUF")).Value.Trim(),
                                               item.Element(XName.Get("MunicCEP")).Value.Trim()));
                }
            }

            return municipios;
        }

        private static IEnumerable<ProcedimentoTipo> GetProcedimentoTiposFromXml()
        {
            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{assemblyName}.Xmls.TipoProcedimento.xml");

            var tiposProcedimentos = new List<ProcedimentoTipo>();

            using (stream)
            {
                XElement root = XElement.Load(stream);

                foreach (var item in root.Elements())
                {
                    tiposProcedimentos.Add(new ProcedimentoTipo(item.Element(XName.Get("Procedimento")).Value.Trim(),
                                                                item.Element(XName.Get("Descrição")).Value.Trim()));
                }
            }

            return tiposProcedimentos;
        }

        private static IEnumerable<Assunto> GetAssuntosFromXml()
        {
            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{assemblyName}.Xmls.Inquerito.xml");

            var assuntos = new List<Assunto>();

            using (stream)
            {
                XElement root = XElement.Load(stream);

                foreach (var item in root.Descendants("Assunto"))
                {
                    if (!assuntos.Any(x => item?.Value.Trim() == x.Descricao))
                    {
                        assuntos.Add(new Assunto(item.Value.Trim()));
                    }
                }
            }

            return assuntos;
        }

        private static IEnumerable<Artigo> GetArtigosFromXml()
        {
            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{assemblyName}.Xmls.Inquerito.xml");

            var artigos = new List<Artigo>();

            using (stream)
            {
                XElement root = XElement.Load(stream);

                foreach (var item in root.Descendants("Artigo"))
                {
                    if (!artigos.Any(x => item?.Value.Trim() == x.Descricao))
                    {
                        artigos.Add(new Artigo(item.Value.Trim()));
                    }
                }
            }

            return artigos;
        }

        public static void DisableCascade(this ModelBuilder modelBuilder)
        {
            var cascadeFks = modelBuilder.Model.GetEntityTypes()
                            .SelectMany(x => x.GetForeignKeys())
                            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFks)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public static void SetColumnTypeOfString(this ModelBuilder modelBuilder, int maxLength = 250, string type = "varchar")
        {
            var properties = modelBuilder.Model.GetEntityTypes()
                .SelectMany(x => x.GetProperties())
                .Where(x => x.ClrType == typeof(string));

            foreach (var property in properties)
            {
                property.Npgsql().ColumnType = type;
                property.SetMaxLength(maxLength);
            }
        }
    }
}
