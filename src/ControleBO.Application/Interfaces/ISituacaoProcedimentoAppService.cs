using ControleBO.Application.ViewModels;

namespace ControleBO.Application.Interfaces
{
    public interface ISituacaoProcedimentoAppService : IAppServiceBase<SituacaoProcedimentoViewModel>
    {
        SituacaoProcedimentoViewModel GetCurrentByProcedimentoId(int procedimentoId);
    }
}
