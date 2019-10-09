using AutoMapper;
using ControleBO.Application.Interfaces;
using ControleBO.Application.ViewModels;
using ControleBO.Domain.Commands;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;
using System.Collections.Generic;

namespace ControleBO.Application.Services
{
    public class IndiciadoAppService : AppServiceBase<IndiciadoViewModel,
                                                      Indiciado,
                                                      RegisterNewIndiciadoCommand,
                                                      UpdateIndiciadoCommand,
                                                      RemoveIndiciadoCommand>,
                                       IIndiciadoAppService
    {
        private readonly IIndiciadoRepository _indiciadoRepository;

        public IndiciadoAppService(IMapper mapper, IIndiciadoRepository repository, IMediatorHandler bus)
            : base(mapper, repository, bus)
        {
            _indiciadoRepository = repository;
        }

        public IEnumerable<IndiciadoViewModel> GetAllByProcedimentoId(int procedimentoId)
        {
            var result = Repository.GetAllAsNoTracking(x => x.ProcedimentoId == procedimentoId, x => x.Nome);

            return Mapper.Map<IEnumerable<IndiciadoViewModel>>(result);
        }

        public IEnumerable<string> GetIndiciadosByText(string text)
        {
            var result = _indiciadoRepository.GetAllAsNoTracking<string>(x => x.Nome, x => x.Nome.Contains(text), null);

            return result;
        }
    }
}
