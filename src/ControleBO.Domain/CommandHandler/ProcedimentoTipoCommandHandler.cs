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
    public class ProcedimentoTipoCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewProcedimentoTipoCommand, int>,
        IRequestHandler<UpdateProcedimentoTipoCommand, int>,
        IRequestHandler<RemoveProcedimentoTipoCommand, int>
    {
        private readonly IProcedimentoTipoRepository _procedimentoTipoRepository;

        public ProcedimentoTipoCommandHandler(IProcedimentoTipoRepository procedimentoTipoRepository,
                                              IUnitOfWork uow,
                                              IMediatorHandler bus,
                                              INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _procedimentoTipoRepository = procedimentoTipoRepository;
        }

        public Task<int> Handle(RegisterNewProcedimentoTipoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            var procedimentoTipo = new ProcedimentoTipo(request.Sigla, request.Descricao);

            if (_procedimentoTipoRepository.Exists(procedimentoTipo.Sigla))
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "A sigla já está sendo usada."));
                return Task.FromResult(0);
            }

            _procedimentoTipoRepository.Add(procedimentoTipo);

            if (Commit())
            {
                // TO DO: Raise Event
            }

            return Task.FromResult(procedimentoTipo.Id);
        }

        public Task<int> Handle(UpdateProcedimentoTipoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            var procedimentoTipo = new ProcedimentoTipo(request.Id, request.Sigla, request.Descricao);
            var existingProcedimentoTipo = _procedimentoTipoRepository.GetById(procedimentoTipo.Id);

            if (existingProcedimentoTipo != null)
            {
                if (!existingProcedimentoTipo.Equals(procedimentoTipo))
                {
                    Bus.RaiseEvent(new DomainNotification(request.MessageType, "A Sigla ou Descrição já está sendo usada."));
                    return Task.FromResult(0);
                }
            }

            _procedimentoTipoRepository.Update(procedimentoTipo);

            if (Commit())
            {
                // TO DO: Raise Event
            }

            return Task.FromResult(procedimentoTipo.Id);
        }

        public Task<int> Handle(RemoveProcedimentoTipoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            _procedimentoTipoRepository.Remove(request.Id);

            if (Commit())
            {
                // TO DO: Raise Event
            }

            return Task.FromResult(request.Id);
        }

        public void Dispose()
        {
            _procedimentoTipoRepository.Dispose();
        }
    }
}
