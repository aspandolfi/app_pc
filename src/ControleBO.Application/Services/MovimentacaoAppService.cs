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
    public class MovimentacaoAppService : AppServiceBase<MovimentacaoViewModel,
                                                         Movimentacao,
                                                         RegisterNewMovimentacaoCommand,
                                                         UpdateMovimentacaoCommand,
                                                         RemoveMovimentacaoCommand>,
                                          IMovimentacaoAppService
    {
        public MovimentacaoAppService(IMapper mapper,
                                      IMovimentacaoRepository repository,
                                      IMediatorHandler bus)
            : base(mapper, repository, bus)
        {
        }

        public IEnumerable<MovimentacaoViewModel> GetByProcedimentoId(int procedimentoId)
        {
            var result = Repository.GetAllAsNoTracking(x => x.ProcedimentoId == procedimentoId, x => x.Data);

            return Mapper.Map<IEnumerable<MovimentacaoViewModel>>(result);
        }
    }
}
