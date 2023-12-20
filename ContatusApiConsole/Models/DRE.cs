using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ContatusApiConsole.Models
{
    internal class DRE
    {
        [JsonProperty("headers")]
        public List<Header> Headers { get; set; }

        [JsonProperty("rows")]
        public List<Row> Rows { get; set; }
    }
}
