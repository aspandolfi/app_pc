using AutoMapper;
using ControleBO.Application.ViewModels;
using ControleBO.Domain.Commands;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;

namespace ControleBO.Application.Services
{
    public class ProcedimentoAppService : AppServiceBase<ProcedimentoViewModel,
                                                         Procedimento,
                                                         RegisterNewProcedimentoCommand,
                                                         UpdateProcedimentoCommand,
                                                         RemoveProcedimentoCommand>
    {
        public ProcedimentoAppService(IMapper mapper, IRepository<Procedimento> repository, IMediatorHandler bus)
            : base(mapper, repository, bus)
        {
        }
    }
}
