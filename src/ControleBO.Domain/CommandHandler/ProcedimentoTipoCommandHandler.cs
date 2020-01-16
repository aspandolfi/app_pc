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
        private readonly IProcedimentoRepository _procedimentoRepository;

        public ProcedimentoTipoCommandHandler(IProcedimentoTipoRepository procedimentoTipoRepository,
                                              IProcedimentoRepository procedimentoRepository,
                                              IUnitOfWork uow,
                                              IMediatorHandler bus,
                                              INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _procedimentoTipoRepository = procedimentoTipoRepository;
            _procedimentoRepository = procedimentoRepository;
        }

        public Task<int> Handle(RegisterNewProcedimentoTipoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            var procedimentoTipo = new ProcedimentoTipo(request.Sigla, request.Descricao);

            if (_procedimentoTipoRepository.Exists(procedimentoTipo.Descricao, procedimentoTipo.Sigla))
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
            var existingProcedimentoTipo = _procedimentoTipoRepository.GetAsNoTracking(x => x.Id == procedimentoTipo.Id);

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

            if (_procedimentoRepository.Any(x => x.TipoProcedimentoId == request.Id))
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "Existem procedimentos associados a este Tipo de Procedimento."));
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
