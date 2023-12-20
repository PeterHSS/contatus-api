using Newtonsoft.Json; 
namespace ContatusApiConsole.Models{ 

    public class Revenues
    {
        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
    }

}