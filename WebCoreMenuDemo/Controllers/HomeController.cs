using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;
using WebCoreMenuDemo.Models;

namespace WebCoreMenuDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<HomeController> _logger;
        public string token;
        private object client;
        public HomeController(ILogger<HomeController> logger , IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration.GetSection("AppSettings");
        }


        public IActionResult Index()
        {
            string RestAPI = _configuration.GetSection("ConnectionString").Value;
            LOGINMODEL login = new LOGINMODEL();
            ROOT_APPLICATION app = new ROOT_APPLICATION();

            login.userName = "admin";
            login.password = "P@ssw0rd";
            RestClient client = new RestClient(RestAPI);
            RestRequest request = new RestRequest($"api/v1/Menus/Login", Method.Post);
            request.AddHeader("Authorization", "Bearer " + token);
            request.AddJsonBody(login);
            RestResponse response = client.Execute(request);
            if (response != null)
            {
                if (response.IsSuccessful)
                {
                    app = JsonConvert.DeserializeObject<ROOT_APPLICATION>(response.Content);
                    token = app.token;
                    ViewBag.token = token;
                    ViewBag.menus = app.application;
                }
            }

            return View();
        }

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