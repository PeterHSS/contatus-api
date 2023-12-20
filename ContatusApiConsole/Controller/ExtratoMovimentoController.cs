using ContatusApiConsole.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;

namespace ContatusApiConsole.Controller
{
    internal class ExtratoMovimentoController
    {
        public async Task<int> PostTotalItems()
        {
            int pagina = 1; // Substitua pelo valor desejado
            int tamanhoPagina = 1000; // Substitua pelo valor desejado
            DateTime dataInicial = DateTime.Parse("2021-01-01"); // Substitua pelo valor desejado
            string auth = "9e732b08-7839-4985-b70f-56bc0a2e1965"; // Substitua pela chave de autorização adequada

            string dataInicio = dataInicial.ToString("yyyy-MM-dd");
            string dataFim = DateTime.Now.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");

            var body = new
            {
                dateFrom = dataInicio,
                dateTo = dataFim,
                quickFilter = "ALL",
                search = null as object
            };

            var jsonBody = JsonConvert.SerializeObject(body);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("x-Authorization", auth);

                var url = "https://services.contaazul.com/finance-pro-reader/v1/financial-statement-view";
                var queryString = $"?page={pagina}&page_size={tamanhoPagina}";
                var apiUrl = $"{url}{queryString}";

                var response = await httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    JObject json = JsonConvert.DeserializeObject<JObject>(jsonResponse)!;

                    JToken itemsToken = json["totalItems"];

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

        public async Task<List<ExtratoMovimento>> PostExtratoMovimento(int pagina)
        {
            //int pagina = 1; // Substitua pelo valor desejado
            int tamanhoPagina = 1000; // Substitua pelo valor desejado
            DateTime dataInicial = DateTime.Parse("2021-01-01"); // Substitua pelo valor desejado
            string auth = "9e732b08-7839-4985-b70f-56bc0a2e1965"; // Substitua pela chave de autorização adequada

            string dataInicio = dataInicial.ToString("yyyy-MM-dd");
            string dataFim = DateTime.Now.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd");

            var body = new
            {
                dateFrom = dataInicio,
                dateTo = dataFim,
                quickFilter = "ALL",
                search = null as object
            };

            var jsonBody = JsonConvert.SerializeObject(body);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("x-Authorization", auth);

                var url = "https://services.contaazul.com/finance-pro-reader/v1/financial-statement-view";
                var queryString = $"?page={pagina}&page_size={tamanhoPagina}";
                var apiUrl = $"{url}{queryString}";

                var response = await httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    JObject json = JsonConvert.DeserializeObject<JObject>(jsonResponse)!;

                    JToken itemsToken = json["items"];

                    if (itemsToken != null)
                    {

                        var extratoMovimento = itemsToken.ToObject<List<ExtratoMovimento>>();

                        return extratoMovimento;
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
