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
    public class MovimentacaoCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewMovimentacaoCommand, int>,
        IRequestHandler<UpdateMovimentacaoCommand, int>,
        IRequestHandler<RemoveMovimentacaoCommand, int>
    {
        private readonly IMovimentacaoRepository _movimentacaoRepository;
        private readonly IProcedimentoRepository _procedimentoRepository;

        public MovimentacaoCommandHandler(IMovimentacaoRepository movimentacaoRepository,
                                          IProcedimentoRepository procedimentoRepository,
                                          IUnitOfWork uow,
                                          IMediatorHandler bus,
                                          INotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            _movimentacaoRepository = movimentacaoRepository;
            _procedimentoRepository = procedimentoRepository;
        }

        public Task<int> Handle(RegisterNewMovimentacaoCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Handle(UpdateMovimentacaoCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> Handle(RemoveMovimentacaoCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
