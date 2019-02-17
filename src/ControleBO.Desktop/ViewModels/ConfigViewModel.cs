using Newtonsoft.Json;

namespace ControleBO.Desktop.ViewModels
{
    public class ConfigViewModel
    {
        [JsonProperty(PropertyName = "apiUrl")]
        public string ApiUrl { get; set; }
    }
}
