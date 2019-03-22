using System;
using System.Collections.Generic;

namespace ControleBO.Application.Interfaces
{
    public interface IAppServiceBase<TViewModel> : IDisposable
    {
        void Register(TViewModel tViewModel);
        IEnumerable<TViewModel> GetAll();
        TViewModel GetById(int id);
        void Update(TViewModel tViewModel);
        void Remove(int id);
        IEnumerable<TViewModel> GetPaged(int page, int pageSize);

        //IList<CustomerHistoryData> GetAllHistory(Guid id);
    }
}
