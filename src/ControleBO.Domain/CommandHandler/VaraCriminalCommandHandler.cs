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
    public class VaraCriminalCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewVaraCriminalCommand, int>,
        IRequestHandler<UpdateVaraCriminalCommand, int>,
        IRequestHandler<RemoveVaraCriminalCommand, int>
    {
        private readonly IVaraCriminalRepository _varaCriminalRepository;
        private readonly IProcedimentoRepository _procedimentoRepository;

        public VaraCriminalCommandHandler(IVaraCriminalRepository varaCriminalRepository,
                                          IProcedimentoRepository procedimentoRepository,
                                          IUnitOfWork uow,
                                          IMediatorHandler bus,
                                          INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _varaCriminalRepository = varaCriminalRepository;
            _procedimentoRepository = procedimentoRepository;
        }

        public Task<int> Handle(RegisterNewVaraCriminalCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            var varaCriminal = new VaraCriminal(request.Descricao);

            if (_varaCriminalRepository.Exists(varaCriminal.Descricao))
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "A Vara Criminal já está sendo usada."));
                return Task.FromResult(0);
            }

            _varaCriminalRepository.Add(varaCriminal);

            if (Commit())
            {
                // TO DO
            }

            return Task.FromResult(varaCriminal.Id);
        }

        public Task<int> Handle(UpdateVaraCriminalCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            var varaCriminal = new VaraCriminal(request.Id, request.Descricao);

            var existingVaraCriminal = _varaCriminalRepository.GetAsNoTracking(x => varaCriminal.Descricao.Contains(x.Descricao));

            if (!existingVaraCriminal.Equals(varaCriminal))
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "A Vara Criminal já está sendo usada."));
                return Task.FromResult(0);
            }

            _varaCriminalRepository.Update(varaCriminal);

            if (Commit())
            {
                //TO DO
            }

            return Task.FromResult(varaCriminal.Id);
        }

        public Task<int> Handle(RemoveVaraCriminalCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            if (_procedimentoRepository.Any(x => x.VaraCriminalId == request.Id))
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "Existem procedimentos associados a esta Vara Criminal."));
                return Task.FromResult(0);
            }

            var varaCriminal = _varaCriminalRepository.GetById(request.Id);

            if (varaCriminal == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "A Vara Criminal não foi encontrada."));
                return Task.FromResult(0);
            }

            _varaCriminalRepository.Remove(varaCriminal.Id);

            if (Commit())
            {
                // TO DO
            }

            return Task.FromResult(request.Id);
        }
    }
}
