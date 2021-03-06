﻿using ControleBO.Domain.Commands;

namespace ControleBO.Domain.Validations
{
    public class RegisterNewVitimaCommandValidation : VitimaValidation<RegisterNewVitimaCommand>
    {
        public RegisterNewVitimaCommandValidation()
        {
            ValidateEmail();
            ValidateNome();
            ValidateNomeMae();
            ValidateNomePai();
            ValidateDataNascimento();
            ValidateTelefone();
            ValidateMunicipio();
        }
    }
}
