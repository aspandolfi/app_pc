using Newtonsoft.Json;
using System.Collections.Generic;

namespace ControleBO.Application.ViewModels
{
    public class DatatableQueryResultViewModel
    {
        [JsonProperty(PropertyName = "draw")]
        public int Draw { get; set; }

        [JsonProperty(PropertyName = "recordsTotal")]
        public int RecordsTotal { get; set; }

        [JsonProperty(PropertyName = "recordsFiltered")]
        public int RecordsFiltered { get; set; }

        [JsonProperty(PropertyName = "data")]
        public List<List<object>> Data { get; set; }

    }
}
