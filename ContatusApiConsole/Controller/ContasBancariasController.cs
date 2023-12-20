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
    internal class ContasBancariasController
    {
        public async Task<List<ContasBancarias>> GetContasBancarias()
        {
            var auth = "9e732b08-7839-4985-b70f-56bc0a2e1965";

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("x-Authorization", auth);

                var apiUrl = "https://services.contaazul.com/contaazul-bff/dashboard/v1/financial-accounts";

                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    JObject json = JsonConvert.DeserializeObject<JObject>(jsonResponse)!;

                    JToken itemsToken = json["dashboardBankAccounts"];

                    if (itemsToken != null)
                    {
                        var contasBancarias = itemsToken.ToObject<List<ContasBancarias>>();

                        return contasBancarias;
                    }
                    else
                    {
                        return null;
                    }
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
