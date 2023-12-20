using Newtonsoft.Json; 
namespace ContatusApiConsole.Models{ 

    public class Negotiator
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

}