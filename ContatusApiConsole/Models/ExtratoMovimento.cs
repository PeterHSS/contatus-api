using Newtonsoft.Json; 
namespace ContatusApiConsole.Models{ 

    public class ExtratoMovimento
    {
        [JsonProperty("balance")]
        public double Balance { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }

        [JsonProperty("installmentsCount")]
        public object InstallmentsCount { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("origin")]
        public string Origin { get; set; }

        [JsonProperty("recurrent")]
        public bool Recurrent { get; set; }

        [JsonProperty("hasAttachment")]
        public bool HasAttachment { get; set; }

        [JsonProperty("scheduled")]
        public bool Scheduled { get; set; }

        [JsonProperty("chargeViewStatus")]
        public string ChargeViewStatus { get; set; }

        [JsonProperty("negotiator")]
        public Negotiator Negotiator { get; set; }

        [JsonProperty("installmentId")]
        public string InstallmentId { get; set; }

        [JsonProperty("financialEventId")]
        public string FinancialEventId { get; set; }

        [JsonProperty("financialEvent")]
        public FinancialEvent FinancialEvent { get; set; }

        [JsonProperty("installmentIndex")]
        public int InstallmentIndex { get; set; }

        [JsonProperty("installmentValueComposition")]
        public InstallmentValueComposition InstallmentValueComposition { get; set; }

        [JsonProperty("installmentPaid")]
        public double InstallmentPaid { get; set; }

        [JsonProperty("recurrenceIndex")]
        public object RecurrenceIndex { get; set; }

        [JsonProperty("categoryCount")]
        public int CategoryCount { get; set; }

        [JsonProperty("transferId")]
        public object TransferId { get; set; }

        [JsonProperty("reconciliationId")]
        public object ReconciliationId { get; set; }

        [JsonProperty("financialAccountId")]
        public string FinancialAccountId { get; set; }

        [JsonProperty("categoryName")]
        public string CategoryName { get; set; }

        [JsonProperty("financialAccount")]
        public FinancialAccount? FinancialAccount { get; set; } 

        [JsonProperty("digitalReceiptId")]
        public object DigitalReceiptId { get; set; }

        [JsonProperty("authorizedBankSlipId")]
        public object AuthorizedBankSlipId { get; set; }

        [JsonProperty("acquittanceScheduled")]
        public bool AcquittanceScheduled { get; set; }

        [JsonProperty("emailVisualization")]
        public bool EmailVisualization { get; set; }

        [JsonProperty("emailSent")]
        public bool EmailSent { get; set; }

        [JsonProperty("chargeRequest")]
        public object ChargeRequest { get; set; }

        [JsonProperty("paymentRequest")]
        public object PaymentRequest { get; set; }
    }

}