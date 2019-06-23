using ControleBO.Domain.Commands;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Core.Notifications;
using ControleBO.Domain.Interfaces;
using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;
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
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            var procedimento = _procedimentoRepository.GetById(request.ProcedimentoId);

            if (procedimento == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O procedimento não foi encontrado."));
                return Task.FromResult(0);
            }

            if (_movimentacaoRepository.Exists(request.Destino, request.ProcedimentoId))
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "A Movimentação já está sendo usada."));
                return Task.FromResult(0);
            }

            var movimentacao = new Movimentacao(request.Destino, request.Data, procedimento);

            _movimentacaoRepository.Add(movimentacao);

            if (Commit())
            {
                //TO DO
            }

            return Task.FromResult(movimentacao.Id);
        }

        public Task<int> Handle(UpdateMovimentacaoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            var procedimento = _procedimentoRepository.GetById(request.ProcedimentoId);

            if (procedimento == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O procedimento não foi encontrado."));
                return Task.FromResult(0);
            }

            var existingMovimentacao = _movimentacaoRepository.GetAsNoTracking(x => x.Id == request.Id);

            if (existingMovimentacao == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "A Movimentação não foi encontrada."));
                return Task.FromResult(0);
            }

            var movimentacao = new Movimentacao(request.Id, request.Destino, request.Data, procedimento, request.RetornouEm);

            if (!movimentacao.Equals(existingMovimentacao))
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "A Movimentação não foi encontrada."));
                return Task.FromResult(0);
            }

            _movimentacaoRepository.Update(movimentacao);

            if (Commit())
            {
                //TO DO
            }

            return Task.FromResult(movimentacao.Id);
        }

        public Task<int> Handle(RemoveMovimentacaoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            var movimentacao = _movimentacaoRepository.GetById(request.Id);

            if (movimentacao == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "A Movimentação não foi encontrada."));
                return Task.FromResult(0);
            }

            _movimentacaoRepository.Remove(movimentacao.Id);

            if (Commit())
            {
                // TO DO
            }

            return Task.FromResult(request.Id);
        }
    }
}
