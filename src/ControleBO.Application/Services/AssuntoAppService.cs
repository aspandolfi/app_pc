using AutoMapper;
using ControleBO.Application.Interfaces;
using ControleBO.Application.ViewModels;
using ControleBO.Domain.Commands;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;

namespace ControleBO.Application.Services
{
    public class AssuntoAppService : AppServiceBase<AssuntoViewModel,
                                                    Assunto,
                                                    RegisterNewAssuntoCommand,
                                                    UpdateAssuntoCommand,
                                                    RemoveAssuntoCommand>,
                                    IAssuntoAppService
    {
        public AssuntoAppService(IMapper mapper, IAssuntoRepository repository, IMediatorHandler bus) : base(mapper, repository, bus)
        {
        }
    }
}
