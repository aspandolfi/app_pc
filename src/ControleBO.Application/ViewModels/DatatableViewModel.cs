using Newtonsoft.Json;

namespace ControleBO.Application.ViewModels
{
    public class DataTableViewModel
    {
        [JsonProperty(PropertyName = "headers")]
        public DataTableHeaderTitleViewModel[] Headers { get; set; }

        [JsonProperty(PropertyName = "dataSet")]
        public object[][] DataSet { get; set; }
    }

    public class DataTableHeaderTitleViewModel
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
    }
}
