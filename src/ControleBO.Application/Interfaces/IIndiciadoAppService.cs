using ControleBO.Application.ViewModels;
using System.Collections.Generic;

namespace ControleBO.Application.Interfaces
{
    public interface IIndiciadoAppService : IAppServiceBase<IndiciadoViewModel>
    {
        IEnumerable<IndiciadoViewModel> GetAllByProcedimentoId(int procedimento);
        IEnumerable<IndiciadoViewModel> GetIndiciadosByText(string text);
    }
}
