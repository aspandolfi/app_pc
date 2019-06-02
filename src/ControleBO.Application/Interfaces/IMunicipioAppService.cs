using ControleBO.Application.ViewModels;
using System.Collections.Generic;

namespace ControleBO.Application.Interfaces
{
    public interface IMunicipioAppService : IAppServiceBase<MunicipioViewModel>
    {
        List<MunicipioViewModel> GetAllByText(string text);
    }
}
