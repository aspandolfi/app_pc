using AutoMapper;
using ControleBO.Application.Interfaces;
using ControleBO.Application.ViewModels;
using ControleBO.Domain.Commands;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace ControleBO.Application.Services
{
    public class ObjetoApreendidoAppService : AppServiceBase<ObjetoApreendidoViewModel,
                                                             ObjetoApreendido,
                                                             RegisterNewObjetoApreendidoCommand,
                                                             UpdateObjetoApreendidoCommand,
                                                             RemoveObjetoApreendidoCommand>,
                                              IObjetoApreendidoAppService
    {
        private readonly IObjetoApreendidoRepository _objetoApreendidoRepository;

        public ObjetoApreendidoAppService(IMapper mapper,
                                          IObjetoApreendidoRepository repository,
                                          IMediatorHandler bus)
            : base(mapper, repository, bus)
        {
            _objetoApreendidoRepository = repository;
        }

        public IEnumerable<ObjetoApreendidoViewModel> GetByProcedimentoId(int procedimentoId)
        {
            var result = _objetoApreendidoRepository.GetAllAsNoTracking(filter: x => x.ProcedimentoId == procedimentoId, orderBy: x => x.OrderByDescending(z => z.CriadoEm)).ToList();

            return Mapper.Map<IEnumerable<ObjetoApreendidoViewModel>>(result);
        }
    }
}
