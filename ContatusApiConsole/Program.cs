using ContatusApiConsole.Controller;
using ContatusApiConsole.Models;
using ContatusApiConsole.Repositories;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using RestSharp;
using System.Linq;
using System.Text;

internal class Program
{
    public static async Task Main(string[] args)
    {
        CompetenciaController competenciaController = new CompetenciaController();
        ContasPagarController contasPagarController = new ContasPagarController();
        ContasReceberController contasReceberController = new ContasReceberController();
        ContasBancariasController contasBancariasController = new ContasBancariasController();
        DREController dREController = new DREController();
        ExtratoMovimentoController extratoMovimentoController = new ExtratoMovimentoController();
        FluxoCaixaDiarioController fluxoCaixaDiarioController = new FluxoCaixaDiarioController();
        CentroCustoController centroCustoController = new CentroCustoController();
        CategoriasController categoriasController = new CategoriasController();
        FluxoCaixaMensalController fluxoCaixaMensalController = new FluxoCaixaMensalController();
        DetalhamentoLancamentosController detalhamentoLancamentosController = new DetalhamentoLancamentosController();

        CompetenciaRepository competenciaRepository = new CompetenciaRepository();
        ContasPagarRepository contasPagarRepository = new ContasPagarRepository();
        ContasReceberRepository contasReceberRepository = new ContasReceberRepository();
        ContasBancariasRepository contasBancariasRepository = new ContasBancariasRepository();
        DRERepository dRERepository = new DRERepository();
        ExtratoMovimentoRepository extratoMovimentoRepository = new ExtratoMovimentoRepository();
        FluxoCaixaDiarioRepository fluxoCaixaDiarioRepository = new FluxoCaixaDiarioRepository();
        CentroCustoRepository centroCustoRepository = new CentroCustoRepository();
        CategoriasRepository categoriasRepository = new CategoriasRepository();
        FluxoCaixaMensalRepository fluxoCaixaMensalRepository = new FluxoCaixaMensalRepository();
        DetalhamentoLancamentosRepository detalhamentoLancamentosRepository = new DetalhamentoLancamentosRepository();

        //var totalItems = await contasPagarController.PostTotalItems();

        //for (int pagina = 1; pagina <= totalItems; pagina++)
        //{
        //    var contasPagar = await contasPagarController.PostContasPagar(pagina);
        //    contasPagarRepository.InsertContasPagar(contasPagar);
        //}

        //totalItems = await contasReceberController.PostTotalItems();

        //for (int pagina = 1; pagina <= totalItems; pagina++)
        //{
        //    var contasReceber = await contasReceberController.PostContasReceber(pagina);
        //    contasReceberRepository.InsertContasReceber(contasReceber);
        //}

        //totalItems = await centroCustoController.GetTotalItems();

        //for (int pagina = 1; pagina <= totalItems; pagina++)
        //{
        //    var centrosCusto = await centroCustoController.GetCentroCusto(pagina);
        //    centroCustoRepository.InsertCentroCusto(centrosCusto);
        //}

        //totalItems = await competenciaController.PostTotalItems();

        //for (int pagina = 1; pagina <= totalItems; pagina++)
        //{
        //    var competencia = await competenciaController.PostCompetencia(pagina);
        //    competenciaRepository.InsertCompetenciaItems(competencia);
        //}

        //totalItems = await extratoMovimentoController.PostTotalItems();

        //for (int pagina = 1; pagina <= totalItems; pagina++)
        //{
        //    var extratosMovimentos = await extratoMovimentoController.PostExtratoMovimento(pagina);
        //    extratoMovimentoRepository.InsertExtratoMovimento(extratosMovimentos);
        //}

        //var competencia = await competenciaController.GetCompetenciaByDateAsync();
        //var contasReceber = await contasReceberController.PostContasReceber();
        //var contasBancarias = await contasBancariasController.GetContasBancarias();
        //var dre = await dREController.GetDRE(2023);
        //var fluxoCaixaDiario = await fluxoCaixaDiarioController.PostFluxoCaixaDiario();
        //var categorias = await categoriasController.GetCategorias();
        //var fluxoCaixaMensal = await fluxoCaixaMensalController.PostFluxoCaixaMensal(2021);
        //var listaIdsContasPagar = contasPagar.Select(x => x.Id).ToList();
        //var listaIdsContasReceber = contasReceber.Select(x => x.Id).ToList();
        //var listaGeralArquivos = Directory.GetFiles(@"C:\Users\Administrator\Desktop\Contatus\detalhamento_lancamentos").ToList();
        ////var listaFormatada = listaGeralArquivos.Select(p => Path.GetFileNameWithoutExtension(p));

        var listaIds = detalhamentoLancamentosRepository.RetornaListaDeIds();

        await detalhamentoLancamentosController.GetDetalhamentoLancamento(listaIds);

        //contasReceberRepository.InsertContasReceber(contasReceber);
        //contasBancariasRepository.InsertContasBancarias(contasBancarias);
        //dRERepository.InsertDRE(dre);
        //fluxoCaixaDiarioRepository.InsertFluxoCaixaDiario(fluxoCaixaDiario);
        //centroCustoRepository.InsertCentroCusto(centrosCusto);
        //categoriasRepository.InsertCategorias(categorias);
        //fluxoCaixaMensalRepository.InsertFluxoCaixaMensal(fluxoCaixaMensal);
    }
}