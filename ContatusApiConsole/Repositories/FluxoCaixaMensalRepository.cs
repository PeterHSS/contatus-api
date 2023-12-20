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
    internal class FluxoCaixaMensalRepository
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

        public FluxoCaixaMensalRepository()
        {
            _sqlConnectionStringBuilder = BuiilderConnection();
        }

        public void InsertFluxoCaixaMensal(FluxoCaixaMensal fluxoCaixaMensal)
        {
            foreach (var row in fluxoCaixaMensal.Data.Rows)
            {
                foreach (var cell in row.Cells)
                {
                    if (cell.Period != null)
                    {
                        using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
                        {
                            sqlConnection.Open();
                            using (SqlCommand command = new SqlCommand("[dbo].[stg_fluxo_caixa_mensal_insert]", sqlConnection))
                            {
                                command.CommandType = CommandType.StoredProcedure;
                                command.CommandTimeout = 9999;

                                command.Parameters.AddWithValue("@rows_label", row.Label ?? (object)DBNull.Value);
                                command.Parameters.AddWithValue("@rows_categoryid", row.CategoryId ?? (object)DBNull.Value);
                                command.Parameters.AddWithValue("@rows_cells_predicted", cell.Predicted.ToString() ?? (object)DBNull.Value);
                                command.Parameters.AddWithValue("@rows_cells_accomplished", cell.Accomplished.ToString() ?? (object)DBNull.Value);
                                command.Parameters.AddWithValue("@rows_cells_period", cell.Period ?? (object)DBNull.Value);
                                command.Parameters.AddWithValue("@rows_level", row.Level.ToString() ?? (object)DBNull.Value);
                                command.Parameters.AddWithValue("@rows_type", row.Type ?? (object)DBNull.Value);
                                command.Parameters.AddWithValue("@rows_totalizer", row.Totalizer.ToString() ?? (object)DBNull.Value);

                                command.ExecuteNonQuery();
                            }
                            sqlConnection.Close();
                        }
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
