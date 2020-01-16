using ControleBO.Application.ViewModels;
using System.Collections.Generic;

namespace ControleBO.Application.Interfaces
{
    public interface IObjetoApreendidoAppService : IAppServiceBase<ObjetoApreendidoViewModel>
    {
        IEnumerable<ObjetoApreendidoViewModel> GetByProcedimentoId(int procedimentoId);
    }
}
