using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using task1proje3.Models;
using System.Net.Http;
using System;
using Newtonsoft.Json;
//using MySql.Data.MySqlClient.Memcached;


using MySqlX.XDevAPI;


using System.Security.Policy;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics.Metrics;
using task1proje3.helper;

namespace task1proje3.Controllers
{


    public class HomeController : Controller
    {

        Uri baseAddress = new Uri("https://api.covid19api.com/");
        HttpClient client;
       
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("deneme");

            //List<Country>modelLis= new List<Country>();
            List<Root> roots = new List<Root>(); //nesne olusturdum
            Root RestResponse = RestHelper<string, Root>.Get(baseAddress.ToString(),"summary",null);
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "summary").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                Root root = JsonConvert.DeserializeObject<Root>(data);

                //ViewBag.Roots = root.Global;
                //globalde 7 get set var datei soracagim global tamam 


                ViewBag.veri1 = root.Global.NewConfirmed;
                ViewBag.veri2 = root.Global.TotalConfirmed;
                ViewBag.veri3 = root.Global.NewDeaths;
                ViewBag.veri4 = root.Global.TotalDeaths;
                ViewBag.veri5 = root.Global.NewRecovered;
                ViewBag.veri6 = root.Global.TotalRecovered;
                ViewBag.veri7 = root.Global.Date; // bundan emin degilim


                ViewBag.veri8 = root.Countries.ToList();
                //ViewBag.veri8 = root.Countries;




                //ViewBag.Roots = roots;
                ViewBag.irem = root.Global.TotalConfirmed;


            }



            return View(RestResponse);

        }
        //public IActionResult CountryList()
        //{

        //    //List<Country>modelLis= new List<Country>();
        //    List<Countries> city= new List<Countries>(); //nesne olusturdum
        //    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "countries").Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        string data = response.Content.ReadAsStringAsync().Result;
        //        List<Countries> root= JsonConvert.DeserializeObject<Countries>(data);
              

        //        ViewBag.element1 = root.Slug;
        //        ViewBag.element2 = root.Country;
        //        ViewBag.element3 = root.ISO2;


        //    }



        //    return View();
        //}




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

