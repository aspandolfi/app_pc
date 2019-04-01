using ControleBO.Domain.Commands;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Core.Notifications;
using ControleBO.Domain.Interfaces;
using ControleBO.Domain.Interfaces.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ControleBO.Domain.CommandHandler
{
    public class ProcedimentoCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewProcedimentoCommand, bool>,
        IRequestHandler<UpdateProcedimentoCommand, bool>,
        IRequestHandler<RemoveProcedimentoCommand, bool>
    {
        private readonly IProcedimentoRepository _procedimentoRepository;
        private readonly IMediatorHandler _bus;

        public ProcedimentoCommandHandler(IProcedimentoRepository procedimentoRepository,
                                          IUnitOfWork uow,
                                          IMediatorHandler bus,
                                          INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _procedimentoRepository = procedimentoRepository;
            _bus = bus;
        }

        public Task<bool> Handle(RegisterNewProcedimentoCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Handle(UpdateProcedimentoCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Handle(RemoveProcedimentoCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
