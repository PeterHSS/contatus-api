
using ContatusApiConsole.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Net.Mail;

namespace ContatusApiConsole.Repositories
{
    internal class CompetenciaRepository
    {

        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

        public CompetenciaRepository()
        {
            _sqlConnectionStringBuilder = BuiilderConnection();
        }

        public void InsertCompetenciaItems(List<Competencia> competencias)
        {
            foreach (var item in competencias)
            {
                using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand command = new SqlCommand("[stg_competencia_items_insert]", sqlConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 9999;

                        command.Parameters.AddWithValue("@id", item.Id.ToString());
                        command.Parameters.AddWithValue("@version", item.Version.ToString());
                        command.Parameters.AddWithValue("@type", item.Type.ToString());
                        command.Parameters.AddWithValue("@competenceDate", item.CompetenceDate.ToString());
                        command.Parameters.AddWithValue("@description", item.Description.ToString());
                        command.Parameters.AddWithValue("@value", item.Value.ToString());
                        command.Parameters.AddWithValue("@reference_id", item.Reference.Id ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@reference_origin", item.Reference.Origin ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@reference_revision", item.Reference.Revision ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@paymentCondition", item.PaymentCondition.ToString());
                        command.Parameters.AddWithValue("@categoryCount", item.CategoryCount.ToString());
                        command.Parameters.AddWithValue("@costCenterCount", item.CostCenterCount.ToString());
                        command.Parameters.AddWithValue("@categoryDescriptions", item.CategoryDescriptions.ToString());
                        command.Parameters.AddWithValue("@negotiator_id", item.Negotiator.Id ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@negotiator_name", item.Negotiator.Name ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@hasDigitalReceipt", item.HasDigitalReceipt.ToString());
                        command.Parameters.AddWithValue("@attachment", item.Attachment.ToString());
                        command.Parameters.AddWithValue("@emailVisualization", item.EmailVisualization.ToString());
                        command.Parameters.AddWithValue("@emailSent", item.EmailSent.ToString());
                        command.Parameters.AddWithValue("@recurrent", item.Recurrent.ToString());
                        command.Parameters.AddWithValue("@scheduled", item.Scheduled.ToString());
                        command.Parameters.AddWithValue("@hasPendingPaymentRequest", item.HasDraftPaymentRequest.ToString());
                        command.Parameters.AddWithValue("@hasDraftPaymentRequest", item.HasDraftPaymentRequest.ToString());
                        command.Parameters.AddWithValue("@hasScheduledPaymentRequest", item.HasScheduledPaymentRequest.ToString());

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
