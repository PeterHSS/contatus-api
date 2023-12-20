using ContatusApiConsole.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatusApiConsole.Repositories
{
    internal class ExtratoMovimentoRepository
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

        public ExtratoMovimentoRepository()
        {
            _sqlConnectionStringBuilder = BuiilderConnection();
        }

        public void InsertExtratoMovimento(List<ExtratoMovimento> extratoMovimentos)
        {
            foreach (var extrato in extratoMovimentos)
            {
                using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand command = new SqlCommand("[dbo].[stg_extrato_movimento_insert]", sqlConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 9999;

                        command.Parameters.AddWithValue("@balance", extrato.Balance.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@type", extrato.Type ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@description", extrato.Description ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@value", extrato.Value.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@status", extrato.Status ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@date", extrato.Date ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@installmentsCount", extrato.InstallmentsCount ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@id", extrato.Id ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@version", extrato.Version.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@reference", extrato.Reference ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@origin", extrato.Origin ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@recurrent", extrato.Recurrent.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@hasAttachment", extrato.HasAttachment.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@scheduled", extrato.Scheduled.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@chargeViewStatus", extrato.ChargeViewStatus ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@negotiator_id", extrato.Negotiator.Id ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@negotiator_name", extrato.Negotiator.Name ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@installmentId", extrato.InstallmentId ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@financialEventId", extrato.FinancialEventId ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@financialEvent_id", extrato.FinancialEvent.Id ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@financialEvent_version", extrato.FinancialEvent.Version);
                        command.Parameters.AddWithValue("@financialEvent_description", extrato.FinancialEvent.Description ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@installmentIndex", extrato.InstallmentIndex.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@installmentValueComposition_grossValue", extrato.InstallmentValueComposition.GrossValue.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@installmentValueComposition_interest", extrato.InstallmentValueComposition.Interest.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@installmentValueComposition_fine", extrato.InstallmentValueComposition.Fine.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@installmentValueComposition_netValue", extrato.InstallmentValueComposition.NetValue.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@installmentValueComposition_discount", extrato.InstallmentValueComposition.Discount.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@installmentValueComposition_fee", extrato.InstallmentValueComposition.Fee.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@installmentPaid", extrato.InstallmentPaid.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@recurrenceIndex", extrato.RecurrenceIndex ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@categoryCount", extrato.CategoryCount.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@transferId", extrato.TransferId ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@reconciliationId", extrato.ReconciliationId ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@financialAccountId", extrato.FinancialAccountId ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@categoryName", extrato.CategoryName ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@financialAccount_id", extrato.FinancialAccount?.Id ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@financialAccount_type", extrato.FinancialAccount?.Type ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@financialAccount_contaAzulDigital", extrato.FinancialAccount?.ContaAzulDigital ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@financialAccount_cashierAccount", extrato.FinancialAccount?.CashierAccount ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@digitalReceiptId", extrato.DigitalReceiptId ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@authorizedBankSlipId", extrato.AuthorizedBankSlipId ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@acquittanceScheduled", extrato.AcquittanceScheduled.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@emailVisualization", extrato.EmailVisualization.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@emailSent", extrato.EmailSent.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@chargeRequest", extrato.ChargeRequest ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@paymentRequest", extrato.PaymentRequest ?? (object)DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                    sqlConnection.Close();
                }

            }
        }

        public void InsertCompetenciaTotals(Totals totals)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                sqlConnection.Open();

                //Expenses
                using (SqlCommand command = new SqlCommand("[competencia_totals_insert]", sqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 9999;

                    command.Parameters.AddWithValue("@type", "expenses");
                    command.Parameters.AddWithValue("@value", totals.Expenses.Value.ToString());
                    command.Parameters.AddWithValue("@count", totals.Expenses.Count.ToString());

                    command.ExecuteNonQuery();
                }
                //Revenues
                using (SqlCommand command = new SqlCommand("[competencia_totals_insert]", sqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 9999;

                    command.Parameters.AddWithValue("@type", "revenues");
                    command.Parameters.AddWithValue("@value", totals.Revenues.Value.ToString());
                    command.Parameters.AddWithValue("@count", totals.Revenues.Count.ToString());

                    command.ExecuteNonQuery();
                }
                //All
                using (SqlCommand command = new SqlCommand("[competencia_totals_insert]", sqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 9999;

                    command.Parameters.AddWithValue("@type", "all");
                    command.Parameters.AddWithValue("@value", totals.All.Value.ToString());
                    command.Parameters.AddWithValue("@count", totals.All.Count.ToString());

                    command.ExecuteNonQuery();
                }
                sqlConnection.Close();
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
