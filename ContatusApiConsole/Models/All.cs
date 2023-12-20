using Newtonsoft.Json;
namespace ContatusApiConsole.Models
{

    public class All
    {
        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }

}