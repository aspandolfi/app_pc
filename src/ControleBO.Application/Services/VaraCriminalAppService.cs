using AutoMapper;
using ControleBO.Application.Interfaces;
using ControleBO.Application.ViewModels;
using ControleBO.Domain.Commands;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;

namespace ControleBO.Application.Services
{
    public class VaraCriminalAppService : AppServiceBase<VaraCriminalViewModel,
                                                         VaraCriminal,
                                                         RegisterNewVaraCriminalCommand,
                                                         UpdateVaraCriminalCommand,
                                                         RemoveVaraCriminalCommand>,
                                          IVaraCriminalAppService
    {
        public VaraCriminalAppService(IMapper mapper, IVaraCriminalRepository repository, IMediatorHandler bus) : base(mapper, repository, bus)
        {
        }
    }
}
