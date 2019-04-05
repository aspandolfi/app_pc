using ControleBO.Domain.Commands;
using ControleBO.Domain.Core.Bus;
using ControleBO.Domain.Core.Notifications;
using ControleBO.Domain.Interfaces;
using ControleBO.Domain.Interfaces.Repositories;
using ControleBO.Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ControleBO.Domain.CommandHandler
{
    public class MunicipioCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewMunicipioCommand, int>,
        IRequestHandler<UpdateMunicipioCommand, int>,
        IRequestHandler<RemoveMunicipioCommand, int>
    {
        private readonly IMunicipioRepository _municipioRepository;

        public MunicipioCommandHandler(IMunicipioRepository municipioRepository,
                                       IUnitOfWork uow,
                                       IMediatorHandler bus,
                                       INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _municipioRepository = municipioRepository;
        }

        public Task<int> Handle(RegisterNewMunicipioCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            var municipio = new Municipio(request.Nome, request.UF, request.CEP);

            if (_municipioRepository.Exists(municipio.Nome, municipio.UF))
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Município já está existe."));
                return Task.FromResult(0);
            }

            _municipioRepository.Add(municipio);

            if (Commit())
            {
                //TO DO
            }

            return Task.FromResult(municipio.Id);
        }

        public Task<int> Handle(UpdateMunicipioCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<int> Handle(RemoveMunicipioCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
