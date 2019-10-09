using ControleBO.Application.ViewModels;
using System;

namespace ControleBO.Application.Interfaces
{
    public interface IRelatorioAppService : IDisposable
    {
        DataTableViewModel GetEstatisticaAssunto(DateTime? de, DateTime? ate);

        DataTableViewModel GetRelacaoProcedimentos(int? situacaoId, DateTime? de, DateTime? ate);

        DataTableViewModel GetRelacaoIndiciados();

        DataTableViewModel GetRelacaoVitimas();

    }
}
