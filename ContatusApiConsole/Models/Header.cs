using Newtonsoft.Json;

namespace ContatusApiConsole.Models
{
    public class Header
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("period")]
        public string Period { get; set; }
    }
}