using ControleBO.Domain.Models;
using System;

namespace ControleBO.Domain.Interfaces.Repositories
{
    public interface ISituacaoTipoRepository : IRepository<SituacaoTipo>
    {
        DateTime? LastUpdate(int situacaoId);
    }
}
