using AutoMapper;
using ControleBO.Application.Interfaces;
using ControleBO.Application.ViewModels;
using ControleBO.Domain.Commands;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;

namespace ControleBO.Application.Services
{
    public class UnidadePolicialAppService : AppServiceBase<UnidadePolicialViewModel,
                                                            UnidadePolicial,
                                                            RegisterNewUnidadePolicialCommand,
                                                            UpdateUnidadePolicialCommand,
                                                            RemoveUnidadePolicialCommand>,
                                             IUnidadePolicialAppService
    {
        public UnidadePolicialAppService(IMapper mapper, IUnidadePolicialRepository repository, IMediatorHandler bus) : base(mapper, repository, bus)
        {
        }
    }
}
