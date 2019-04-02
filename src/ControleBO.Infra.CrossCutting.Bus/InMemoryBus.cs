using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Core.Commands;
using ControleBO.Domain.Core.Events;
using MediatR;
using System.Threading.Tasks;

namespace ControleBO.Infra.CrossCutting.Bus
{
    public class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            //if (!@event.MessageType.Equals("DomainNotification"))
            //_eventStore?.Save(@event);

            return _mediator.Publish(@event);
        }

        public Task<int> SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }
    }
}
