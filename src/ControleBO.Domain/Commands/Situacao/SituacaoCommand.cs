﻿using ControleBO.Domain.Core.Commands;

namespace ControleBO.Domain.Commands.Situacao
{
    public abstract class SituacaoCommand : Command
    {
        private string _descricao;

        public int Id { get; protected set; }

        public string Descricao
        {
            get
            {
                return _descricao;
            }
            protected set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _descricao = value.Trim();
                }
            }
        }
    }
}
