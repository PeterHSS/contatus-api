using Newtonsoft.Json;

namespace ContatusApiConsole.Models
{
    public class Acquittance
    {
        [JsonProperty("attachments")]
        public List<object> Attachments { get; set; }

        [JsonProperty("acquittanceDate")]
        public string AcquittanceDate { get; set; }

        [JsonProperty("observation")]
        public object Observation { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("valueComposition")]
        public ValueComposition ValueComposition { get; set; }

        [JsonProperty("financialAccount")]
        public FinancialAccount FinancialAccount { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("digitalReceiptId")]
        public object DigitalReceiptId { get; set; }

        [JsonProperty("nsu")]
        public object Nsu { get; set; }

        [JsonProperty("installmentId")]
        public string InstallmentId { get; set; }

        [JsonProperty("chargeRequestId")]
        public object ChargeRequestId { get; set; }

        [JsonProperty("paymentMethod")]
        public string PaymentMethod { get; set; }

        [JsonProperty("reconciliationId")]
        public string ReconciliationId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}