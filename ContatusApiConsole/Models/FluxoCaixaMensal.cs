using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ContatusApiConsole.Models
{
    internal class FluxoCaixaMensal
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }
}
