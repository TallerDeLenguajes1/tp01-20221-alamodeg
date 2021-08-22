using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Problema1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Problema1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Problema1()
        {
            return View();
        }

        [HttpPost] //recibe la cadena de texto del navegador??
        public string Problema1_Muestra(string numero)
        {
            try
            {
                int num = Convert.ToInt32(numero);
                return $"El cuadrado del numero {num} es {num*num}";
            }
            catch (Exception ex)
            {
                return $"ERROR: {ex.Message} - Formato de entrada incorrecto";
            }
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
