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
    public class MunicipioAppService : AppServiceBase<MunicipioViewModel,
                                                      Municipio,
                                                      RegisterNewMunicipioCommand,
                                                      UpdateMunicipioCommand,
                                                      RemoveMunicipioCommand>,
                                        IMunicipioAppService
    {
        private IMemoryCache _cache;

        public MunicipioAppService(IMapper mapper,
                                   IMunicipioRepository repository,
                                   IMediatorHandler bus,
                                   IMemoryCache cache)
            : base(mapper, repository, bus)
        {
            _cache = cache;
        }

        public List<MunicipioViewModel> GetAllByText(string text)
        {
            return GetMunicipios(text);
        }

        private List<MunicipioViewModel> GetMunicipios(string text)
        {
            var municipios = _cache.Get<List<Municipio>>("_municipios");

            if (municipios == null)
            {
                municipios = Repository.GetAllAsNoTracking().ToList();
                _cache.GetOrCreate("_municipios", context =>
                {
                    context.SetAbsoluteExpiration(TimeSpan.FromHours(10));
                    context.SetPriority(CacheItemPriority.High);

                    return municipios;
                });
            }
            return Mapper.Map<List<MunicipioViewModel>>(municipios.Where(x => x.Nome.Contains(text)).Take(10));
        }
    }
}
