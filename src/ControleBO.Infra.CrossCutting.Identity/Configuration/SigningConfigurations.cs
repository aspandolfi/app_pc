using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ControleBO.Infra.CrossCutting.Identity.Configuration
{
    public class SigningConfigurations
    {
        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        public SigningConfigurations()
        {
            var keyByteArray = Encoding.ASCII.GetBytes("AspNetCore_ControleProcedimentos");

            //using (var provider = new RSACryptoServiceProvider(2048))
            //{
            //    Key = new RsaSecurityKey(provider.ExportParameters(true));
            //}

            Key = new SymmetricSecurityKey(keyByteArray);

            SigningCredentials = new SigningCredentials(
                Key, SecurityAlgorithms.HmacSha256);
        }

        public static SigningConfigurations Create()
        {
            return new SigningConfigurations();
        }
    }
}
