﻿using ControleBO.Domain.Core.Models;

namespace ControleBO.Domain.Models
{
    public class ProcedimentoTipo : Entity
    {
        public ProcedimentoTipo(string sigla, string descricao)
        {
            Sigla = sigla;
            Descricao = descricao;
        }

        public ProcedimentoTipo(int id, string sigla, string descricao)
            : this(sigla, descricao)
        {
            Id = id;
        }

        protected ProcedimentoTipo() { }

        public string Sigla { get; set; }

        public string Descricao { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (!(obj is ProcedimentoTipo))
            {
                return false;
            }

            var procedimentoTipo = obj as ProcedimentoTipo;

            return string.Compare(procedimentoTipo.Sigla, Sigla, true) == 0 ||
                   string.Compare(procedimentoTipo.Descricao, Descricao, true) == 0;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
