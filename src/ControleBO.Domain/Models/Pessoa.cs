using ControleBO.Domain.Core.Models;
using System;

namespace ControleBO.Domain.Models
{
    public abstract class Pessoa : Entity
    {
        private DateTime? _dataNascimento;
        private bool _menorIdade;
        private int? _idade;

        public Pessoa(string nome, string nomePai, string nomeMae, DateTime? dataNascimento, string telefone, Municipio naturalidade)
        {
            Nome = nome;
            NomePai = nomePai;
            NomeMae = nomeMae;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Naturalidade = naturalidade;
        }

        public Pessoa(int id, string nome, string nomePai, string nomeMae, DateTime? dataNascimento, string telefone, Municipio naturalidade)
            : this(nome, nomePai, nomeMae, dataNascimento, telefone, naturalidade)
        {
            Id = id;
        }

        protected Pessoa() { }

        public string Nome { get; set; }

        public string NomePai { get; set; }

        public string NomeMae { get; set; }

        public DateTime? DataNascimento
        {
            get
            {
                return _dataNascimento;
            }
            set
            {
                _dataNascimento = value;

                if (_dataNascimento.HasValue)
                {
                    _idade = (int?)((DateTime.Now - _dataNascimento.Value).TotalDays / 365);
                    _menorIdade = _idade < 18;
                }
            }
        }

        public int? Idade
        {
            get
            {
                return _idade;
            }
            private set
            {
                _idade = value;
            }
        }

        public bool MenorIdade
        {
            get
            {
                return _menorIdade;
            }
            private set
            {
                _menorIdade = value;
            }
        }

        public string Telefone { get; set; }

        public int? NaturalidadeId { get; set; }

        public virtual Municipio Naturalidade { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (!(obj is Pessoa))
            {
                return false;
            }

            var pessoa = obj as Pessoa;

            return string.Compare(pessoa.Nome, Nome, true) == 0 && pessoa.Id == Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
