using ControleBO.Application.ViewModels;
using System;

namespace ControleBO.Application.Interfaces
{
    public interface IRelatorioAppService : IDisposable
    {
        DataTableViewModel GetEstatisticaAssunto();

        DataTableViewModel GetRelacaoProcedimentos(int situacaoId);

        DataTableViewModel GetRelacaoIndiciados();

    }
}
