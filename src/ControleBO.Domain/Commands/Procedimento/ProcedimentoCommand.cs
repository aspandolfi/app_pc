using ControleBO.Domain.Commands.Vitima;
using ControleBO.Domain.Core.Commands;
using System;
using System.Collections.Generic;

namespace ControleBO.Domain.Commands
{
    public abstract class ProcedimentoCommand : Command
    {
        public int Id { get; protected set; }

        public string BoletimUnificado { get; protected set; }

        public string BoletimOcorrencia { get; protected set; }

        public string NumeroProcessual { get; protected set; }

        public string Gampes { get; protected set; }

        public string Anexos { get; protected set; }

        public string LocalFato { get; protected set; }

        public DateTime DataFato { get; protected set; }

        public DateTime? DataInstauracao { get; protected set; }

        public string TipoCriminal { get; protected set; }

        public string AndamentoProcessual { get; protected set; }

        public int TipoProcedimento { get; protected set; }

        public int VaraCriminal { get; protected set; }

        public int Comarca { get; protected set; }

        public int Assunto { get; protected set; }

        public int Artigo { get; protected set; }

        public int DelegaciaOrigem { get; protected set; }

        public IEnumerable<VitimaCommand> Vitimas { get; protected set; }

        public IEnumerable<IndiciadoCommand> Autores { get; protected set; }

        public IEnumerable<ObjetoApreendidoCommand> ObjetosApreendidos { get; protected set; }
    }
}
