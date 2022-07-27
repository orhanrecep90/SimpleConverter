using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimpleConverter.Service;
using SimpleConverter.Service.Model;
using SimpleConverter.WebApp.Models;
using System.Diagnostics;

namespace SimpleConverter.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConverterService _converterService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IConverterService converterService, ILogger<HomeController> logger)
        {
            _converterService = converterService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new ResponseModel());
        }

        [HttpPost]
        public IActionResult Index(string json,string btnType)
        {
            _logger.LogWarning($"Req: {json}");
            ViewBag.Request = json;
            ResponseModel response = new ResponseModel() ;
            if (btnType=="HTML")
            {
                response = _converterService.GetHtmlTableFromJson(json);
            }
            else if (btnType == "XML")
            {
                response = _converterService.GetXmlFromJson(json);
            }

            _logger.LogWarning($"Res: {response.Response}");
            return View(response);
        }


        #region default pages
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}