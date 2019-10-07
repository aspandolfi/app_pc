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
    public class UnidadePolicialCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewUnidadePolicialCommand, int>,
        IRequestHandler<UpdateUnidadePolicialCommand, int>,
        IRequestHandler<RemoveUnidadePolicialCommand, int>
    {
        private readonly IUnidadePolicialRepository _unidadePolicialRepository;
        private readonly IProcedimentoRepository _procedimentoRepository;

        public UnidadePolicialCommandHandler(IUnidadePolicialRepository unidadePolicialRepository,
                                             IProcedimentoRepository procedimentoRepository,
                                             IUnitOfWork uow,
                                             IMediatorHandler bus,
                                             INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _unidadePolicialRepository = unidadePolicialRepository;
            _procedimentoRepository = procedimentoRepository;
        }

        public Task<int> Handle(RegisterNewUnidadePolicialCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            var unidadePolicial = new UnidadePolicial(request.Codigo, request.Sigla, request.Descricao, request.CodigoCargoQO);

            if (_unidadePolicialRepository.Exists(unidadePolicial.Descricao))
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "A Unidade Policial já existe."));
                return Task.FromResult(0);
            }

            _unidadePolicialRepository.Add(unidadePolicial);

            if (Commit())
            {
                //TO DO
            }

            return Task.FromResult(unidadePolicial.Id);
        }

        public Task<int> Handle(UpdateUnidadePolicialCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            var unidadePolicial = new UnidadePolicial(request.Id, request.Codigo, request.Sigla, request.Descricao, request.CodigoCargoQO);
            var existingUnidadePolicial = _unidadePolicialRepository.GetAsNoTracking(x => unidadePolicial.Descricao.Contains(x.Descricao));

            if (!existingUnidadePolicial.Equals(unidadePolicial))
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "A Unidade Policial já está sendo usada."));
                return Task.FromResult(0);
            }

            _unidadePolicialRepository.Update(unidadePolicial);

            if (Commit())
            {
                //TO DO
            }

            return Task.FromResult(unidadePolicial.Id);
        }

        public Task<int> Handle(RemoveUnidadePolicialCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            if (_procedimentoRepository.Any(x => x.DelegaciaOrigemId == request.Id))
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "Existem procedimentos associados a esta Unidade Policial."));
                return Task.FromResult(0);
            }

            var unidadePolicial = _unidadePolicialRepository.GetById(request.Id);

            if (unidadePolicial == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "A Unidade Policial não foi encontrada."));
                return Task.FromResult(0);
            }

            _unidadePolicialRepository.Remove(unidadePolicial.Id);

            if (Commit())
            {
                // TO DO
            }

            return Task.FromResult(request.Id);
        }
    }
}
