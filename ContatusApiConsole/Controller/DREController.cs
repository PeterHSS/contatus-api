using ContatusApiConsole.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ContatusApiConsole.Controller
{
    internal class DREController
    {
        public async Task<DRE> GetDRE(int getYear)
        {
            string auth = "9e732b08-7839-4985-b70f-56bc0a2e1965";
            string period = "MONTHLY";
            string analysis = "NONE";
            string dreCostValueDisabled = "false";
            string year = getYear.ToString();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("x-Authorization", auth);

                var url = "https://services.contaazul.com/search-engine-core/v1/dre";

                var queryString = $"?period={period}&analysis={analysis}&dreCostValueDisabled={dreCostValueDisabled}&start_year={year}&end_year={year}";

                var apiUrl = $"{url}{queryString}";

                var response = await httpClient.GetAsync(apiUrl);


                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<DRE>(jsonResponse);
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
