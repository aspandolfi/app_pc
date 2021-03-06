﻿using ControleBO.Domain.Core.Models;
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
                            DateTime? dataFato,
                            DateTime? dataInstauracao,
                            string andamentoProcessual,
                            ProcedimentoTipo tipoProcedimento,
                            VaraCriminal varaCriminal,
                            Municipio comarca,
                            Assunto assunto,
                            Artigo artigo,
                            UnidadePolicial unidadePolicial,
                            Situacao situacaoAtual)
        {
            BoletimUnificado = boletimUnificado;
            BoletimOcorrencia = boletimOcorrencia;
            NumeroProcessual = numeroProcessual;
            Gampes = gampes;
            Anexos = anexos;
            LocalFato = localFato;
            DataFato = dataFato;
            DataInstauracao = dataInstauracao;
            AndamentoProcessual = andamentoProcessual;
            TipoProcedimento = tipoProcedimento;
            VaraCriminal = varaCriminal;
            Comarca = comarca;
            Assunto = assunto;
            Artigo = artigo;
            DelegaciaOrigem = unidadePolicial;
            SituacaoAtual = situacaoAtual;
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
                            DateTime? dataFato,
                            DateTime? dataInstauracao,
                            string andamentoProcessual,
                            ProcedimentoTipo tipoProcedimento,
                            VaraCriminal varaCriminal,
                            Municipio comarca,
                            Assunto assunto,
                            Artigo artigo,
                            UnidadePolicial unidadePolicial,
                            Situacao situacaoAtual)
            : this(boletimUnificado,
                   boletimOcorrencia,
                   numeroProcessual,
                   gampes,
                   anexos,
                   localFato,
                   dataFato,
                   dataInstauracao,
                   andamentoProcessual,
                   tipoProcedimento,
                   varaCriminal,
                   comarca,
                   assunto,
                   artigo,
                   unidadePolicial,
                   situacaoAtual)
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

        public DateTime? DataFato { get; set; }

        public DateTime? DataInstauracao { get; set; }

        public string AndamentoProcessual { get; set; }

        public int? TipoProcedimentoId { get; set; }

        public virtual ProcedimentoTipo TipoProcedimento { get; set; }

        public int? VaraCriminalId { get; set; }

        public virtual VaraCriminal VaraCriminal { get; set; }

        public int? ComarcaId { get; set; }

        public virtual Municipio Comarca { get; set; }

        public int? AssuntoId { get; set; }

        public virtual Assunto Assunto { get; set; }

        public int? ArtigoId { get; set; }

        public virtual Artigo Artigo { get; set; }

        public int? DelegaciaOrigemId { get; set; }

        public virtual UnidadePolicial DelegaciaOrigem { get; set; }

        public virtual ICollection<Vitima> Vitimas { get; set; }

        public virtual ICollection<Indiciado> Autores { get; set; }

        public virtual ICollection<ObjetoApreendido> ObjetosApreendidos { get; set; }

        public virtual ICollection<SituacaoProcedimento> HistoricoSituacoes { get; set; }

        public virtual ICollection<Movimentacao> HistoricoMovimentacoes { get; set; }

        public virtual Movimentacao UltimaMovimentacao => HistoricoMovimentacoes.LastOrDefault();

        public int SituacaoAtualId { get; set; }

        public virtual Situacao SituacaoAtual { get; set; }
    }
}
