using ControleBO.Application.ViewModels;

namespace ControleBO.Application.Interfaces
{
    public interface IObjetoApreendidoAppService : IAppServiceBase<ObjetoApreendidoViewModel>
    {
        ObjetoApreendidoViewModel GetByProcedimentoId(int procedimentoId);
    }
}
