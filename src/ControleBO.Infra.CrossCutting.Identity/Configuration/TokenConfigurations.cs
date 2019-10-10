namespace ControleBO.Infra.CrossCutting.Identity.Configuration
{
    public class TokenConfigurations
    {
        public const string RefreshToken = "RefreshToken";

        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
    }
}
