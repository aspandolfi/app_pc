﻿using AutoMapper;
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
    public class MovimentacaoAppService : AppServiceBase<MovimentacaoViewModel,
                                                         Movimentacao,
                                                         RegisterNewMovimentacaoCommand,
                                                         UpdateMovimentacaoCommand,
                                                         RemoveMovimentacaoCommand>,
                                          IMovimentacaoAppService
    {
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public MovimentacaoAppService(IMapper mapper,
                                      IMovimentacaoRepository repository,
                                      IMediatorHandler bus)
            : base(mapper, repository, bus)
        {
            _movimentacaoRepository = repository;
        }

        public IEnumerable<MovimentacaoViewModel> GetByProcedimentoId(int procedimentoId)
        {
            var result = Repository.GetAllAsNoTracking(x => x.ProcedimentoId == procedimentoId, x => x.OrderByDescending(z => z.Data), null);

            return Mapper.Map<IEnumerable<MovimentacaoViewModel>>(result);
        }

        public MovimentacaoViewModel GetLastByProcedimentoId(int procedimentoId)
        {
            var result = _movimentacaoRepository.GetLastByProcedimentoId(procedimentoId);

            return Mapper.Map<MovimentacaoViewModel>(result);
        }
    }
}
