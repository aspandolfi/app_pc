using AutoMapper;
using ControleBO.Application.ViewModels;
using ControleBO.Domain.Models;

namespace ControleBO.Application.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProcedimentoTipo, ProcedimentoTipoViewModel>();
        }
    }
}
