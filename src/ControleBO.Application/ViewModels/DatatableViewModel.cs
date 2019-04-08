using Newtonsoft.Json;

namespace ControleBO.Application.ViewModels
{
    public class DatatableViewModel
    {
        [JsonProperty(PropertyName = "headers")]
        public DatatableHeaderTitleViewModel[] Headers { get; set; }

        [JsonProperty(PropertyName = "dataSet")]
        public object[][] DataSet { get; set; }
    }

    public class DatatableHeaderTitleViewModel
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
    }
}
