using Newtonsoft.Json;

namespace ContatusApiConsole.Models
{
    public class Child
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("dreEntryId")]
        public int DreEntryId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("cells")]
        public List<double> Cells { get; set; }

        [JsonProperty("children")]
        public List<Child> Children { get; set; }
    }
}