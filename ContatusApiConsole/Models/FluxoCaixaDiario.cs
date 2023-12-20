using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatusApiConsole.Models
{
    internal class FluxoCaixaDiario
    {
        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("revenuesValue")]
        public double RevenuesValue { get; set; }

        [JsonProperty("expensesValue")]
        public double ExpensesValue { get; set; }

        [JsonProperty("balance")]
        public double Balance { get; set; }

        [JsonProperty("transfersRevenue")]
        public double TransfersRevenue { get; set; }

        [JsonProperty("transfersExpense")]
        public double TransfersExpense { get; set; }
    }
}
