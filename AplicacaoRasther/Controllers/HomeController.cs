using AplicacaoRasther.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AplicacaoRasther.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private string PathCategory = "https://service.tecnomotor.com.br/iRasther/tipo?pm.platform=1&pm.version=23";
        private string PathMontadora = "https://service.tecnomotor.com.br/iRasther/montadora?pm.platform=1&pm.version=23&pm.type=PESADOS";
        private string PathVeiculo = "https://service.tecnomotor.com.br/iRasther/veiculo?pm.platform=1&pm.version=23&pm.type=LEVES&p";
        private string PathMotorizacaoo = "https://service.tecnomotor.com.br/iRasther/motorizacao?pm.platform=1&pm.version=23&pm.type=LEVE";
        public Categoria Categoria = new Categoria();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            await GetCategories();
            return View();
        }

        #region GET LIST OF CATEGORY
        public async Task<List<string>> GetCategories()
        {

            using (HttpClient Client = new HttpClient())
            {
                HttpResponseMessage response = await Client.GetAsync(PathCategory);
                var result = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.CategoriasList = JsonConvert.DeserializeObject<List<string>>(result);
                    await GetMontadoras();
                }
            }
            return Categoria.CategoriasList;
        }
        #endregion


        #region GET LIST OF MONTADORA
        public async Task GetMontadoras()
        {

            using (HttpClient Client = new HttpClient())
            {
                HttpResponseMessage response = await Client.GetAsync(PathMontadora);
                var result = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.MontadoraList = JsonConvert.DeserializeObject<List<Montadora>>(result);
                    await GetVeiculos();
                }
            }

        }
        #endregion  #region GET LIST OF MONTADORA


        #region GET LIST OF GETVEICULOS
        public async Task GetVeiculos()
        {

            using (HttpClient Client = new HttpClient())
            {
                HttpResponseMessage response = await Client.GetAsync(PathVeiculo);
                var result = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    ViewBag.VeiculoList = JsonConvert.DeserializeObject<List<Veiculo>>(result);
                // await GetMotorizacoa();
            }
        }
        #endregion

        #region GET LIST OF GETVEICULOS
        public async Task GetMotorizacoa()
        {

            using (HttpClient Client = new HttpClient())
            {
                HttpResponseMessage response = await Client.GetAsync(PathMotorizacaoo);
                var result = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.MotorizacaoList = JsonConvert.DeserializeObject<List<Motorizacao>>(result);
                    //await GetMotorizacoa();
                }
            }
        }
        #endregion


        #region GET LIST OF TIPOSDESISTEMAS
        public async Task GetTiposDeSistemas()
        {

            using (HttpClient Client = new HttpClient())
            {
                HttpResponseMessage response = await Client.GetAsync(PathMotorizacaoo);
                var result = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.TiposDeSistemaList = JsonConvert.DeserializeObject<List<TipoDeSistema>>(result);
                }
            }
        }
        #endregion

        #region GET LIST OF TIPOSDESISTEMAS
        public async Task GetSistemas()
        {

            using (HttpClient Client = new HttpClient())
            {
                HttpResponseMessage response = await Client.GetAsync(PathMotorizacaoo);
                var result = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    ViewBag.SistemasList = JsonConvert.DeserializeObject<List<Sistema>>(result);

            }
        }
        #endregion



        public IActionResult Privacy()
        {
            return View();
        }
    }
}
