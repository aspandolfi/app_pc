using ControleBO.Domain.Commands;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Core.Notifications;
using ControleBO.Domain.Interfaces;
using ControleBO.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ControleBO.Domain.CommandHandler
{
    public class SituacaoCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewSituacaoCommand, int>,
        IRequestHandler<UpdateSituacaoCommand, int>,
        IRequestHandler<RemoveSituacaoCommand, int>
    {
        private readonly ISituacaoRepository _situacaoRepository;

        public SituacaoCommandHandler(ISituacaoRepository situacaoRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            _situacaoRepository = situacaoRepository;
        }

        public Task<int> Handle(RegisterNewSituacaoCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<int> Handle(UpdateSituacaoCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<int> Handle(RemoveSituacaoCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
