using ControleBO.Application.ViewModels;
using System.Collections.Generic;

namespace ControleBO.Application.Interfaces
{
    public interface IProcedimentoAppService : IAppServiceBase<ProcedimentoViewModel>
    {
        DataTableViewModel GetAllAsDatatable();
        DataTableViewModel GetAllPagedAsDatatable(int page, int pageSize = 10);
        DatatableQueryResultViewModel GetAllQueryableAsDatatable(DatatableQueryInputViewModel datatableQuery);
        IEnumerable<ProcedimentoListViewModel> GetAllAsListViewModel();
    }
}
