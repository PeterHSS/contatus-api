using ContatusApiConsole.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatusApiConsole.Controller
{
    internal class CentroCustoController
    {
        public async Task<int> GetTotalItems()
        {
            string auth = "9e732b08-7839-4985-b70f-56bc0a2e1965";

            int pageSize = 1000;
            int page = 1;
            string quickFilter = "ALL";

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("x-Authorization", auth);

                var url = "https://services.contaazul.com/finance-pro/v1/cost-centers";

                var queryString = $"?page_size={pageSize}&page={page}&quick_filter={quickFilter}";

                var apiUrl = $"{url}{queryString}";

                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    JObject json = JsonConvert.DeserializeObject<JObject>(jsonResponse)!;

                    JToken itemsToken = json["totalItems"]!;

                    if (itemsToken != null)
                    {

                        var totalItems = itemsToken.ToObject<int>();

                        return (int)Math.Ceiling((double)totalItems / 1000);
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    Console.WriteLine($"Erro na solicitação: {response.StatusCode} - {response.ReasonPhrase}");
                    return 1;
                }
            }
        }

        public async Task<List<CentroCusto>> GetCentroCusto(int pagina)
        {
            string auth = "9e732b08-7839-4985-b70f-56bc0a2e1965";

            int pageSize = 1000;
            //int page = 1;
            string quickFilter = "ALL";

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("x-Authorization", auth);

                var url = "https://services.contaazul.com/finance-pro/v1/cost-centers";

                var queryString = $"?page_size={pageSize}&page={pagina}&quick_filter={quickFilter}";

                var apiUrl = $"{url}{queryString}";

                var response = await httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    JObject json = JsonConvert.DeserializeObject<JObject>(jsonResponse)!;

                    JToken itemsToken = json["items"]!;

                    if (itemsToken != null)
                    {

                        var centroCusto = itemsToken.ToObject<List<CentroCusto>>();

                        return centroCusto!;
                    }
                    else
                    {
                        return null!;
                    }
                }
                else
                {
                    Console.WriteLine($"Erro na solicitação: {response.StatusCode} - {response.ReasonPhrase}");
                    return null!;
                }
            }
        }
    }
}
