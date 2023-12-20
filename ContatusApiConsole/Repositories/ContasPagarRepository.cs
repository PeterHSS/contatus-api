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
    internal class ContasPagarRepository
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

        public ContasPagarRepository()
        {
            _sqlConnectionStringBuilder = BuiilderConnection();
        }

        public void InsertContasPagar(List<ContasPagar> listContasPagar)
        {
            foreach (var contasPagar in listContasPagar)
            {
                foreach (var acquittance in contasPagar.Acquittances)
                {
                    using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
                    {
                        sqlConnection.Open();
                        using (SqlCommand command = new SqlCommand("[dbo].[stg_contas_pagar_insert]", sqlConnection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandTimeout = 9999;

                            command.Parameters.AddWithValue("@id", contasPagar.Id ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@version", contasPagar.Version.ToString() ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@index", contasPagar.Index.ToString() ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@note", contasPagar.Note ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@description", contasPagar.Description ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@dueDate", contasPagar.DueDate ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@expectedPaymentDate", contasPagar.ExpectedPaymentDate ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@lastAcquittanceDate", contasPagar.LastAcquittanceDate ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@unpaid", contasPagar.Unpaid.ToString() ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@paid", contasPagar.Paid.ToString());
                            command.Parameters.AddWithValue("@status", contasPagar.Status ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@reference", contasPagar.Reference ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@conciliated", contasPagar.Conciliated.ToString());
                            command.Parameters.AddWithValue("@totalNetValue", contasPagar.TotalNetValue.ToString());
                            command.Parameters.AddWithValue("@loss", contasPagar.Loss ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@attachment", contasPagar.Attachment.ToString());
                            command.Parameters.AddWithValue("@recurrent", contasPagar.Recurrent.ToString());
                            command.Parameters.AddWithValue("@chargeRequest", contasPagar.ChargeRequest ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@paymentRequest", contasPagar.PaymentRequest ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@valueComposition_grossValue", contasPagar.ValueComposition.GrossValue.ToString());
                            command.Parameters.AddWithValue("@valueComposition_interest", contasPagar.ValueComposition.Interest.ToString());
                            command.Parameters.AddWithValue("@valueComposition_fine", contasPagar.ValueComposition.Fine.ToString());
                            command.Parameters.AddWithValue("@valueComposition_netValue", contasPagar.ValueComposition.NetValue.ToString());
                            command.Parameters.AddWithValue("@valueComposition_discount", contasPagar.ValueComposition.Discount.ToString());
                            command.Parameters.AddWithValue("@valueComposition_fee", contasPagar.ValueComposition.Fee.ToString());
                            command.Parameters.AddWithValue("@financialAccount_id", contasPagar.FinancialAccount.Id ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@financialAccount_type", contasPagar.FinancialAccount.Type);
                            command.Parameters.AddWithValue("@financialAccount_contaAzulDigital", contasPagar.FinancialAccount.ContaAzulDigital.ToString());
                            command.Parameters.AddWithValue("@financialAccount_cashierAccount", contasPagar.FinancialAccount.CashierAccount.ToString());
                            command.Parameters.AddWithValue("@financialEvent_type", contasPagar.FinancialEvent.Type ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@financialEvent_competenceDate", contasPagar.FinancialEvent.CompetenceDate ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@financialEvent_value", contasPagar.FinancialEvent.Value.ToString());
                            command.Parameters.AddWithValue("@financialEvent_id", contasPagar.FinancialEvent.Id ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@financialEvent_negotiator_id", contasPagar.FinancialEvent.Negotiator.Id ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@financialEvent_negotiator_name", contasPagar.FinancialEvent.Negotiator.Name ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@financialEvent_description", contasPagar.FinancialEvent.Description.ToString());
                            command.Parameters.AddWithValue("@financialEvent_categoryCount", contasPagar.FinancialEvent.CategoryCount.ToString());
                            command.Parameters.AddWithValue("@financialEvent_costCenterCount", contasPagar.FinancialEvent.CostCenterCount.ToString());
                            command.Parameters.AddWithValue("@financialEvent_reference_id", contasPagar.FinancialEvent.Reference.Id ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@financialEvent_reference_origin", contasPagar.FinancialEvent.Reference.Origin ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@financialEvent_reference_revision", contasPagar.FinancialEvent.Reference.Revision ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@financialEvent_numberOfInstallments", contasPagar.FinancialEvent.NumberOfInstallments.ToString());
                            command.Parameters.AddWithValue("@financialEvent_scheduled", contasPagar.FinancialEvent.Scheduled.ToString());
                            command.Parameters.AddWithValue("@financialEvent_version", contasPagar.FinancialEvent.Version.ToString());
                            command.Parameters.AddWithValue("@financialEvent_recurrenceIndex", contasPagar.FinancialEvent.RecurrenceIndex.ToString());
                            command.Parameters.AddWithValue("@financialEvent_categoryDescriptions", contasPagar.FinancialEvent.CategoryDescriptions.ToString());
                            command.Parameters.AddWithValue("@hasDigitalReceipt", contasPagar.HasDigitalReceipt.ToString());
                            command.Parameters.AddWithValue("@authorizedBankSlipId", contasPagar.AuthorizedBankSlipId ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@acquittanceScheduled", contasPagar.AcquittanceScheduled.ToString());
                            command.Parameters.AddWithValue("@acquittances_id", acquittance.Id.ToString());
                            command.Parameters.AddWithValue("@acquittances_version", acquittance.Version.ToString());
                            command.Parameters.AddWithValue("@acquittances_acquittanceDate", acquittance.AcquittanceDate.ToString());
                            command.Parameters.AddWithValue("@acquittances_reconciliationId", acquittance.ReconciliationId ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@acquittances_financialAccount_id", acquittance.FinancialAccount.Id ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@acquittances_financialAccount_type", acquittance.FinancialAccount.Type ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@acquittances_financialAccount_contaAzulDigital", acquittance.FinancialAccount.ContaAzulDigital.ToString() ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@acquittances_financialAccount_cashierAccount", acquittance.FinancialAccount.CashierAccount.ToString() ?? (object)DBNull.Value);

                            command.ExecuteNonQuery();
                        }
                        sqlConnection.Close();
                    }

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
