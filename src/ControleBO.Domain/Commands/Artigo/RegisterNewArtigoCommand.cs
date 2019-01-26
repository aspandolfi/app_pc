using System;

namespace ControleBO.Domain.Commands
{
    public class RegisterNewArtigoCommand : ArtigoCommand
    {
        public RegisterNewArtigoCommand(int id, string descricao)
        {
            Id = id;
            Descricao = Descricao;
        }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
