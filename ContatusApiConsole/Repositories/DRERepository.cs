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
    internal class DRERepository
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

        public DRERepository()
        {
            _sqlConnectionStringBuilder = BuiilderConnection();
        }

        public void InsertDRE(DRE dre)
        {
            foreach (var row in dre.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
                    {
                        sqlConnection.Open();
                        using (SqlCommand command = new SqlCommand("[dbo].[stg_dre_insert]", sqlConnection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandTimeout = 9999;

                            command.Parameters.AddWithValue("@header_label", dre.Headers[i].Label);
                            command.Parameters.AddWithValue("@header_period", dre.Headers[i].Period ?? (object) DBNull.Value);
                            command.Parameters.AddWithValue("@row_label", row.Label);
                            command.Parameters.AddWithValue("@row_dreEntryId", row.DreEntryId);
                            command.Parameters.AddWithValue("@row_type", row.Type);
                            command.Parameters.AddWithValue("@row_cells", row.Cells[i].ToString());

                            command.ExecuteNonQuery();
                        }
                        sqlConnection.Close();
                    }

                }

            }

            foreach (var row in dre.Rows)
            {
                foreach (var child in row.Children)
                {
                    for (int i = 0; i < child.Cells.Count; i++)
                    {
                        using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
                        {
                            sqlConnection.Open();
                            using (SqlCommand command = new SqlCommand("[dbo].[stg_dre_children_insert]", sqlConnection))
                            {
                                command.CommandType = CommandType.StoredProcedure;
                                command.CommandTimeout = 9999;

                                command.Parameters.AddWithValue("@header_label", dre.Headers[i].Label);
                                command.Parameters.AddWithValue("@header_period", dre.Headers[i].Period ?? (object)DBNull.Value);
                                command.Parameters.AddWithValue("@row_dreEntryId_parent", row.DreEntryId.ToString());
                                command.Parameters.AddWithValue("@row_label", child.Label);
                                command.Parameters.AddWithValue("@row_dreEntryId", child.DreEntryId);
                                command.Parameters.AddWithValue("@row_type", child.Type);
                                command.Parameters.AddWithValue("@row_cells", child.Cells[i].ToString());

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
