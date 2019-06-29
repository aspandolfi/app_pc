using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleBO.Infra.CrossCutting.Identity.Models.ViewModels
{
    public class AuthenticationResultViewModel
    {
        public AuthenticationResultViewModel(bool authenticated,
                                             DateTime created,
                                             DateTime expiration,
                                             string token,
                                             string message = "OK")
        {
            Authenticated = authenticated;
            Created = created;
            Expiration = expiration;
            Token = token;
            Message = message;
        }

        [JsonProperty(PropertyName = "authenticated")]
        public bool Authenticated { get; } = true;

        [JsonProperty(PropertyName = "created")]
        public DateTime Created { get; }

        [JsonProperty(PropertyName = "expiration")]
        public DateTime Expiration { get; }

        [JsonProperty(PropertyName = "token")]
        public string Token { get; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; } = "OK";
    }
}
