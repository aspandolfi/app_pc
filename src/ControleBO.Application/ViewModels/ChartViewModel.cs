using Newtonsoft.Json;
using System.Collections.Generic;

namespace ControleBO.Application.ViewModels
{
    public class ChartViewModel
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "categories")]
        public IEnumerable<string> XAxisCategories { get; set; }

        [JsonProperty(PropertyName = "series")]
        public IEnumerable<ChartSerieViewModel> Series { get; set; }

        [JsonProperty(PropertyName = "yAxisTitle")]
        public string YAxisTitle { get; set; }

        public class ChartSerieViewModel
        {
            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }

            [JsonProperty(PropertyName = "colorByPoint")]
            public bool? ColorByPoint { get; set; } = null;

            [JsonProperty(PropertyName = "data")]
            public IEnumerable<dynamic> Data { get; set; }

            public class ChartPieData
            {
                [JsonProperty(PropertyName = "name")]
                public string Name { get; set; }

                [JsonProperty(PropertyName = "y")]
                public decimal Y { get; set; }
            }
        }
    }
}
