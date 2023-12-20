using Newtonsoft.Json;

namespace ContatusApiConsole.Models
{
    public class ValueComposition
    {
        [JsonProperty("grossValue")]
        public double GrossValue { get; set; }

        [JsonProperty("interest")]
        public double Interest { get; set; }

        [JsonProperty("fine")]
        public double Fine { get; set; }

        [JsonProperty("netValue")]
        public double NetValue { get; set; }

        [JsonProperty("discount")]
        public double Discount { get; set; }

        [JsonProperty("fee")]
        public double Fee { get; set; }
    }
}