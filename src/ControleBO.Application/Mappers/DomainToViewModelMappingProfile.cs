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
            CreateMap<DataTableObject, DataTableViewModel>();
            CreateMap<Vitima, VitimaViewModel>();
            CreateMap<Indiciado, IndiciadoViewModel>();
            CreateMap<Situacao, SituacaoViewModel>();
            CreateMap<SituacaoTipo, SituacaoTipoViewModel>();
            CreateMap<Movimentacao, MovimentacaoViewModel>();
            CreateMap<SituacaoProcedimento, SituacaoProcedimentoViewModel>();
            CreateMap<ObjetoApreendido, ObjetoApreendidoViewModel>();
        }
    }
}
