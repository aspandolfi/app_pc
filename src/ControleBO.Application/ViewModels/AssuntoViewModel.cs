using Newtonsoft.Json;

namespace ControleBO.Application.ViewModels
{
    public class AssuntoViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "descricao")]
        public string Descricao { get; set; }
    }
}
