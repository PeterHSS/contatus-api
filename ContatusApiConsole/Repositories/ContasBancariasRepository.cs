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
    internal class ContasBancariasRepository
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

        public ContasBancariasRepository()
        {
            _sqlConnectionStringBuilder = BuiilderConnection();
        }

        public void InsertContasBancarias(List<ContasBancarias> listContasBancarias)
        {
            foreach (var contaBancaria in listContasBancarias)
            {
                using (SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand command = new SqlCommand("[dbo].[stg_contas_bancarias_insert]", sqlConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 9999;

                        command.Parameters.AddWithValue("@automaticBankFeedEnabled", contaBancaria.AutomaticBankFeedEnabled);
                        command.Parameters.AddWithValue("@numberOfPendingConciliations", contaBancaria.NumberOfPendingConciliations);
                        command.Parameters.AddWithValue("@defaultAccount", contaBancaria.DefaultAccount);
                        command.Parameters.AddWithValue("@balance", contaBancaria.Balance);
                        command.Parameters.AddWithValue("@bankAccount_accountType", contaBancaria.BankAccount.AccountType ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@bankAccount_ativo", contaBancaria.BankAccount.Ativo);
                        command.Parameters.AddWithValue("@bankAccount_codBanco", contaBancaria.BankAccount.CodBanco);
                        command.Parameters.AddWithValue("@bankAccount_defaultAccount", contaBancaria.BankAccount.DefaultAccount);
                        command.Parameters.AddWithValue("@bankAccount_id", contaBancaria.BankAccount.Id);
                        command.Parameters.AddWithValue("@bankAccount_idBanco", contaBancaria.BankAccount.IdBanco);
                        command.Parameters.AddWithValue("@bankAccount_nmBanco", contaBancaria.BankAccount.NmBanco ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@bankAccount_uuid", contaBancaria.BankAccount.Uuid ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@bankAccount_flag", contaBancaria.BankAccount.Flag ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@bankAccount_paymentCompany", contaBancaria.BankAccount.PaymentCompany ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@bankAccount_wizardStatus", contaBancaria.BankAccount.WizardStatus ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@bankAccount_contaAzulDigital", contaBancaria.BankAccount.ContaAzulDigital);

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
