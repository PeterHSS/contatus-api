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
    internal class CategoriasRepository
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

        public CategoriasRepository()
        {
            _sqlConnectionStringBuilder = BuiilderConnection();
        }

        public void InsertCategorias(List<Categorias> categorias)
        {
            foreach (var categoria in categorias)
            {
                using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand command = new SqlCommand("[dbo].[stg_categorias_insert]", sqlConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 9999;

                        command.Parameters.AddWithValue("@id", categoria.Id.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@uuid", categoria.Uuid ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@code", categoria.Code ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@description", categoria.Description ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@type", categoria.Type ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@level", categoria.Level.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@feedDRECost", categoria.FeedDRECost.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@accountancyCodeBlocked", categoria.AccountancyCodeBlocked.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@hasChildren", categoria.HasChildren.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@parentLedgerAccountId", categoria.ParentLedgerAccountId.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@financeAccountId", categoria.FinanceAccountId.ToString() ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@financeAccountDescription", categoria.FinanceAccountDescription ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@accountancyCode", categoria.AccountancyCode.ToString() ?? (object)DBNull.Value);


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
