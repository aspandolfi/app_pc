namespace ControleBO.Domain.Core.Events
{
    public interface IHandle<in T> where T : Message
    {
        void Handle(T message);
    }
}
