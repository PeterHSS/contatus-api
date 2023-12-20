using Newtonsoft.Json; 
namespace ContatusApiConsole.Models{ 

    public class Totals
    {
        [JsonProperty("expenses")]
        public Expenses Expenses { get; set; }

        [JsonProperty("revenues")]
        public Revenues Revenues { get; set; }

        [JsonProperty("all")]
        public All All { get; set; }
    }

}