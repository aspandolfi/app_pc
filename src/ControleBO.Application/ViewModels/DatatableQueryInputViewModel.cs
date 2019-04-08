using Newtonsoft.Json;

namespace ControleBO.Application.ViewModels
{
    public class DatatableQueryInputViewModel
    {
        [JsonProperty(PropertyName = "draw")]
        public int Draw { get; set; }

        [JsonProperty(PropertyName = "order[0][column]")]
        public int OrderColumn { get; set; } = 1;

        [JsonProperty(PropertyName = "order[0][dir]")]
        public string OrderDir { get; set; }

        [JsonProperty(PropertyName = "start")]
        public int Start { get; set; }

        [JsonProperty(PropertyName = "length")]
        public int Length { get; set; }

        [JsonProperty(PropertyName = "search[value]")]
        public string TextToSearch { get; set; }
    }
}
