using ControleBO.Application.ViewModels;
using System.Collections.Generic;

namespace ControleBO.Application.Interfaces
{
    public interface IMovimentacaoAppService : IAppServiceBase<MovimentacaoViewModel>
    {
        IEnumerable<MovimentacaoViewModel> GetByProcedimentoId(int procedimentoId);
    }
}
