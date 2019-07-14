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
    public class SituacaoTipoCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewSituacaoTipoCommand, int>,
        IRequestHandler<UpdateSituacaoTipoCommand, int>,
        IRequestHandler<RemoveSituacaoTipoCommand, int>
    {
        private readonly ISituacaoTipoRepository _situacaoTipoRepository;
        private readonly ISituacaoRepository _situacaoRepository;

        public SituacaoTipoCommandHandler(ISituacaoTipoRepository situacaoTipoRepository,
                                          ISituacaoRepository situacaoRepository,
                                          IUnitOfWork uow,
                                          IMediatorHandler bus,
                                          INotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            _situacaoTipoRepository = situacaoTipoRepository;
            _situacaoRepository = situacaoRepository;
        }

        public Task<int> Handle(RegisterNewSituacaoTipoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            var situacao = _situacaoRepository.GetById(request.SituacaoId);

            if (situacao == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "A Situação não foi encontrada."));
                return Task.FromResult(0);
            }

            var tipoSituacao = new SituacaoTipo(request.Descricao, situacao);

            if (_situacaoTipoRepository.Exists(tipoSituacao.Descricao, tipoSituacao.Situacao.Id))
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Tipo já está sendo usado."));
                return Task.FromResult(0);
            }

            _situacaoTipoRepository.Add(tipoSituacao);

            if (Commit())
            {
                //TO DO
            }

            return Task.FromResult(tipoSituacao.Id);
        }

        public Task<int> Handle(UpdateSituacaoTipoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            var situacao = _situacaoRepository.GetById(request.SituacaoId);

            if (situacao == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "A Situação não foi encontrada."));
                return Task.FromResult(0);
            }

            var existingTipoSituacao = _situacaoTipoRepository.GetById(request.Id);

            if (existingTipoSituacao == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Tipo de Situação não foi encontrado."));
                return Task.FromResult(0);
            }

            if (_situacaoTipoRepository.Exists(request.Descricao, request.SituacaoId))
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Tipo já está sendo usado."));
                return Task.FromResult(0);
            }

            existingTipoSituacao.Descricao = request.Descricao;

            _situacaoTipoRepository.Update(existingTipoSituacao);

            if (Commit())
            {
                //TO DO
            }

            return Task.FromResult(existingTipoSituacao.Id);
        }

        public Task<int> Handle(RemoveSituacaoTipoCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
