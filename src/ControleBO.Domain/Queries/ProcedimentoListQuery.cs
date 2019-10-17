using System;

namespace ControleBO.Domain.Queries
{
    public class ProcedimentoListQuery
    {
        public int Id { get; set; }

        public string BoletimUnificado { get; set; }

        public string BoletimOcorrencia { get; set; }

        public string NumeroProcessual { get; set; }

        public DateTime DataInsercao { get; set; }

        public string TipoProcedimento { get; set; }

        public string Comarca { get; set; }

        public string AndamentoProcessual { get; set; }

        public string Vitimas { get; set; }
    }
}
