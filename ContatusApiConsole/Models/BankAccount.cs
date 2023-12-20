using Newtonsoft.Json;

namespace ContatusApiConsole.Models
{
    public class BankAccount
    {
        [JsonProperty("accountType")]
        public string AccountType { get; set; }

        [JsonProperty("ativo")]
        public bool Ativo { get; set; }

        [JsonProperty("codBanco")]
        public int CodBanco { get; set; }

        [JsonProperty("defaultAccount")]
        public bool DefaultAccount { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("idBanco")]
        public int IdBanco { get; set; }

        [JsonProperty("nmBanco")]
        public string NmBanco { get; set; }

        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("flag")]
        public string Flag { get; set; }

        [JsonProperty("paymentCompany")]
        public object PaymentCompany { get; set; }

        [JsonProperty("wizardStatus")]
        public string WizardStatus { get; set; }

        [JsonProperty("contaAzulDigital")]
        public bool ContaAzulDigital { get; set; }

        [JsonProperty("parentAccount")]
        public ParentAccount ParentAccount { get; set; }
    }
}