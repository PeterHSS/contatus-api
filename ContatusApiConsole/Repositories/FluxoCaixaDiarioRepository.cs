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
    internal class FluxoCaixaDiarioRepository
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

        public FluxoCaixaDiarioRepository()
        {
            _sqlConnectionStringBuilder = BuiilderConnection();
        }

        public void InsertFluxoCaixaDiario(List<FluxoCaixaDiario> fluxosCaixaDiario)
        {
            foreach (var fluxoCaixaDiario in fluxosCaixaDiario)
            {
                using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand command = new SqlCommand("[dbo].[stg_fluxo_caixa_diario_insert]", sqlConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 9999;

                        command.Parameters.AddWithValue("@date", fluxoCaixaDiario.Date.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@revenuesValue", fluxoCaixaDiario.RevenuesValue.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@expensesValue", fluxoCaixaDiario.ExpensesValue.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@balance", fluxoCaixaDiario.Balance.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@transfersRevenue", fluxoCaixaDiario.TransfersRevenue.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@transfersExpense", fluxoCaixaDiario.TransfersExpense.ToString() ?? (object)DBNull.Value);
                        
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
