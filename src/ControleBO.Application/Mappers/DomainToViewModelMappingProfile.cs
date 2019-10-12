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
            CreateMap<Procedimento, ProcedimentoViewModel>()
                .ForMember(dest => dest.AndamentoProcessual, opt => opt.MapFrom(src => src.SituacaoAtual.Descricao));
            CreateMap<ProcedimentoTipo, ProcedimentoTipoViewModel>();
            CreateMap<Municipio, MunicipioViewModel>();
            CreateMap<DataTableObject, DataTableViewModel>();
            CreateMap<DataTableHeaderTitle, DataTableHeaderTitleViewModel>();
            CreateMap<Vitima, VitimaViewModel>()
                .ForMember(dest => dest.Naturalidade, opt => opt.MapFrom(src => src.Naturalidade.Nome));
            CreateMap<Indiciado, IndiciadoViewModel>()
                .ForMember(dest => dest.Naturalidade, opt => opt.MapFrom(src => src.Naturalidade.Nome));
            CreateMap<Situacao, SituacaoViewModel>();
            CreateMap<SituacaoTipo, SituacaoTipoViewModel>();
            CreateMap<SituacaoProcedimento, SituacaoProcedimentoViewModel>();
            CreateMap<Movimentacao, MovimentacaoViewModel>();
            CreateMap<SituacaoProcedimento, SituacaoProcedimentoViewModel>();
            CreateMap<ObjetoApreendido, ObjetoApreendidoViewModel>();
            CreateMap<Artigo, ArtigoViewModel>();
            CreateMap<Assunto, AssuntoViewModel>();
            CreateMap<UnidadePolicial, UnidadePolicialViewModel>();
            CreateMap<VaraCriminal, VaraCriminalViewModel>();
        }
    }
}
