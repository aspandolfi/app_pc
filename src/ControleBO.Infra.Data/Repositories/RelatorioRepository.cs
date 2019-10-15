using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;
using ControleBO.Domain.Queries;
using ControleBO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;

namespace ControleBO.Infra.Data.Repositories
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly SpcContext DbContext;

        public RelatorioRepository(SpcContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }

        public IEnumerable<EstatisticaAssuntoQuery> GetEstatisticaAssunto(DateTime? de, DateTime? ate)
        {
            ICollection<Expression<Func<Procedimento, bool>>> filters = new Collection<Expression<Func<Procedimento, bool>>>();

            if (de.HasValue && ate.HasValue)
            {
                Expression<Func<Procedimento, bool>> func = (x) => x.CriadoEm >= de && x.CriadoEm <= ate;

                filters.Add(func);
            }
            else
            {
                if (de.HasValue)
                {
                    Expression<Func<Procedimento, bool>> func = (x) => x.CriadoEm >= de;

                    filters.Add(func);
                }

                if (ate.HasValue)
                {
                    Expression<Func<Procedimento, bool>> func = (x) => x.CriadoEm <= ate;

                    filters.Add(func);
                }
            }

            IQueryable<Procedimento> query = DbContext.Procedimentos;

            foreach (var filter in filters)
            {
                query = query.Where(filter);
            }

            query = query.Where(p => p.Assunto != null);

            var result = query.GroupBy(p => new { Assunto = p.Assunto.Descricao })
                              .AsNoTracking()
                              .Select(a => new EstatisticaAssuntoQuery
                              {
                                  Assunto = a.Key.Assunto,
                                  EmAndamento = a.Select(x => x.SituacaoAtualId).Where(x => x == 1).Count(),
                                  NaJustica = a.Select(x => x.SituacaoAtualId).Where(x => x == 2).Count(),
                                  Relatado = a.Select(x => x.SituacaoAtualId).Where(x => x == 3).Count()
                              })
                              .ToList();

            return result;
        }

        public IEnumerable<RelacaoIndiciadoQuery> GetRelacaoIndiciados()
        {
            var query = DbContext.Indiciados
                .AsNoTracking()
                .Select(x => new RelacaoIndiciadoQuery
                {
                    Investigado = x.Nome,
                    NumeroProcedimento = x.ProcedimentoId,
                    Artigo = x.Procedimento.Artigo.Descricao,
                    TipoProcedimento = x.Procedimento.TipoProcedimento.Descricao,
                    SituacaoAtual = x.Procedimento.SituacaoAtual.Descricao,
                    SituacaoAtualId = x.Procedimento.SituacaoAtualId
                })
                .ToList();

            return query;
        }

        public IEnumerable<RelacaoProcedimentoSituacaoQuery> GetRelacaoProcedimentoPorSituacao()
        {
            IQueryable<Procedimento> query = DbContext.Procedimentos;

            var result = query.OrderBy(p => p.CriadoEm)
                              .Include(x => x.SituacaoAtual)
                              .GroupBy(p => new { Situacao = p.SituacaoAtual.Descricao })
                              .AsNoTracking()
                              .Select(p => new RelacaoProcedimentoSituacaoQuery
                              {
                                  Count = p.Count(),
                                  Situacao = p.Key.Situacao
                              });

            return result;

        }

        public IEnumerable<RelacaoProcedimentoQuery> GetRelacaoProcedimentos(int? situacaoId, DateTime? de, DateTime? ate)
        {
            ICollection<Expression<Func<Procedimento, bool>>> filters = new Collection<Expression<Func<Procedimento, bool>>>();

            if (situacaoId.HasValue)
            {
                Expression<Func<Procedimento, bool>> func = (x) => x.SituacaoAtualId == situacaoId;

                filters.Add(func);
            }

            if (de.HasValue && ate.HasValue)
            {
                Expression<Func<Procedimento, bool>> func = (x) => x.CriadoEm >= de && x.CriadoEm <= ate;

                filters.Add(func);
            }
            else
            {
                if (de.HasValue)
                {
                    Expression<Func<Procedimento, bool>> func = (x) => x.CriadoEm >= de;

                    filters.Add(func);
                }

                if (ate.HasValue)
                {
                    Expression<Func<Procedimento, bool>> func = (x) => x.CriadoEm <= ate;

                    filters.Add(func);
                }
            }

            IQueryable<Procedimento> query = DbContext.Procedimentos;

            foreach (var filter in filters)
            {
                query = query.Where(filter);
            }

            var result = query.AsNoTracking()
                .Select(p => new RelacaoProcedimentoQuery
                {
                    Artigo = p.Artigo.Descricao,
                    BoletimOcorrencia = p.BoletimOcorrencia,
                    DataFato = p.DataFato,
                    Instauracao = p.DataInstauracao,
                    Indiciados = string.Join("<br/>", p.Autores.Select(a => a.Nome)),
                    NumeroProcedimento = p.Id,
                    Situacao = p.SituacaoAtual.Descricao,
                    UnidadePolicial = p.DelegaciaOrigem.Descricao
                }).ToList();

            return result;
        }

        public IEnumerable<RelacaoVitimaQuery> GetRelacaoVitimas()
        {
            var query = DbContext.Vitimas
                .AsNoTracking()
                .Select(x => new RelacaoVitimaQuery
                {
                    Vitima = x.Nome,
                    NumeroProcedimento = x.ProcedimentoId,
                    Artigo = x.Procedimento.Artigo.Descricao,
                    TipoProcedimento = x.Procedimento.TipoProcedimento.Descricao,
                    SituacaoAtual = x.Procedimento.SituacaoAtual.Descricao,
                    SituacaoAtualId = x.Procedimento.SituacaoAtualId
                })
                .ToList();

            return query;
        }
    }
}
