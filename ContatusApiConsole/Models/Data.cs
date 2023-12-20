using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatusApiConsole.Models
{
    internal class Data
    {
        [JsonProperty("header")]
        public List<string> Header { get; set; }

        [JsonProperty("rows")]
        public List<Linha> Rows { get; set; }
    }
}
