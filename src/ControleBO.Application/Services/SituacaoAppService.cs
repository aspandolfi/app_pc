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
    public class SituacaoAppService : AppServiceBase<SituacaoViewModel,
                                                     Situacao,
                                                     RegisterNewSituacaoCommand,
                                                     UpdateSituacaoCommand,
                                                     RemoveSituacaoCommand>,
                                      ISituacaoAppService
    {
        private readonly ISituacaoTipoRepository _situacaoTipoRepository;

        public SituacaoAppService(IMapper mapper,
                                  ISituacaoRepository repository,
                                  ISituacaoTipoRepository situacaoTipoRepository,
                                  IMediatorHandler bus)
            : base(mapper, repository, bus)
        {
            _situacaoTipoRepository = situacaoTipoRepository;
        }

        public override IEnumerable<SituacaoViewModel> GetAll()
        {
            var query = Repository.GetAllAsNoTracking(x => x.Tipos).ToList();

            return Mapper.Map<IEnumerable<SituacaoViewModel>>(query);
        }
    }
}
