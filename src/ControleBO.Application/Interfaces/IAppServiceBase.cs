using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleBO.Application.Interfaces
{
    public interface IAppServiceBase<TViewModel> : IDisposable
    {
        Task<int> Register(TViewModel tViewModel);
        IEnumerable<TViewModel> GetAll();
        TViewModel GetById(int id);
        void Update(TViewModel tViewModel);
        void Remove(int id);
        IEnumerable<TViewModel> GetPaged(int page, int pageSize);

        DateTime? UltimaAtualizacao();

        //IList<CustomerHistoryData> GetAllHistory(Guid id);
    }
}
