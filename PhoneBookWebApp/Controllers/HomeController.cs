using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nancy.Json;
using Newtonsoft.Json;
using PhoneBookWebApp.Helper;
using PhoneBookWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        PhonebookAPI phonebookApi = new PhonebookAPI();
        public async Task<IActionResult> Index(string strName)
        {
            List<PhonebookData> phonebooks = new List<PhonebookData>();
            HttpClient client = phonebookApi.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Phonebook/SearchPhonebook?strName=" + strName);
            
            
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                phonebooks = JsonConvert.DeserializeObject<List<PhonebookData>>(results);
            }
            
            return View(phonebooks);
        }


        public async Task<IActionResult> Details(int Id)
        {
            var phonebooks = new PhonebookData();
            HttpClient client = phonebookApi.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Phonebook/{Id}");

            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                phonebooks = JsonConvert.DeserializeObject<PhonebookData>(results);
            }

            return View(phonebooks);
        }

        public ActionResult create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult create(PhonebookData phonebook)
        {
            HttpClient client = phonebookApi.Initial();

            var postTask = client.PostAsync("api/Phonebook", new StringContent(
   new JavaScriptSerializer().Serialize(phonebook), Encoding.UTF8, "application/json")).Result;
            //postTask.wa();

            if (postTask.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        //public async Task<IActionResult> Index(string strName)
        //{
        //    var phonebooks = new PhonebookData();
        //    HttpClient client = phonebookApi.Initial();
        //    HttpResponseMessage res = await client.GetAsync($"api/Phonebook/{strName}");

        //    if (res.IsSuccessStatusCode)
        //    {
        //        var results = res.Content.ReadAsStringAsync().Result;
        //        phonebooks = JsonConvert.DeserializeObject<PhonebookData>(results);
        //    }

        //    return View(phonebooks);
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
