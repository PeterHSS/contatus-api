using Newtonsoft.Json;

namespace ContatusApiConsole.Models
{
    public class ParentAccount
    {
        [JsonProperty("nmBanco")]
        public string NmBanco { get; set; }
    }
}