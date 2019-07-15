using ControleBO.Application.ViewModels;
using System;

namespace ControleBO.Application.Interfaces
{
    public interface ISituacaoTipoAppService : IAppServiceBase<SituacaoTipoViewModel>
    {
        DateTime? UltimaAtualizacao(int situacaoId);
    }
}
