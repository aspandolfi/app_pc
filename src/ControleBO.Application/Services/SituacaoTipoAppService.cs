using System;
using AutoMapper;
using ControleBO.Application.Interfaces;
using ControleBO.Application.ViewModels;
using ControleBO.Domain.Commands;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;

namespace ControleBO.Application.Services
{
    public class SituacaoTipoAppService : AppServiceBase<SituacaoTipoViewModel,
                                                         SituacaoTipo,
                                                         RegisterNewSituacaoTipoCommand,
                                                         UpdateSituacaoTipoCommand,
                                                         RemoveSituacaoTipoCommand>,
                                          ISituacaoTipoAppService
    {
        private readonly ISituacaoTipoRepository _situacaoTipoRepository;

        public SituacaoTipoAppService(IMapper mapper,
                                      ISituacaoTipoRepository repository,
                                      IMediatorHandler bus)
            : base(mapper, repository, bus)
        {
            _situacaoTipoRepository = repository;
        }

        public DateTime? UltimaAtualizacao(int situacaoId)
        {
            return _situacaoTipoRepository.LastUpdate(situacaoId);
        }
    }
}
