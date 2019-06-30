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
    public class AssuntoCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewAssuntoCommand, int>,
        IRequestHandler<UpdateAssuntoCommand, int>,
        IRequestHandler<RemoveAssuntoCommand, int>
    {
        private readonly IAssuntoRepository _assuntoRepository;

        public AssuntoCommandHandler(IAssuntoRepository assuntoRepository,
                                     IUnitOfWork uow,
                                     IMediatorHandler bus,
                                     INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _assuntoRepository = assuntoRepository;
        }

        public Task<int> Handle(RegisterNewAssuntoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            var assunto = new Assunto(request.Descricao);

            if (_assuntoRepository.Exists(assunto.Descricao))
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Assunto já está sendo usado."));
                return Task.FromResult(0);
            }

            _assuntoRepository.Add(assunto);

            if (Commit())
            {
                //TO DO
            }

            return Task.FromResult(assunto.Id);
        }

        public Task<int> Handle(UpdateAssuntoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            var assunto = new Assunto(request.Id, request.Descricao);
            var existingAssunto = _assuntoRepository.GetAsNoTracking(x => assunto.Descricao.Contains(x.Descricao));

            if (!existingAssunto.Equals(assunto))
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Assunto já está sendo usado."));
                return Task.FromResult(0);
            }

            _assuntoRepository.Update(assunto);

            if (Commit())
            {
                //TO DO
            }

            return Task.FromResult(assunto.Id);
        }

        public Task<int> Handle(RemoveAssuntoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            var assunto = _assuntoRepository.GetById(request.Id);

            if (assunto == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Assunto não foi encontrado."));
                return Task.FromResult(0);
            }

            _assuntoRepository.Remove(assunto.Id);

            if (Commit())
            {
                // TO DO
            }

            return Task.FromResult(request.Id);
        }
    }
}
