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
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            var municipio = new Municipio(request.Id, request.Nome, request.UF, request.CEP);

            var existingMunicipio = _municipioRepository.GetById(request.Id);

            if (existingMunicipio == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Município não foi encontrado."));
                return Task.FromResult(0);
            }

            existingMunicipio.Nome = municipio.Nome;
            existingMunicipio.UF = municipio.UF;
            existingMunicipio.CEP = municipio.CEP;

            if (!municipio.Equals(existingMunicipio))
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Município já está existe."));
                return Task.FromResult(0);
            }

            _municipioRepository.Update(existingMunicipio);

            if (Commit())
            {
                //TO DO
            }

            return Task.FromResult(municipio.Id);
        }

        public Task<int> Handle(RemoveMunicipioCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            var existingMunicipio = _municipioRepository.GetById(request.Id);

            if (existingMunicipio == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Município não foi encontrado."));
                return Task.FromResult(0);
            }

            _municipioRepository.Remove(existingMunicipio.Id);

            if (Commit())
            {
                //TO DO
            }

            return Task.FromResult(request.Id);
        }
    }
}
