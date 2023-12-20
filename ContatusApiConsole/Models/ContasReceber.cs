using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatusApiConsole.Models
{
    internal class ContasReceber
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("index")]
        public int Index { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("dueDate")]
        public string DueDate { get; set; }

        [JsonProperty("expectedPaymentDate")]
        public string ExpectedPaymentDate { get; set; }

        [JsonProperty("lastAcquittanceDate")]
        public string LastAcquittanceDate { get; set; }

        [JsonProperty("unpaid")]
        public double Unpaid { get; set; }

        [JsonProperty("paid")]
        public double Paid { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("reference")]
        public object Reference { get; set; }

        [JsonProperty("conciliated")]
        public bool Conciliated { get; set; }

        [JsonProperty("totalNetValue")]
        public double TotalNetValue { get; set; }

        [JsonProperty("loss")]
        public object Loss { get; set; }

        [JsonProperty("attachment")]
        public bool Attachment { get; set; }

        [JsonProperty("recurrent")]
        public bool Recurrent { get; set; }

        [JsonProperty("chargeRequest")]
        public object ChargeRequest { get; set; }

        [JsonProperty("paymentRequest")]
        public object PaymentRequest { get; set; }

        [JsonProperty("valueComposition")]
        public ValueComposition ValueComposition { get; set; }

        [JsonProperty("financialAccount")]
        public FinancialAccount FinancialAccount { get; set; }

        [JsonProperty("financialEvent")]
        public FinancialEvent FinancialEvent { get; set; }

        [JsonProperty("hasDigitalReceipt")]
        public bool HasDigitalReceipt { get; set; }

        [JsonProperty("authorizedBankSlipId")]
        public object AuthorizedBankSlipId { get; set; }

        [JsonProperty("acquittanceScheduled")]
        public bool AcquittanceScheduled { get; set; }

        [JsonProperty("acquittances")]
        public List<Acquittance> Acquittances { get; set; }
    }
}
