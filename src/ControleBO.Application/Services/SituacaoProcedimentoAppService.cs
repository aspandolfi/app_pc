using AutoMapper;
using ControleBO.Application.Interfaces;
using ControleBO.Application.ViewModels;
using ControleBO.Domain.Commands;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;

namespace ControleBO.Application.Services
{
    public class SituacaoProcedimentoAppService : AppServiceBase<SituacaoProcedimentoViewModel,
                                                                 SituacaoProcedimento,
                                                                 RegisterNewSituacaoProcedimentoCommand,
                                                                 UpdateSituacaoProcedimentoCommand,
                                                                 RemoveSituacaoProcedimentoCommand>,
                                                  ISituacaoProcedimentoAppService
    {
        private readonly ISituacaoProcedimentoRepository _situacaoProcedimentoRepository;

        public SituacaoProcedimentoAppService(IMapper mapper, ISituacaoProcedimentoRepository repository, IMediatorHandler bus)
            : base(mapper, repository, bus)
        {
            _situacaoProcedimentoRepository = repository;
        }

        public SituacaoProcedimentoViewModel GetCurrentByProcedimentoId(int procedimentoId)
        {
            var result = _situacaoProcedimentoRepository.GetCurrentByProcedimentoId(procedimentoId);

            return Mapper.Map<SituacaoProcedimentoViewModel>(result);
        }
    }
}
