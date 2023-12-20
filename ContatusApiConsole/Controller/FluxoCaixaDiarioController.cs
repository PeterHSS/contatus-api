using ContatusApiConsole.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatusApiConsole.Controller
{
    internal class FluxoCaixaDiarioController
    {
        public async Task<List<FluxoCaixaDiario>> PostFluxoCaixaDiario()
        {
            DateTime dataInicial = DateTime.Parse("2021-01-01"); // Substitua pelo valor desejado
            string auth = "9e732b08-7839-4985-b70f-56bc0a2e1965"; // Substitua pela chave de autorização adequada

            string dataInicio = dataInicial.ToString("yyyy-MM-dd");
            string dataFim = DateTime.Now.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");

            var body = new
            {
                startDate = dataInicio,
                endDate = DateTime.Now.ToString("yyyy-MM-dd"),
            };

            var jsonBody = JsonConvert.SerializeObject(body);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("x-Authorization", auth);

                var apiUrl = "https://services.contaazul.com/finance-pro-reader/v1/daily-cash-flow";

                var response = await httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    var fluxoCaixaDiario = JsonConvert.DeserializeObject<List<FluxoCaixaDiario>>(jsonResponse);

                    return fluxoCaixaDiario;
                }
                else
                {
                    Console.WriteLine($"Erro na solicitação: {response.StatusCode} - {response.ReasonPhrase}");
                    return null;
                }
            }
        }
    }
}
