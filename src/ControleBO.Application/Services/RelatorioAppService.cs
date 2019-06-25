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

        public DataTableViewModel GetEstatisticaAssunto()
        {
            var result = _relatorioRepository.GetEstatisticaAssunto();

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
    }
}
