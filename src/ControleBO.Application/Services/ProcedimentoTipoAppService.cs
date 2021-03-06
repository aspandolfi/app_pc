﻿using AutoMapper;
using ControleBO.Application.Interfaces;
using ControleBO.Application.ViewModels;
using ControleBO.Domain.Commands;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;

namespace ControleBO.Application.Services
{
    public class ProcedimentoTipoAppService : AppServiceBase<ProcedimentoTipoViewModel,
                                                             ProcedimentoTipo,
                                                             RegisterNewProcedimentoTipoCommand,
                                                             UpdateProcedimentoTipoCommand,
                                                             RemoveProcedimentoTipoCommand>, IProcedimentoTipoAppService
    {
        private readonly IProcedimentoTipoRepository _repository;

        public ProcedimentoTipoAppService(IMapper mapper,
                                          IProcedimentoTipoRepository repository,
                                          IMediatorHandler bus) : base(mapper, repository, bus)
        {
            _repository = repository;
        }
    }
}
