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
    public class SituacaoProcedimentoCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewSituacaoProcedimentoCommand, int>,
        IRequestHandler<UpdateSituacaoProcedimentoCommand, int>,
        IRequestHandler<RemoveSituacaoProcedimentoCommand, int>
    {
        private readonly ISituacaoProcedimentoRepository _situacaoProcedimentoRepository;
        private readonly IProcedimentoRepository _procedimentoRepository;
        private readonly ISituacaoRepository _situacaoRepository;
        private readonly ISituacaoTipoRepository _situacaoTipoRepository;

        public SituacaoProcedimentoCommandHandler(ISituacaoProcedimentoRepository situacaoProcedimentoRepository,
                                                  IProcedimentoRepository procedimentoRepository,
                                                  ISituacaoRepository situacaoRepository,
                                                  ISituacaoTipoRepository situacaoTipoRepository,
                                                  IUnitOfWork uow,
                                                  IMediatorHandler bus,
                                                  INotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            _situacaoProcedimentoRepository = situacaoProcedimentoRepository;
            _procedimentoRepository = procedimentoRepository;
            _situacaoRepository = situacaoRepository;
            _situacaoTipoRepository = situacaoTipoRepository;
        }

        public Task<int> Handle(RegisterNewSituacaoProcedimentoCommand request, CancellationToken cancellationToken)
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

            var situacao = _situacaoRepository.GetById(request.SituacaoId);

            if (situacao == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "A Situação não foi encontrada."));
                return Task.FromResult(0);
            }

            SituacaoTipo tipoSituacao = null;

            if (request.SituacaoTipoId.HasValue)
            {
                tipoSituacao = _situacaoTipoRepository.GetById(request.SituacaoTipoId.Value);

                if (request.SituacaoTipoId.Value > 0 && tipoSituacao == null)
                {
                    Bus.RaiseEvent(new DomainNotification(request.MessageType, "O motivo não foi encontrado."));
                    return Task.FromResult(0);
                }
            }

            //if (_situacaoProcedimentoRepository.Exists(request.ProcedimentoId, request.SituacaoId, request.SituacaoTipoId))
            //{
            //    Bus.RaiseEvent(new DomainNotification(request.MessageType, "O procedimento encontra-se na situação atual. Nada pra atualizar."));
            //    return Task.FromResult(0);
            //}

            var situacaoProcedimento = new SituacaoProcedimento(procedimento, situacao, tipoSituacao, request.DataRelatorio, request.Observacao);

            _situacaoProcedimentoRepository.Add(situacaoProcedimento);

            if (Commit())
            {
                //TO DO
            }

            return Task.FromResult(situacaoProcedimento.Id);
        }

        public Task<int> Handle(UpdateSituacaoProcedimentoCommand request, CancellationToken cancellationToken)
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

            var situacao = _situacaoRepository.GetById(request.SituacaoId);

            if (situacao == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "A Situação não foi encontrada."));
                return Task.FromResult(0);
            }

            SituacaoTipo tipoSituacao = null;

            if (request.SituacaoTipoId.HasValue)
            {
                tipoSituacao = _situacaoTipoRepository.GetById(request.SituacaoTipoId.Value);

                if (request.SituacaoTipoId.Value > 0 && tipoSituacao == null)
                {
                    Bus.RaiseEvent(new DomainNotification(request.MessageType, "O motivo não foi encontrado."));
                    return Task.FromResult(0);
                }
            }

            var existingSituacaoProcedimento = _situacaoProcedimentoRepository.GetAsNoTracking(x=> x.Id == request.Id);

            var situacaoProcedimento = new SituacaoProcedimento(request.Id, procedimento, situacao, tipoSituacao, request.DataRelatorio, request.Observacao);

            if (!situacaoProcedimento.Equals(existingSituacaoProcedimento))
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O procedimento encontra-se na situação atual. Nada pra atualizar."));
                return Task.FromResult(0);
            }

            _situacaoProcedimentoRepository.Update(situacaoProcedimento);

            if (Commit())
            {
                //TO DO
            }

            return Task.FromResult(situacaoProcedimento.Id);
        }

        public Task<int> Handle(RemoveSituacaoProcedimentoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            var situacaoProcedimento = _situacaoProcedimentoRepository.GetById(request.Id);

            if (situacaoProcedimento == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "A situação atual não foi encontrada."));
                return Task.FromResult(0);
            }

            _situacaoProcedimentoRepository.Remove(situacaoProcedimento.Id);

            if (Commit())
            {
                // TO DO
            }

            return Task.FromResult(request.Id);
        }
    }
}
