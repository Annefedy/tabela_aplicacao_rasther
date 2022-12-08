using AplicacaoRasther.Models;
using AplicacaoRasther.Models.ViewModel;
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
        public static GenericModel GenericModel { get; set; } = new GenericModel();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
           var teste = await GetCategories();
            return View(teste);
        }

        #region GET LIST OF CATEGORY
        public async Task<GenericModel> GetCategories()
        {

            using (HttpClient Client = new HttpClient())
            {
                HttpResponseMessage response = await Client.GetAsync(PathCategory);
                var result = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    await GetMontadoras("");
                    GenericModel.Categoria.CategoriasList = JsonConvert.DeserializeObject<List<string>>(result);
                    return GenericModel;
                }
                return new GenericModel();
            }

        }
        #endregion


        #region GET LIST OF MONTADORA
        public async Task GetMontadoras(string Caterogiria)
        {

            using (HttpClient Client = new HttpClient())
            {
                HttpResponseMessage response = await Client.GetAsync(PathMontadora + Caterogiria);
                var result = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    await GetVeiculos();
                    GenericModel.Montadora.MontadoraList = JsonConvert.DeserializeObject<List<Montadora>>(result);
                    
                }
               
            }

        }
        #endregion  #region GET LIST OF MONTADORA


        #region GET LIST OF GETVEICULOS
        public async  Task GetVeiculos()
        {

            using (HttpClient Client = new HttpClient())
            {
                HttpResponseMessage response = await Client.GetAsync(PathVeiculo);
                var result = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    await GetMotorizacoa();
                    GenericModel.Veiculo.VeiculoList = JsonConvert.DeserializeObject<List<Veiculo>>(result);
                }
            }
        }
        #endregion

        #region GET LIST OF GETMOTORIZACOA
        public async Task GetMotorizacoa()
        {

            using (HttpClient Client = new HttpClient())
            {
                HttpResponseMessage response = await Client.GetAsync(PathMotorizacaoo);
                var result = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    GenericModel.Motorizacao.MotorizacaoList = JsonConvert.DeserializeObject<List<Motorizacao>>(result);
            }
        }
        #endregion


        #region GET LIST OF TIPOSDESISTEMAS
        public async Task<List<TipoDeSistema>> GetTiposDeSistemas()
        {

            using (HttpClient Client = new HttpClient())
            {
                HttpResponseMessage response = await Client.GetAsync(PathMotorizacaoo);
                var result = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    return ViewBag.TiposDeSistemaList = JsonConvert.DeserializeObject<List<TipoDeSistema>>(result);
                return new List<TipoDeSistema>();

            }
        }
        #endregion

        #region GET LIST OF TIPOSDESISTEMAS
        public async Task<List<Sistema>> GetSistemas()
        {

            using (HttpClient Client = new HttpClient())
            {
                HttpResponseMessage response = await Client.GetAsync(PathMotorizacaoo);
                var result = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                    return ViewBag.SistemasList = JsonConvert.DeserializeObject<List<Sistema>>(result);
                return new List<Sistema>();
            }
        }
        #endregion



        public IActionResult Privacy()
        {
            return View();
        }
    }
}
