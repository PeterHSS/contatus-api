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
    internal class CategoriasController
    {
        public async Task<List<Categorias>> GetCategorias()
        {
            string auth = "9e732b08-7839-4985-b70f-56bc0a2e1965";

            string[] types = new string[2] { "expenses", "revenues" };

            var categorias = new List<Categorias>();

            foreach (var type in types)
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("x-Authorization", auth);

                    var apiUrl = $"https://services.contaazul.com/app/finance/v1/category/parentable/{type}?includeAllLevels=true&includeLabels=false";

                    var response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();

                        var categoriaDeserialized = JsonConvert.DeserializeObject<List<Categorias>>(jsonResponse);

                        categorias.AddRange(categoriaDeserialized!);
                    }
                    else
                    {
                        Console.WriteLine($"Erro na solicitação: {response.StatusCode} - {response.ReasonPhrase}");

                    }
                }
            }

            return categorias;
        }
    }
}
