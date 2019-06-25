using AutoMapper;
using ControleBO.Application.Interfaces;
using ControleBO.Application.ViewModels;
using ControleBO.Domain.Commands;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.DataObjects;
using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ControleBO.Application.Services
{
    public class ProcedimentoAppService : AppServiceBase<ProcedimentoViewModel,
                                                         Procedimento,
                                                         RegisterNewProcedimentoCommand,
                                                         UpdateProcedimentoCommand,
                                                         RemoveProcedimentoCommand>, IProcedimentoAppService
    {
        public ProcedimentoAppService(IMapper mapper, IProcedimentoRepository repository, IMediatorHandler bus)
            : base(mapper, repository, bus)
        {
        }

        static readonly List<Expression<Func<Procedimento, object>>> DatatableColumns =
            new List<Expression<Func<Procedimento, object>>>
            {
                null,
                x=> x.Id,
                x=> x.BoletimUnificado,
                x=> x.BoletimOcorrencia,
                x=> x.NumeroProcessual,
                x=> x.TipoProcedimento.Sigla,
                x=> x.CriadoEm,
                x=> x.Comarca.Nome,
                x=> x.AndamentoProcessual
            };

        public DataTableViewModel GetAllAsDatatable()
        {
            var result = Repository.GetAllAsNoTracking(x => x.RemovidoEm == null, x => x.CriadoEm);

            var dt = CreateDatatableObject(result);

            return Mapper.Map<DataTableViewModel>(dt);
        }

        public DataTableViewModel GetAllPagedAsDatatable(int page, int pageSize = 10)
        {
            var result = Repository.GetPaged(x => x.CriadoEm, page, pageSize);

            var dt = CreateDatatableObject(result);

            return Mapper.Map<DataTableViewModel>(dt);
        }

        public DatatableQueryResultViewModel GetAllQueryableAsDatatable(DatatableQueryInputViewModel datatableQuery)
        {
            string textToSearch = datatableQuery.TextToSearch;

            var predicate = new Func<Procedimento, bool>((p) => textToSearch.Contains(p.Id.ToString()) ||
                                                                textToSearch.Contains(p.BoletimUnificado) ||
                                                                textToSearch.Contains(p.BoletimOcorrencia) ||
                                                                textToSearch.Contains(p.NumeroProcessual) ||
                                                                textToSearch.Contains(p.TipoProcedimento.Sigla) ||
                                                                textToSearch.Contains(p.CriadoEm.ToString()) ||
                                                                textToSearch.Contains(p.BoletimOcorrencia) ||
                                                                textToSearch.Contains(p.Comarca.Nome) ||
                                                                textToSearch.Contains(p.BoletimOcorrencia));

            var result = Enumerable.Empty<Procedimento>();

            if (string.IsNullOrEmpty(textToSearch))
            {
                result = Repository.GetPaged(DatatableColumns[datatableQuery.OrderColumn], datatableQuery.Start, datatableQuery.Length);
            }
            else
            {
                result = Repository.GetPaged(x => predicate(x), DatatableColumns[datatableQuery.OrderColumn], datatableQuery.Start, datatableQuery.Length);
            }

            return new DatatableQueryResultViewModel
            {
                Draw = datatableQuery.Draw,
                RecordsFiltered = result.Count(),
                Data = result.Select(p => new List<object>
                {
                    string.Empty,
                    p.Id,
                    p.BoletimUnificado,
                    p.BoletimOcorrencia,
                    p.NumeroProcessual,
                    p.TipoProcedimento.Sigla,
                    p.CriadoEm,
                    p.Comarca.Nome,
                    p.AndamentoProcessual
                }).ToList(),
                RecordsTotal = Repository.Count()
            };
        }

        private DataTableObject CreateDatatableObject(IEnumerable<Procedimento> procedimentos = null)
        {
            var dt = new DataTableObject();

            dt.AddHeaders(new List<string>
            {
                string.Empty,
                "Número de Cadastro",
                "Boletim Unificado",
                "Boletim de Ocorrência",
                "Número Processual",
                "Tipo de Procedimento",
                "Data de Inserção",
                "Comarca",
                "Andamento Processual"
            });

            if (procedimentos != null)
            {
                dt.AddDataSet(procedimentos.Select(p => new List<object>
                {
                    string.Empty,
                    p.Id,
                    p.BoletimUnificado,
                    p.BoletimOcorrencia,
                    p.NumeroProcessual,
                    p.TipoProcedimento.Sigla,
                    p.CriadoEm,
                    p.Comarca.Nome,
                    p.AndamentoProcessual
                }).ToList());
            }

            return dt;
        }

        public IEnumerable<ProcedimentoListViewModel> GetAllAsListViewModel()
        {
            var result = Repository.GetAllAsNoTracking(x => new
            {
                x.Id,
                x.BoletimUnificado,
                x.BoletimOcorrencia,
                x.NumeroProcessual,
                TipoProcedimento = x.TipoProcedimento.Sigla,
                x.CriadoEm,
                Comarca = x.Comarca.Nome,
                x.AndamentoProcessual
            }, null, x => x.CriadoEm);

            return result.Select(p => new ProcedimentoListViewModel
            {
                Id = p.Id,
                BoletimUnificado = p.BoletimUnificado,
                BoletimOcorrencia = p.BoletimOcorrencia,
                NumeroProcessual = p.NumeroProcessual,
                TipoProcedimento = p.TipoProcedimento,
                DataInsercao = p.CriadoEm,
                Comarca = p.Comarca,
                AndamentoProcessual = p.AndamentoProcessual
            });
        }
    }
}
