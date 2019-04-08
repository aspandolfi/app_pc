using ControleBO.Application.ViewModels;
using System.Collections.Generic;

namespace ControleBO.Application.Interfaces
{
    public interface IVitimaAppService : IAppServiceBase<VitimaViewModel>
    {
        IEnumerable<VitimaViewModel> GetVitimasByText(string text);
    }
}
