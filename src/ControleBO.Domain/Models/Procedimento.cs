using ControleBO.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleBO.Domain.Models
{
    public class Procedimento : Entity
    {
        public Procedimento(string boletimUnificado,
                            string boletimOcorrencia,
                            string numeroProcessual,
                            string gampes,
                            string anexos,
                            string localFato,
                            DateTime dataFato,
                            DateTime? dataInstauracao,
                            string tipoCriminal,
                            string andamentoProcessual,
                            ProcedimentoTipo tipoProcedimento,
                            VaraCriminal varaCriminal,
                            Municipio comarca,
                            Assunto assunto,
                            Artigo artigo)
        {
            BoletimUnificado = boletimUnificado;
            BoletimOcorrencia = boletimOcorrencia;
            NumeroProcessual = numeroProcessual;
            Gampes = gampes;
            Anexos = anexos;
            LocalFato = localFato;
            DataFato = dataFato;
            DataInstauracao = dataInstauracao;
            TipoCriminal = tipoCriminal;
            AndamentoProcessual = andamentoProcessual;
            TipoProcedimento = tipoProcedimento;
            VaraCriminal = varaCriminal;
            Comarca = comarca;
            Assunto = assunto;
            Artigo = artigo;
            Vitimas = new HashSet<Vitima>();
            Autores = new HashSet<Indiciado>();
            ObjetosApreendidos = new HashSet<ObjetoApreendido>();
            HistoricoSituacoes = new HashSet<SituacaoProcedimento>();
            HistoricoMovimentacoes = new HashSet<Movimentacao>();
        }

        public Procedimento(int id,
                            string boletimUnificado,
                            string boletimOcorrencia,
                            string numeroProcessual,
                            string gampes,
                            string anexos,
                            string localFato,
                            DateTime dataFato,
                            DateTime? dataInstauracao,
                            string tipoCriminal,
                            string andamentoProcessual,
                            ProcedimentoTipo tipoProcedimento,
                            VaraCriminal varaCriminal,
                            Municipio comarca,
                            Assunto assunto,
                            Artigo artigo)
            : this(boletimUnificado,
                   boletimOcorrencia,
                   numeroProcessual,
                   gampes,
                   anexos,
                   localFato,
                   dataFato,
                   dataInstauracao,
                   tipoCriminal,
                   andamentoProcessual,
                   tipoProcedimento,
                   varaCriminal,
                   comarca,
                   assunto,
                   artigo)
        {
            Id = id;
        }

        protected Procedimento() { }

        public string BoletimUnificado { get; set; }

        public string BoletimOcorrencia { get; set; }

        public string NumeroProcessual { get; set; }

        public string Gampes { get; set; }

        public string Anexos { get; set; }

        public string LocalFato { get; set; }

        public DateTime DataFato { get; set; }

        public DateTime? DataInstauracao { get; set; }

        public string TipoCriminal { get; set; }

        public string AndamentoProcessual { get; set; }

        public virtual ProcedimentoTipo TipoProcedimento { get; set; }

        public virtual VaraCriminal VaraCriminal { get; set; }

        public virtual Municipio Comarca { get; set; }

        public virtual Assunto Assunto { get; set; }

        public virtual Artigo Artigo { get; set; }

        public virtual UnidadePolicial DelegaciaOrigem { get; set; }

        public virtual ICollection<Vitima> Vitimas { get; set; }

        public virtual ICollection<Indiciado> Autores { get; set; }

        public virtual ICollection<ObjetoApreendido> ObjetosApreendidos { get; set; }

        public virtual ICollection<SituacaoProcedimento> HistoricoSituacoes { get; set; }

        public virtual ICollection<Movimentacao> HistoricoMovimentacoes { get; set; }


        public Movimentacao UltimaMovimentacao => HistoricoMovimentacoes.LastOrDefault();

        public SituacaoProcedimento SituacaoAtual => HistoricoSituacoes.LastOrDefault();

    }
}
