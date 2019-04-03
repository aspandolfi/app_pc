using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Core.Notifications;
using ControleBO.Domain.Interfaces;
using ControleBO.Domain.Interfaces.Repositories;
using MediatR;

namespace ControleBO.Domain.CommandHandler
{
    public class VaraCriminalCommandHandler : CommandHandler
    {
        public VaraCriminalCommandHandler(IVaraCriminalRepository varaCriminalRepository,
                                          IUnitOfWork uow,
                                          IMediatorHandler bus,
                                          INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
        }
    }
}
