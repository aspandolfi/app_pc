using MediatR;

namespace ControleBO.Domain.Core.Events
{
    public class Message : IRequest
    {
        public string MessageType { get; protected set; }
        public int AggregateId { get; protected set; }

        public Message()
        {
            MessageType = GetType().Name;
        }
    }
}