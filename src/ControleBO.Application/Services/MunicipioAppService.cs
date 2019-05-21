using AutoMapper;
using ControleBO.Application.Interfaces;
using ControleBO.Application.ViewModels;
using ControleBO.Domain.Commands;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;

namespace ControleBO.Application.Services
{
    public class MunicipioAppService : AppServiceBase<MunicipioViewModel,
                                                      Municipio,
                                                      RegisterNewMunicipioCommand,
                                                      UpdateMunicipioCommand,
                                                      RemoveMunicipioCommand>,
                                        IMunicipioAppService
    {
        public MunicipioAppService(IMapper mapper, IMunicipioRepository repository, IMediatorHandler bus) : base(mapper, repository, bus)
        {
        }
    }
}
