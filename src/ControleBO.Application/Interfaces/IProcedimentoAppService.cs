using ControleBO.Application.ViewModels;
using System.Collections.Generic;

namespace ControleBO.Application.Interfaces
{
    public interface IProcedimentoAppService : IAppServiceBase<ProcedimentoViewModel>
    {
        DatatableViewModel GetAllAsDatatable();
        DatatableViewModel GetAllPagedAsDatatable(int page, int pageSize = 10);
        DatatableQueryResultViewModel GetAllQueryableAsDatatable(DatatableQueryInputViewModel datatableQuery);
        IEnumerable<ProcedimentoListViewModel> GetAllAsListViewModel();
    }
}
