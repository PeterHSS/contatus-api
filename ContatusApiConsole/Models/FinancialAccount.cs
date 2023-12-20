using Newtonsoft.Json;

namespace ContatusApiConsole.Models
{
    public class FinancialAccount
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("contaAzulDigital")]
        public bool ContaAzulDigital { get; set; }

        [JsonProperty("cashierAccount")]
        public bool CashierAccount { get; set; }

        [JsonProperty("hasBankSlipConfiguration")]
        public bool HasBankSlipConfiguration { get; set; }

        [JsonProperty("dueDate")]
        public object DueDate { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("wizardStatus")]
        public object WizardStatus { get; set; }

        [JsonProperty("defaultAccount")]
        public bool DefaultAccount { get; set; }

        [JsonProperty("closingDate")]
        public object ClosingDate { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("parentId")]
        public object ParentId { get; set; }

        [JsonProperty("externalReference")]
        public object ExternalReference { get; set; }

        [JsonProperty("bankInstitutionCode")]
        public int BankInstitutionCode { get; set; }

        [JsonProperty("bankInstitution")]
        public string BankInstitution { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("legacyId")]
        public int LegacyId { get; set; }

        [JsonProperty("chargeRequestEnabled")]
        public bool ChargeRequestEnabled { get; set; }

        [JsonProperty("agency")]
        public object Agency { get; set; }

        [JsonProperty("number")]
        public object Number { get; set; }
    }
}