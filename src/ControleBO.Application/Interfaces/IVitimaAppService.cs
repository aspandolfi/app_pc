using ControleBO.Application.ViewModels;
using System.Collections.Generic;

namespace ControleBO.Application.Interfaces
{
    public interface IVitimaAppService : IAppServiceBase<VitimaViewModel>
    {
        IEnumerable<string> GetVitimasByText(string text);
        IEnumerable<VitimaViewModel> GetAllByProcedimentoId(int procedimentoId);
    }
}
