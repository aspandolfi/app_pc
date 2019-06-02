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
    public class IndiciadoCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewIndiciadoCommand, int>,
        IRequestHandler<UpdateIndiciadoCommand, int>,
        IRequestHandler<RemoveIndiciadoCommand, int>
    {
        private readonly IIndiciadoRepository _indiciadoRepository;
        private readonly IProcedimentoRepository _procedimentoRepository;
        private readonly IMunicipioRepository _municipioRepository;

        public IndiciadoCommandHandler(IIndiciadoRepository indiciadoRepository,
                                       IProcedimentoRepository procedimentoRepository,
                                       IMunicipioRepository municipioRepository,
                                       IUnitOfWork uow,
                                       IMediatorHandler bus,
                                       INotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            _indiciadoRepository = indiciadoRepository;
            _procedimentoRepository = procedimentoRepository;
            _municipioRepository = municipioRepository;
        }

        public Task<int> Handle(RegisterNewIndiciadoCommand request, CancellationToken cancellationToken)
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

            var municipio = _municipioRepository.GetById(request.MunicipioId);

            if (request.MunicipioId > 0 && municipio == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Município não foi encontrado."));
                return Task.FromResult(0);
            }

            if (_indiciadoRepository.Exists(request.Nome, request.ProcedimentoId.ToString()))
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "A Indiciado já está sendo usada."));
                return Task.FromResult(0);
            }

            var indiciado = new Indiciado(request.Apelido, procedimento, request.Nome, request.NomePai, request.NomeMae, request.DataNascimento, request.Idade, request.Telefone, municipio);

            _indiciadoRepository.Add(indiciado);

            if (Commit())
            {
                //TO DO
            }

            return Task.FromResult(indiciado.Id);
        }

        public Task<int> Handle(UpdateIndiciadoCommand request, CancellationToken cancellationToken)
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

            var municipio = _municipioRepository.GetById(request.MunicipioId);

            if (request.MunicipioId > 0 && municipio == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Município não foi encontrado."));
                return Task.FromResult(0);
            }

            var indiciado = new Indiciado(request.Id, request.Apelido, procedimento, request.Nome, request.NomePai, request.NomeMae, request.DataNascimento, request.Idade, request.Telefone, municipio);
            var existingIndiciado = _indiciadoRepository.Get(x => x.Nome.Contains(request.Nome) && x.ProcedimentoId == request.ProcedimentoId);

            if (indiciado.Equals(existingIndiciado))
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Indiciado já está sendo usado."));
                return Task.FromResult(0);
            }

            _indiciadoRepository.Update(indiciado);

            if (Commit())
            {
                //TO DO
            }

            return Task.FromResult(indiciado.Id);
        }

        public Task<int> Handle(RemoveIndiciadoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            var indiciado = _indiciadoRepository.GetById(request.Id);

            if (indiciado == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Indiciado não foi encontrado."));
                return Task.FromResult(0);
            }

            _indiciadoRepository.Remove(indiciado.Id);

            if (Commit())
            {
                // TO DO
            }

            return Task.FromResult(request.Id);
        }
    }
}
