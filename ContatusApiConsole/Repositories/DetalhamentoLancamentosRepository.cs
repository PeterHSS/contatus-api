using ContatusApiConsole.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatusApiConsole.Repositories
{
    internal class DetalhamentoLancamentosRepository
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

        public DetalhamentoLancamentosRepository()
        {
            _sqlConnectionStringBuilder = BuiilderConnection();
        }

        public void InsertDetalhamentoLancamento(string json)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand("[dbo].[stg_detalhamento_lancamento_insert]", sqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 9999;

                    command.Parameters.AddWithValue("@json", json);
                    command.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }

        }

        public List<string> RetornaListaDeIds()
        {
            var listaIds = new List<string>();

            using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand command = new SqlCommand("[dbo].[id_contas_listar]", sqlConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 9999;
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        using (DataTable table = new DataTable())
                        {
                            adapter.Fill(table);

                            foreach (DataRow row in table.Rows)
                            {
                                string? valor = row["id"].ToString();
                                listaIds.Add(valor!);
                            }
                        }
                    }
                }
                sqlConnection.Close();
            }

            return listaIds;
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
