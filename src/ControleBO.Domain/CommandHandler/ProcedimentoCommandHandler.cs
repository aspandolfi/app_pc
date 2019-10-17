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
        private readonly IUnidadePolicialRepository _unidadePolicialRepository;
        private readonly ISituacaoProcedimentoRepository _situacaoProcedimentoRepository;
        private readonly ISituacaoRepository _situacaoRepository;
        private readonly IVitimaRepository _vitimaRepository;
        private readonly IIndiciadoRepository _indiciadoRepository;
        private readonly IMovimentacaoRepository _movimentacaoRepository;
        private readonly IObjetoApreendidoRepository _objetoApreendidoRepository;

        public ProcedimentoCommandHandler(IProcedimentoRepository procedimentoRepository,
                                          IProcedimentoTipoRepository procedimentoTipoRepository,
                                          IArtigoRepository artigoRepository,
                                          IAssuntoRepository assuntoRepository,
                                          IMunicipioRepository municipioRepository,
                                          IVaraCriminalRepository varaCriminalRepository,
                                          IUnidadePolicialRepository unidadePolicialRepository,
                                          ISituacaoProcedimentoRepository situacaoProcedimentoRepository,
                                          ISituacaoRepository situacaoRepository,
                                          IVitimaRepository vitimaRepository,
                                          IIndiciadoRepository indiciadoRepository,
                                          IMovimentacaoRepository movimentacaoRepository,
                                          IObjetoApreendidoRepository objetoApreendidoRepository,
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
            _unidadePolicialRepository = unidadePolicialRepository;
            _situacaoProcedimentoRepository = situacaoProcedimentoRepository;
            _situacaoRepository = situacaoRepository;
            _vitimaRepository = vitimaRepository;
            _indiciadoRepository = indiciadoRepository;
            _movimentacaoRepository = movimentacaoRepository;
            _objetoApreendidoRepository = objetoApreendidoRepository;
        }

        public Task<int> Handle(RegisterNewProcedimentoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(0);
            }

            if (!string.IsNullOrEmpty(request.NumeroProcessual))
            {
                if (_procedimentoRepository.Exists(request.NumeroProcessual))
                {
                    Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Número Processual já está sendo usado."));
                    return Task.FromResult(0);
                }
            }

            ProcedimentoTipo tipoProcedimento = null;

            if (request.TipoProcedimentoId.HasValue)
            {
                tipoProcedimento = _procedimentoTipoRepository.GetById(request.TipoProcedimentoId.Value);

                if (tipoProcedimento == null)
                {
                    Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Tipo de Procedimento não foi encontrado."));
                    return Task.FromResult(0);
                }
            }

            Artigo artigo = null;

            if (request.ArtigoId.HasValue)
            {
                artigo = _artigoRepository.GetById(request.ArtigoId.Value);

                if (artigo == null)
                {
                    Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Artigo não foi encontrado."));
                    return Task.FromResult(0);
                }
            }

            Assunto assunto = null;

            if (request.AssuntoId.HasValue)
            {
                assunto = _assuntoRepository.GetById(request.AssuntoId.Value);

                if (assunto == null)
                {
                    Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Assunto não foi encontrado."));
                    return Task.FromResult(0);
                }
            }

            Municipio municipio = null;

            if (request.ComarcaId.HasValue)
            {
                municipio = _municipioRepository.GetById(request.ComarcaId.Value);

                if (municipio == null)
                {
                    Bus.RaiseEvent(new DomainNotification(request.MessageType, "A Comarca não foi encontrada."));
                    return Task.FromResult(0);
                }
            }

            VaraCriminal varaCriminal = null;

            if (request.VaraCriminalId.HasValue)
            {
                varaCriminal = _varaCriminalRepository.GetById(request.VaraCriminalId.Value);

                if (varaCriminal == null)
                {
                    Bus.RaiseEvent(new DomainNotification(request.MessageType, "A Vara Criminal não foi encontrada."));
                    return Task.FromResult(0);
                }
            }

            UnidadePolicial unidadePolicial = null;

            if (request.DelegaciaOrigemId.HasValue)
            {
                unidadePolicial = _unidadePolicialRepository.GetById(request.DelegaciaOrigemId.Value);

                if (unidadePolicial == null)
                {
                    Bus.RaiseEvent(new DomainNotification(request.MessageType, "A Delegacia de Origem não foi encontrada."));
                    return Task.FromResult(0);
                }
            }

            var situacao = _situacaoRepository.GetById(1);

            var procedimento = new Procedimento(request.BoletimUnificado, request.BoletimOcorrencia, request.NumeroProcessual, request.Gampes,
                                                request.Anexos, request.LocalFato, request.DataFato, request.DataInstauracao, request.TipoCriminal,
                                                request.AndamentoProcessual, tipoProcedimento, varaCriminal, municipio, assunto, artigo, unidadePolicial, situacao);

            _procedimentoRepository.Add(procedimento);

            var situacaoProcedimento = new SituacaoProcedimento(procedimento, situacao);

            _situacaoProcedimentoRepository.Add(situacaoProcedimento);

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

            ProcedimentoTipo tipoProcedimento = null;

            if (request.TipoProcedimentoId.HasValue)
            {
                tipoProcedimento = _procedimentoTipoRepository.GetById(request.TipoProcedimentoId.Value);

                if (tipoProcedimento == null)
                {
                    Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Tipo de Procedimento não foi encontrado."));
                    return Task.FromResult(0);
                }
            }

            Artigo artigo = null;

            if (request.ArtigoId.HasValue)
            {
                artigo = _artigoRepository.GetById(request.ArtigoId.Value);

                if (artigo == null)
                {
                    Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Artigo não foi encontrado."));
                    return Task.FromResult(0);
                }
            }

            Assunto assunto = null;

            if (request.AssuntoId.HasValue)
            {
                assunto = _assuntoRepository.GetById(request.AssuntoId.Value);

                if (assunto == null)
                {
                    Bus.RaiseEvent(new DomainNotification(request.MessageType, "O Assunto não foi encontrado."));
                    return Task.FromResult(0);
                }
            }

            Municipio municipio = null;

            if (request.ComarcaId.HasValue)
            {
                municipio = _municipioRepository.GetById(request.ComarcaId.Value);

                if (municipio == null)
                {
                    Bus.RaiseEvent(new DomainNotification(request.MessageType, "A Comarca não foi encontrada."));
                    return Task.FromResult(0);
                }
            }

            VaraCriminal varaCriminal = null;

            if (request.VaraCriminalId.HasValue)
            {
                varaCriminal = _varaCriminalRepository.GetById(request.VaraCriminalId.Value);

                if (varaCriminal == null)
                {
                    Bus.RaiseEvent(new DomainNotification(request.MessageType, "A Vara Criminal não foi encontrada."));
                    return Task.FromResult(0);
                }
            }

            UnidadePolicial unidadePolicial = null;

            if (request.DelegaciaOrigemId.HasValue)
            {
                unidadePolicial = _unidadePolicialRepository.GetById(request.DelegaciaOrigemId.Value);

                if (unidadePolicial == null)
                {
                    Bus.RaiseEvent(new DomainNotification(request.MessageType, "A Delegacia de Origem não foi encontrada."));
                    return Task.FromResult(0);
                }
            }

            Procedimento existingProcedimento = null;

            if (!string.IsNullOrEmpty(request.NumeroProcessual))
            {
                existingProcedimento = _procedimentoRepository.GetAsNoTracking(x => x.NumeroProcessual.Contains(request.NumeroProcessual)
                                                                                          && x.Id != request.Id);
            }

            if (existingProcedimento != null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O número processual já está sendo usado."));
                return Task.FromResult(0);
            }

            existingProcedimento = _procedimentoRepository.GetAsNoTracking(x => x.Id == request.Id);

            if (existingProcedimento == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O procedimento não foi encontrado."));
                return Task.FromResult(0);
            }

            var situacaoAtual = _situacaoRepository.GetById(existingProcedimento.SituacaoAtualId);

            var procedimento = new Procedimento(request.Id, request.BoletimUnificado, request.BoletimOcorrencia, request.NumeroProcessual, request.Gampes,
                                                request.Anexos, request.LocalFato, request.DataFato, request.DataInstauracao, request.TipoCriminal,
                                                request.AndamentoProcessual, tipoProcedimento, varaCriminal, municipio, assunto, artigo, unidadePolicial, situacaoAtual);

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

            var procedimento = _procedimentoRepository.GetById(request.Id);

            if (procedimento == null)
            {
                Bus.RaiseEvent(new DomainNotification(request.MessageType, "O procedimento não foi encontrado."));
                return Task.FromResult(0);
            }

            _vitimaRepository.Remove(x => x.ProcedimentoId == request.Id);
            _indiciadoRepository.Remove(x => x.ProcedimentoId == request.Id);
            _movimentacaoRepository.Remove(x => x.ProcedimentoId == request.Id);
            _objetoApreendidoRepository.Remove(x => x.ProcedimentoId == request.Id);
            _situacaoProcedimentoRepository.Remove(x => x.ProcedimentoId == request.Id);

            _procedimentoRepository.Remove(request.Id);

            if (Commit())
            {
                // TO DO: Raise Event
            }

            return Task.FromResult(request.Id);
        }
    }
}
