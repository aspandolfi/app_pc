using Newtonsoft.Json;

namespace ControleBO.Application.ViewModels
{
    public class VitimaViewModel : PessoaViewModel
    {
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "procedimentoId")]
        public int ProcedimentoId { get; set; }
    }
}
