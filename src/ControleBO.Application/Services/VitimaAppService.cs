﻿using AutoMapper;
using ControleBO.Application.Interfaces;
using ControleBO.Application.ViewModels;
using ControleBO.Domain.Commands;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;
using System.Collections.Generic;

namespace ControleBO.Application.Services
{
    public class VitimaAppService : AppServiceBase<VitimaViewModel, Vitima, RegisterNewVitimaCommand, UpdateVitimaCommand, RemoveVitimaCommand>, IVitimaAppService
    {
        public VitimaAppService(IMapper mapper,
                                IVitimaRepository repository,
                                IMediatorHandler bus)
            : base(mapper, repository, bus)
        {
        }

        public IEnumerable<VitimaViewModel> GetAllByProcedimentoId(int procedimentoId)
        {
            var result = Repository.GetAllAsNoTracking(x => x.ProcedimentoId == procedimentoId, x => x.Nome);

            return Mapper.Map<IEnumerable<VitimaViewModel>>(result);
        }

        public IEnumerable<VitimaViewModel> GetVitimasByText(string text)
        {
            var result = Repository.GetAllAsNoTracking(x => text.Contains(x.Nome));

            return Mapper.Map<IEnumerable<VitimaViewModel>>(result);
        }
    }
}
