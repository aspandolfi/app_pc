using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Core.Commands;
using ControleBO.Domain.Core.Notifications;
using ControleBO.Domain.Interfaces;
using MediatR;

namespace ControleBO.Domain.CommandHandler
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        protected readonly IMediatorHandler Bus;
        private readonly DomainNotificationHandler _notifications;

        public CommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _notifications = (DomainNotificationHandler)notifications;
            Bus = bus;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }

        public bool Commit()
        {
            if (_notifications.HasNotifications()) return false;
            if (_uow.Commit()) return true;

            Bus.RaiseEvent(new DomainNotification("Commit", "Tivemos um problema ao salvar os dados."));
            return false;
        }
    }
}
