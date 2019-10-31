using ControleBO.Domain.Core.Commands;
using System;
using System.Collections.Generic;

namespace ControleBO.Domain.Commands
{
    public abstract class ProcedimentoCommand : Command
    {
        private string _boletimUnificado;
        private string _boletimOcorrencia;
        private string _numeroProcessual;
        private string _gampes;
        private string _anexos;
        private string _localFato;
        private string _tipoCriminal;
        private string _andamentoProcessual;

        public int Id { get; protected set; }

        public string BoletimUnificado
        {
            get
            {
                return _boletimUnificado;
            }
            protected set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _boletimUnificado = value.Trim();
                }
            }
        }

        public string BoletimOcorrencia
        {
            get
            {
                return _boletimOcorrencia;
            }
            protected set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _boletimOcorrencia = value.Trim();
                }
            }
        }

        public string NumeroProcessual
        {
            get
            {
                return _numeroProcessual;
            }
            protected set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _numeroProcessual = value.Trim();
                }
            }
        }

        public string Gampes
        {
            get
            {
                return _gampes;
            }
            protected set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _gampes = value.Trim();
                }
            }
        }

        public string Anexos
        {
            get
            {
                return _anexos;
            }
            protected set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _anexos = value.Trim();
                }
            }
        }

        public string LocalFato
        {
            get
            {
                return _localFato;
            }
            protected set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _localFato = value.Trim();
                }
            }
        }

        public DateTime? DataFato { get; protected set; }

        public DateTime? DataInstauracao { get; protected set; }

        public string TipoCriminal
        {
            get
            {
                return _tipoCriminal;
            }
            protected set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _tipoCriminal = value.Trim();
                }
            }
        }

        public string AndamentoProcessual
        {
            get
            {
                return _andamentoProcessual;
            }
            protected set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _andamentoProcessual = value.Trim();
                }
            }
        }

        public int? TipoProcedimentoId { get; protected set; }

        public int? VaraCriminalId { get; protected set; }

        public int? ComarcaId { get; protected set; }

        public int? AssuntoId { get; protected set; }

        public int? ArtigoId { get; protected set; }

        public int? DelegaciaOrigemId { get; protected set; }

        public IEnumerable<VitimaCommand> Vitimas { get; protected set; }

        public IEnumerable<IndiciadoCommand> Autores { get; protected set; }

        public IEnumerable<ObjetoApreendidoCommand> ObjetosApreendidos { get; protected set; }

        public IEnumerable<MovimentacaoCommand> Movimentacoes { get; protected set; }
    }
}
