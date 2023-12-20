using ContatusApiConsole.Models;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ContatusApiConsole.Repositories
{
    internal class ContasReceberRepository
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

        public ContasReceberRepository()
        {
            _sqlConnectionStringBuilder = BuiilderConnection();
        }

        public void InsertContasReceber(List<ContasReceber> listContasReceber)
        {
            foreach (var contasReceber in listContasReceber)
            {
                foreach (var acquittance in contasReceber.Acquittances)
                {
                    using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
                    {
                        sqlConnection.Open();
                        using (SqlCommand command = new SqlCommand("[dbo].[stg_contas_receber_insert]", sqlConnection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandTimeout = 9999;

                            command.Parameters.AddWithValue("@id", contasReceber.Id ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@version", contasReceber.Version.ToString());
                            command.Parameters.AddWithValue("@index", contasReceber.Index.ToString());
                            command.Parameters.AddWithValue("@note", contasReceber.Note ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@description", contasReceber.Description ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@dueDate", contasReceber.DueDate ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@expectedPaymentDate", contasReceber.ExpectedPaymentDate ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@lastAcquittanceDate", contasReceber.LastAcquittanceDate ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@unpaid", contasReceber.Unpaid.ToString());
                            command.Parameters.AddWithValue("@paid", contasReceber.Paid.ToString());
                            command.Parameters.AddWithValue("@status", contasReceber.Status ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@reference", contasReceber.Reference ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@conciliated", contasReceber.Conciliated.ToString());
                            command.Parameters.AddWithValue("@totalNetValue", contasReceber.TotalNetValue.ToString());
                            command.Parameters.AddWithValue("@loss", contasReceber.Loss ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@attachment", contasReceber.Attachment.ToString());
                            command.Parameters.AddWithValue("@recurrent", contasReceber.Recurrent.ToString());
                            command.Parameters.AddWithValue("@chargeRequest", contasReceber.ChargeRequest ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@paymentRequest", contasReceber.PaymentRequest ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@valueComposition_grossValue", contasReceber.ValueComposition.GrossValue.ToString());
                            command.Parameters.AddWithValue("@valueComposition_interest", contasReceber.ValueComposition.Interest.ToString());
                            command.Parameters.AddWithValue("@valueComposition_fine", contasReceber.ValueComposition.Fine.ToString());
                            command.Parameters.AddWithValue("@valueComposition_netValue", contasReceber.ValueComposition.NetValue.ToString());
                            command.Parameters.AddWithValue("@valueComposition_discount", contasReceber.ValueComposition.Discount.ToString());
                            command.Parameters.AddWithValue("@valueComposition_fee", contasReceber.ValueComposition.Fee.ToString());
                            command.Parameters.AddWithValue("@financialAccount_id", contasReceber.FinancialAccount.Id.ToString());
                            command.Parameters.AddWithValue("@financialAccount_type", contasReceber.FinancialAccount.Type);
                            command.Parameters.AddWithValue("@financialAccount_contaAzulDigital", contasReceber.FinancialAccount.ContaAzulDigital.ToString());
                            command.Parameters.AddWithValue("@financialAccount_cashierAccount", contasReceber.FinancialAccount.CashierAccount.ToString());
                            command.Parameters.AddWithValue("@financialEvent_type", contasReceber.FinancialEvent.Type.ToString());
                            command.Parameters.AddWithValue("@financialEvent_competenceDate", contasReceber.FinancialEvent.CompetenceDate.ToString());
                            command.Parameters.AddWithValue("@financialEvent_value", contasReceber.FinancialEvent.Value.ToString());
                            command.Parameters.AddWithValue("@financialEvent_id", contasReceber.FinancialEvent.Id.ToString());
                            command.Parameters.AddWithValue("@financialEvent_negotiator_id", contasReceber.FinancialEvent.Negotiator.Id ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@financialEvent_negotiator_name", contasReceber.FinancialEvent.Negotiator.Name ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@financialEvent_description", contasReceber.FinancialEvent.Description.ToString());
                            command.Parameters.AddWithValue("@financialEvent_categoryCount", contasReceber.FinancialEvent.CategoryCount.ToString());
                            command.Parameters.AddWithValue("@financialEvent_costCenterCount", contasReceber.FinancialEvent.CostCenterCount.ToString());
                            command.Parameters.AddWithValue("@financialEvent_reference_id", contasReceber.FinancialEvent.Reference.Id ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@financialEvent_reference_origin", contasReceber.FinancialEvent.Reference.Origin ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@financialEvent_reference_revision", contasReceber.FinancialEvent.Reference.Revision ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@financialEvent_numberOfInstallments", contasReceber.FinancialEvent.NumberOfInstallments.ToString());
                            command.Parameters.AddWithValue("@financialEvent_scheduled", contasReceber.FinancialEvent.Scheduled.ToString());
                            command.Parameters.AddWithValue("@financialEvent_version", contasReceber.FinancialEvent.Version.ToString());
                            command.Parameters.AddWithValue("@financialEvent_recurrenceIndex", contasReceber.FinancialEvent.RecurrenceIndex.ToString());
                            command.Parameters.AddWithValue("@financialEvent_categoryDescriptions", contasReceber.FinancialEvent.CategoryDescriptions.ToString());
                            command.Parameters.AddWithValue("@hasDigitalReceipt", contasReceber.HasDigitalReceipt.ToString());
                            command.Parameters.AddWithValue("@authorizedBankSlipId", contasReceber.AuthorizedBankSlipId ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@acquittanceScheduled", contasReceber.AcquittanceScheduled.ToString());
                            command.Parameters.AddWithValue("@acquittances_id", acquittance.Id.ToString());
                            command.Parameters.AddWithValue("@acquittances_version", acquittance.Version.ToString());
                            command.Parameters.AddWithValue("@acquittances_acquittanceDate", acquittance.AcquittanceDate.ToString());
                            command.Parameters.AddWithValue("@acquittances_reconciliationId", acquittance.ReconciliationId ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@acquittances_financialAccount_id", acquittance.FinancialAccount.Id.ToString());
                            command.Parameters.AddWithValue("@acquittances_financialAccount_type", acquittance.FinancialAccount.Type.ToString());
                            command.Parameters.AddWithValue("@acquittances_financialAccount_contaAzulDigital", acquittance.FinancialAccount.ContaAzulDigital.ToString());
                            command.Parameters.AddWithValue("@acquittances_financialAccount_cashierAccount", acquittance.FinancialAccount.CashierAccount.ToString());

                            command.ExecuteNonQuery();
                        }
                        sqlConnection.Close();
                    }

                }
            }

        }
     
        private SqlConnectionStringBuilder BuiilderConnection()
        {
            return new SqlConnectionStringBuilder
            {
                DataSource = "VMI1465631\\SQLEXPRESS",
                InitialCatalog = "Contatus",
                IntegratedSecurity = true,
                TrustServerCertificate = true
            };
        }
    }
}
