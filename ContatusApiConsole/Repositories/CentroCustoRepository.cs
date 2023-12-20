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
    internal class CentroCustoRepository
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

        public CentroCustoRepository()
        {
            _sqlConnectionStringBuilder = BuiilderConnection();
        }

        public void InsertCentroCusto(List<CentroCusto> centrosCusto)
        {
            foreach (var centro in centrosCusto)
            {
                using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand command = new SqlCommand("[dbo].[stg_centro_custo_insert]", sqlConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 9999;

                        command.Parameters.AddWithValue("@id", centro.Id.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@version", centro.Version.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@code", centro.Code ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@name", centro.Name.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@parent", centro.Parent ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@active", centro.Active.ToString() ?? (object)DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                    sqlConnection.Close();
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
