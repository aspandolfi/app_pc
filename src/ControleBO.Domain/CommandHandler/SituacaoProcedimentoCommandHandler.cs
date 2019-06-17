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
    public class SituacaoProcedimentoCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewSituacaoProcedimentoCommand, int>,
        IRequestHandler<UpdateSituacaoProcedimentoCommand, int>,
        IRequestHandler<RemoveSituacaoProcedimentoCommand, int>
    {
        private readonly ISituacaoProcedimentoRepository _situacaoProcedimentoRepository;
        private readonly IProcedimentoRepository _procedimentoRepository;
        private readonly ISituacaoRepository _situacaoRepository;

        public SituacaoProcedimentoCommandHandler(ISituacaoProcedimentoRepository situacaoProcedimentoRepository,
                                                  IProcedimentoRepository procedimentoRepository,
                                                  ISituacaoRepository situacaoRepository,
                                                  IUnitOfWork uow,
                                                  IMediatorHandler bus,
                                                  INotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            _situacaoProcedimentoRepository = situacaoProcedimentoRepository;
            _procedimentoRepository = procedimentoRepository;
            _situacaoRepository = situacaoRepository;
        }

        public Task<int> Handle(RegisterNewSituacaoProcedimentoCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Handle(UpdateSituacaoProcedimentoCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Handle(RemoveSituacaoProcedimentoCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
