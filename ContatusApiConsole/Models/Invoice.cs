using Newtonsoft.Json;

namespace ContatusApiConsole.Models
{
    public class Invoice
    {
        [JsonProperty("number")]
        public object Number { get; set; }

        [JsonProperty("rps")]
        public object Rps { get; set; }

        [JsonProperty("type")]
        public object Type { get; set; }
    }
}