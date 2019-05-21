﻿using ControleBO.Domain.Commands;
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
    public class ArtigoCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewArtigoCommand, int>,
        IRequestHandler<UpdateArtigoCommand, int>,
        IRequestHandler<RemoveArtigoCommand, int>
    {
        private readonly IArtigoRepository _artigoRepository;

        public ArtigoCommandHandler(IArtigoRepository artigoRepository,
                                    IUnitOfWork uow,
                                    IMediatorHandler bus,
                                    INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _artigoRepository = artigoRepository;
        }

        public Task<int> Handle(RegisterNewArtigoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            var assunto = new Artigo(request.Descricao);

            if (_artigoRepository.Exists(assunto.Descricao))
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Artigo já está sendo usado."));
                return Task.FromResult(0);
            }

            _artigoRepository.Add(assunto);

            if (Commit())
            {
                //TO DO
            }

            return Task.FromResult(assunto.Id);
        }

        public Task<int> Handle(UpdateArtigoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            var assunto = new Artigo(request.Id, request.Descricao);
            var existingAssunto = _artigoRepository.Get(x => assunto.Descricao.Contains(x.Descricao));

            if (!existingAssunto.Equals(assunto))
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Artigo já está sendo usado."));
                return Task.FromResult(0);
            }

            _artigoRepository.Update(assunto);

            if (Commit())
            {
                //TO DO
            }

            return Task.FromResult(assunto.Id);
        }

        public Task<int> Handle(RemoveArtigoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            var assunto = _artigoRepository.GetById(request.Id);

            if (assunto == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Artigo não foi encontrado."));
                return Task.FromResult(0);
            }

            _artigoRepository.Remove(assunto.Id);

            if (Commit())
            {
                // TO DO
            }

            return Task.FromResult(request.Id);
        }
    }
}
