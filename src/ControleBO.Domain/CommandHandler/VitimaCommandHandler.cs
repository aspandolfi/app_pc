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
    public class VitimaCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewVitimaCommand, int>,
        IRequestHandler<UpdateVitimaCommand, int>,
        IRequestHandler<RemoveVitimaCommand, int>
    {
        private readonly IVitimaRepository _vitimaRepository;
        private readonly IProcedimentoRepository _procedimentoRepository;
        private readonly IMunicipioRepository _municipioRepository;

        public VitimaCommandHandler(IVitimaRepository vitimaRepository,
                                    IProcedimentoRepository procedimentoRepository,
                                    IMunicipioRepository municipioRepository,
                                    IUnitOfWork uow,
                                    IMediatorHandler bus,
                                    INotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            _vitimaRepository = vitimaRepository;
            _procedimentoRepository = procedimentoRepository;
            _municipioRepository = municipioRepository;
        }

        public Task<int> Handle(RegisterNewVitimaCommand request, CancellationToken cancellationToken)
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

            Municipio municipio = null;

            if (request.MunicipioId.HasValue)
            {
                municipio = _municipioRepository.GetById(request.MunicipioId.Value);

                if (request.MunicipioId > 0 && municipio == null)
                {
                    Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Município não foi encontrado."));
                    return Task.FromResult(0);
                }
            }

            if (_vitimaRepository.Exists(request.Nome, request.ProcedimentoId))
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "A Vítima já está sendo usada."));
                return Task.FromResult(0);
            }

            var vitima = new Vitima(request.Email, procedimento, request.Nome, request.NomePai, request.NomeMae, request.DataNascimento, request.Idade, request.Telefone, municipio);

            _vitimaRepository.Add(vitima);

            if (Commit())
            {
                //TO DO
            }

            return Task.FromResult(vitima.Id);
        }

        public Task<int> Handle(UpdateVitimaCommand request, CancellationToken cancellationToken)
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

            Municipio municipio = null;

            if (request.MunicipioId.HasValue)
            {
                municipio = _municipioRepository.GetById(request.MunicipioId.Value);

                if (request.MunicipioId > 0 && municipio == null)
                {
                    Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Município não foi encontrado."));
                    return Task.FromResult(0);
                }
            }

            var vitima = new Vitima(request.Id, request.Email, procedimento, request.Nome, request.NomePai, request.NomeMae, request.DataNascimento, request.Idade, request.Telefone, municipio);
            var existingVitima = _vitimaRepository.GetAsNoTracking(x => x.Nome.Contains(request.Nome) && x.ProcedimentoId == request.ProcedimentoId);

            if (!vitima.Equals(existingVitima))
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "A Vítima já está sendo usada."));
                return Task.FromResult(0);
            }

            _vitimaRepository.Update(vitima);

            if (Commit())
            {
                //TO DO
            }

            return Task.FromResult(vitima.Id);
        }

        public Task<int> Handle(RemoveVitimaCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            var vitima = _vitimaRepository.GetById(request.Id);

            if (vitima == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "A Vítima não foi encontrada."));
                return Task.FromResult(0);
            }

            _vitimaRepository.Remove(vitima.Id);

            if (Commit())
            {
                // TO DO
            }

            return Task.FromResult(request.Id);
        }
    }
}
