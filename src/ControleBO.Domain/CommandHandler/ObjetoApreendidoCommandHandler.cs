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
    public class ObjetoApreendidoCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewObjetoApreendidoCommand, int>,
        IRequestHandler<UpdateObjetoApreendidoCommand, int>,
        IRequestHandler<RemoveObjetoApreendidoCommand, int>
    {
        private readonly IObjetoApreendidoRepository _objetoApreendidoRepository;
        private readonly IProcedimentoRepository _procedimentoRepository;

        public ObjetoApreendidoCommandHandler(IObjetoApreendidoRepository objetoApreendidoRepository,
                                              IProcedimentoRepository procedimentoRepository,
                                              IUnitOfWork uow,
                                              IMediatorHandler bus,
                                              INotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            _objetoApreendidoRepository = objetoApreendidoRepository;
            _procedimentoRepository = procedimentoRepository;
        }

        public Task<int> Handle(RegisterNewObjetoApreendidoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            var procedimento = _procedimentoRepository.GetById(request.ProcedimentoId);

            if (procedimento == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Procedimento não foi encontrado."));
                return Task.FromResult(0);
            }

            var objetoApreendido = new ObjetoApreendido(request.Descricao, request.Local, procedimento, request.DataApreensao);

            if (_objetoApreendidoRepository.Exists(objetoApreendido.Descricao, request.ProcedimentoId))
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Objeto já está sendo usado."));
                return Task.FromResult(0);
            }

            _objetoApreendidoRepository.Add(objetoApreendido);

            if (Commit())
            {
                //TO DO
            }

            return Task.FromResult(objetoApreendido.Id);
        }

        public Task<int> Handle(UpdateObjetoApreendidoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            var procedimento = _procedimentoRepository.GetById(request.ProcedimentoId);

            if (procedimento == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Procedimento não foi encontrado."));
                return Task.FromResult(0);
            }

            var existingObjetoApreendido = _objetoApreendidoRepository.GetById(request.Id);

            if (existingObjetoApreendido == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Objeto não foi encontrado."));
                return Task.FromResult(0);
            }

            var objetoApreendido = new ObjetoApreendido(request.Id, request.Descricao, request.Local, procedimento, request.DataApreensao);

            existingObjetoApreendido.Descricao = objetoApreendido.Descricao;
            existingObjetoApreendido.Local = objetoApreendido.Local;
            existingObjetoApreendido.DataApreensao = objetoApreendido.DataApreensao;

            _objetoApreendidoRepository.Update(existingObjetoApreendido);

            if (Commit())
            {
                //TO DO
            }

            return Task.FromResult(existingObjetoApreendido.Id);
        }

        public Task<int> Handle(RemoveObjetoApreendidoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            var existingObjetoApreendido = _objetoApreendidoRepository.GetById(request.Id);

            if (existingObjetoApreendido == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Objeto não foi encontrado."));
                return Task.FromResult(0);
            }

            _objetoApreendidoRepository.Remove(existingObjetoApreendido.Id);


            if (Commit())
            {
                //TO DO
            }

            return Task.FromResult(request.Id);
        }
    }
}
