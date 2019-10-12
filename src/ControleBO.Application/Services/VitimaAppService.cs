using AutoMapper;
using ControleBO.Application.Interfaces;
using ControleBO.Application.ViewModels;
using ControleBO.Domain.Commands;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleBO.Application.Services
{
    public class VitimaAppService : AppServiceBase<VitimaViewModel, Vitima, RegisterNewVitimaCommand, UpdateVitimaCommand, RemoveVitimaCommand>, IVitimaAppService
    {
        private readonly IMemoryCache _cache;

        public VitimaAppService(IMapper mapper,
                                IVitimaRepository repository,
                                IMemoryCache cache,
                                IMediatorHandler bus)
            : base(mapper, repository, bus)
        {
            _cache = cache;
        }

        public IEnumerable<VitimaViewModel> GetAllByProcedimentoId(int procedimentoId)
        {
            var result = Repository.GetAllAsNoTracking(filter: x => x.ProcedimentoId == procedimentoId, orderBy: x => x.Nome, includes: x => x.Naturalidade).ToList();

            //var vitimas = VitimasCached();

            return Mapper.Map<IEnumerable<VitimaViewModel>>(result);
        }

        public IEnumerable<string> GetVitimasByText(string text)
        {
            var result = Repository.GetAllAsNoTracking<string>(v => v.Nome, v => v.Nome.Contains(text), null);

            return result;
        }

        private IEnumerable<Vitima> VitimasCached()
        {
            return _cache.GetOrCreate<IEnumerable<Vitima>>("vitimas", (entry) =>
            {
                entry.AbsoluteExpiration = DateTime.Now.AddHours(10D);

                if (entry.Value == null)
                {
                    var result = Repository.GetAllAsNoTracking().ToList();
                    entry.SetValue(result);
                }
                return entry.Value as IEnumerable<Vitima>;
            });
        }
    }
}
