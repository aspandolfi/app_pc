using AutoMapper;
using ControleBO.Application.Interfaces;
using ControleBO.Application.ViewModels;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.DataObjects;
using ControleBO.Domain.Interfaces.Repositories;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ControleBO.Application.Services
{
    public class RelatorioAppService : IRelatorioAppService
    {
        private readonly IMapper Mapper;
        private readonly IMediatorHandler Bus;
        private readonly IRelatorioRepository _relatorioRepository;

        public RelatorioAppService(IRelatorioRepository relatorioRepository,
                                   IMapper mapper,
                                   IMediatorHandler bus)
        {
            Mapper = mapper;
            Bus = bus;
            _relatorioRepository = relatorioRepository;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public DataTableViewModel GetEstatisticaAssunto(DateTime? de, DateTime? ate)
        {
            var result = _relatorioRepository.GetEstatisticaAssunto(de, ate);

            var dt = new DataTableObject();

            dt.AddHeaders("Delitos", "Em Andamento", "Na Justiça", "Relatado", "Outra UniPol", "Total");

            dt.AddDataSet(result.Select(x => new Collection<object>
            {
                x.Assunto,
                x.EmAndamento,
                x.NaJustica,
                x.Relatado,
                x.OutraUniPol,
                x.Total
            }));

            return Mapper.Map<DataTableViewModel>(dt);
        }

        public DataTableViewModel GetRelacaoIndiciados()
        {
            var result = _relatorioRepository.GetRelacaoIndiciados();

            var dt = new DataTableObject();

            dt.AddHeaders("Investigado",
                "Proced. n°",
                "Artigo",
                "Tipo de Procedimento",
                "Situação");

            dt.AddDataSet(result.Select(x => new Collection<object>
            {
                x.Investigado,
                x.NumeroProcedimento,
                x.Artigo,
                x.TipoProcedimento,
                x.SituacaoAtual
            }));

            return Mapper.Map<DataTableViewModel>(dt);
        }

        public DataTableViewModel GetRelacaoProcedimentos(int? situacaoId, DateTime? de, DateTime? ate)
        {
            var result = _relatorioRepository.GetRelacaoProcedimentos(situacaoId, de, ate);

            var dt = new DataTableObject();

            dt.AddHeaders("Proced n°",
                "Boletim de Ocorrência",
                "Artigo",
                "Indiciados",
                "Unidade Policial",
                "Data do Fato",
                "Instauração",
                "Situação");

            dt.AddDataSet(result.Select(x => new Collection<object>
            {
                x.NumeroProcedimento,
                x.BoletimOcorrencia,
                x.Artigo,
                x.Indiciados,
                x.UnidadePolicial,
                x.DataFato?.ToString("dd/MM/yyyy"),
                x.Instauracao?.ToString("dd/MM/yyyy"),
                x.Situacao
            }));

            return Mapper.Map<DataTableViewModel>(dt);
        }

        public DataTableViewModel GetRelacaoVitimas()
        {
            var result = _relatorioRepository.GetRelacaoVitimas();

            var dt = new DataTableObject();

            dt.AddHeaders("Vítima",
                "Proced. n°",
                "Artigo",
                "Tipo de Procedimento",
                "Situação");

            dt.AddDataSet(result.Select(x => new Collection<object>
            {
                x.Vitima,
                x.NumeroProcedimento,
                x.Artigo,
                x.TipoProcedimento,
                x.SituacaoAtual
            }));

            return Mapper.Map<DataTableViewModel>(dt);
        }
    }
}
