using Newtonsoft.Json;

namespace ControleBO.Application.ViewModels
{
    public class AutorViewModel : PessoaViewModel
    {
        [JsonProperty(PropertyName = "apelido")]
        public string Apelido { get; set; }

        [JsonProperty(PropertyName = "procedimentoId")]
        public int ProcedimentoId { get; set; }
    }
}
