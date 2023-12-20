using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatusApiConsole.Models
{
    internal class Categorias
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("feedDRECost")]
        public bool FeedDRECost { get; set; }

        [JsonProperty("accountancyCodeBlocked")]
        public bool AccountancyCodeBlocked { get; set; }

        [JsonProperty("hasChildren")]
        public bool HasChildren { get; set; }

        [JsonProperty("parentLedgerAccountId")]
        public int? ParentLedgerAccountId { get; set; }

        [JsonProperty("financeAccountId")]
        public int? FinanceAccountId { get; set; }

        [JsonProperty("financeAccountDescription")]
        public string FinanceAccountDescription { get; set; }

        [JsonProperty("accountancyCode")]
        public int? AccountancyCode { get; set; }
    }
}
