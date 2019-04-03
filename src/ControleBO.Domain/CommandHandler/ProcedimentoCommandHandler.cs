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
    public class ProcedimentoCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewProcedimentoCommand, int>,
        IRequestHandler<UpdateProcedimentoCommand, int>,
        IRequestHandler<RemoveProcedimentoCommand, int>
    {
        private readonly IProcedimentoRepository _procedimentoRepository;
        private readonly IProcedimentoTipoRepository _procedimentoTipoRepository;
        private readonly IArtigoRepository _artigoRepository;
        private readonly IAssuntoRepository _assuntoRepository;
        private readonly IMunicipioRepository _municipioRepository;
        private readonly IVaraCriminalRepository _varaCriminalRepository;

        public ProcedimentoCommandHandler(IProcedimentoRepository procedimentoRepository,
                                          IProcedimentoTipoRepository procedimentoTipoRepository,
                                          IArtigoRepository artigoRepository,
                                          IAssuntoRepository assuntoRepository,
                                          IMunicipioRepository municipioRepository,
                                          IVaraCriminalRepository varaCriminalRepository,
                                          IUnitOfWork uow,
                                          IMediatorHandler bus,
                                          INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _procedimentoRepository = procedimentoRepository;
            _procedimentoTipoRepository = procedimentoTipoRepository;
            _artigoRepository = artigoRepository;
            _assuntoRepository = assuntoRepository;
            _municipioRepository = municipioRepository;
            _varaCriminalRepository = varaCriminalRepository;
        }

        public Task<int> Handle(RegisterNewProcedimentoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            if (_procedimentoRepository.Exists(request.NumeroProcessual))
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Boletim Unificado já está sendo usado."));
                return Task.FromResult(0);
            }

            var tipoProcedimento = _procedimentoTipoRepository.GetById(request.TipoProcedimentoId);

            if (tipoProcedimento == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Tipo de Procedimento não foi encontrado."));
                return Task.FromResult(0);
            }

            var artigo = _artigoRepository.GetById(request.ArtigoId);

            if (artigo == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Artigo não foi encontrado."));
                return Task.FromResult(0);
            }

            var assunto = _assuntoRepository.GetById(request.AssuntoId);

            if (assunto == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Assunto não foi encontrado."));
                return Task.FromResult(0);
            }

            var municipio = _municipioRepository.GetById(request.ComarcaId);

            if (municipio == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "A Comarca não foi encontrada."));
                return Task.FromResult(0);
            }

            var varaCriminal = _varaCriminalRepository.GetById(request.VaraCriminalId);

            if (varaCriminal == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "A Vara Criminal não foi encontrada."));
                return Task.FromResult(0);
            }

            var procedimento = new Procedimento(request.BoletimUnificado, request.BoletimOcorrencia, request.NumeroProcessual, request.Gampes,
                                                request.Anexos, request.LocalFato, request.DataFato, request.DataInstauracao, request.TipoCriminal,
                                                request.AndamentoProcessual, tipoProcedimento, varaCriminal, municipio, assunto, artigo);

            _procedimentoRepository.Add(procedimento);

            if (Commit())
            {
                // TO DO: Raise Event
            }

            return Task.FromResult(procedimento.Id);
        }

        public Task<int> Handle(UpdateProcedimentoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            var tipoProcedimento = _procedimentoTipoRepository.GetById(request.TipoProcedimentoId);

            if (tipoProcedimento == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Tipo de Procedimento não foi encontrado."));
                return Task.FromResult(0);
            }

            var artigo = _artigoRepository.GetById(request.ArtigoId);

            if (artigo == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Artigo não foi encontrado."));
                return Task.FromResult(0);
            }

            var assunto = _assuntoRepository.GetById(request.AssuntoId);

            if (assunto == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Assunto não foi encontrado."));
                return Task.FromResult(0);
            }

            var municipio = _municipioRepository.GetById(request.ComarcaId);

            if (municipio == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "A Comarca não foi encontrada."));
                return Task.FromResult(0);
            }

            var varaCriminal = _varaCriminalRepository.GetById(request.VaraCriminalId);

            if (varaCriminal == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "A Vara Criminal não foi encontrada."));
                return Task.FromResult(0);
            }

            var existringProcedimento = _procedimentoRepository.Get(x => x.BoletimUnificado == request.BoletimUnificado);

            var procedimento = new Procedimento(request.Id, request.BoletimUnificado, request.BoletimOcorrencia, request.NumeroProcessual, request.Gampes,
                                                request.Anexos, request.LocalFato, request.DataFato, request.DataInstauracao, request.TipoCriminal,
                                                request.AndamentoProcessual, tipoProcedimento, varaCriminal, municipio, assunto, artigo);

            if (!existringProcedimento.Equals(procedimento))
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Boletim Unificado já está sendo usado."));
                return Task.FromResult(0);
            }

            _procedimentoRepository.Update(procedimento);

            if (Commit())
            {
                // TO DO: Raise Event
            }

            return Task.FromResult(procedimento.Id);
        }

        public Task<int> Handle(RemoveProcedimentoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            _procedimentoRepository.Remove(request.Id);

            if (Commit())
            {
                // TO DO: Raise Event
            }

            return Task.FromResult(request.Id);
        }
    }
}
