using Newtonsoft.Json;

namespace ContatusApiConsole.Models
{
    public class Cell
    {
        [JsonProperty("predicted")]
        public double Predicted { get; set; }

        [JsonProperty("accomplished")]
        public double Accomplished { get; set; }

        [JsonProperty("period")]
        public string Period { get; set; }
    }
}