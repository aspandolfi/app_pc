using AutoMapper;
using ControleBO.Application.ViewModels;
using ControleBO.Domain.DataObjects;
using ControleBO.Domain.Models;

namespace ControleBO.Application.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProcedimentoTipo, ProcedimentoTipoViewModel>();
            CreateMap<Municipio, MunicipioViewModel>();
            CreateMap<DatatableObject, DatatableViewModel>();
            CreateMap<Vitima, VitimaViewModel>();
            CreateMap<Indiciado, IndiciadoViewModel>();
        }
    }
}
