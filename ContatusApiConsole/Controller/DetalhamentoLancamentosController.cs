using ContatusApiConsole.Models;
using ContatusApiConsole.Repositories;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContatusApiConsole.Controller
{
    internal class DetalhamentoLancamentosController
    {

        private readonly DetalhamentoLancamentosRepository? _detalhamentoLancamentosRepository = new DetalhamentoLancamentosRepository();

        public async Task GetDetalhamentoLancamento(IEnumerable<string> ids)
        {
            string auth = "9e732b08-7839-4985-b70f-56bc0a2e1965"; // Substitua pela chave de autorização adequada

            foreach (var id in ids)
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("x-Authorization", auth);

                    var apiUrl = $"https://services.contaazul.com/contaazul-bff/finance/v1/installments/{id}/summary";

                    var response = await httpClient.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonResponse = await response.Content.ReadAsStringAsync();
                        if (!jsonResponse.IsNullOrEmpty())
                            _detalhamentoLancamentosRepository.InsertDetalhamentoLancamento(jsonResponse);
                    }
                }
            }

        }
    }
}
