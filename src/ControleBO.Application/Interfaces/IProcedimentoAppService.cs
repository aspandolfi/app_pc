using ControleBO.Application.ViewModels;

namespace ControleBO.Application.Interfaces
{
    public interface IProcedimentoAppService : IAppServiceBase<ProcedimentoViewModel>
    {
        DatatableViewModel GetAllAsDatatable();
        DatatableViewModel GetAllPagedAsDatatable(int page, int pageSize = 10);
        DatatableQueryResultViewModel GetAllQueryableAsDatatable(DatatableQueryInputViewModel datatableQuery);
    }
}
