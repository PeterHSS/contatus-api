using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatusApiConsole.Models
{
    internal class ContasBancarias
    {
        [JsonProperty("automaticBankFeedEnabled")]
        public bool AutomaticBankFeedEnabled { get; set; }

        [JsonProperty("numberOfPendingConciliations")]
        public int NumberOfPendingConciliations { get; set; }

        [JsonProperty("defaultAccount")]
        public bool DefaultAccount { get; set; }

        [JsonProperty("balance")]
        public double Balance { get; set; }

        [JsonProperty("bankAccount")]
        public BankAccount BankAccount { get; set; }
    }
}
