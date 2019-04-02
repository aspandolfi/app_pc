using ControleBO.Domain.Core.Commands;
using ControleBO.Domain.Core.Events;
using System.Threading.Tasks;

namespace ControleBO.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task<int> SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
