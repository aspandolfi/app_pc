using MediatR;

namespace ControleBO.Domain.Core.Events
{
    public class Message : IRequest<int>
    {
        public string MessageType { get; protected set; }
        public int AggregateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}