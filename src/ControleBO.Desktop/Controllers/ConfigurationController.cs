using ControleBO.Desktop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;

namespace ControleBO.Desktop.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ConfigurationController : ControllerBase
    {
        // GET: api/Configuration
        [HttpGet]
        public IActionResult Get()
        {
            string dataPath = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();

            string combinePath = Path.Combine(dataPath, "environmentconfig.json");

            var config = JsonConvert.DeserializeObject<ConfigViewModel>(System.IO.File.ReadAllText(combinePath));

            return Ok(config);
        }

        // POST: api/Configuration
        [HttpPost]
        public IActionResult Post([FromBody] ConfigViewModel configVm)
        {
            JObject o = (JObject)JToken.FromObject(configVm);

            string dataPath = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();

            string combinePath = Path.Combine(dataPath, "environmentconfig.json");

            using (StreamWriter file = System.IO.File.CreateText(combinePath))
            using (JsonWriter writer = new JsonTextWriter(file))
            {
                o.WriteTo(writer);
            }

            return Ok(configVm);
        }
    }
}
