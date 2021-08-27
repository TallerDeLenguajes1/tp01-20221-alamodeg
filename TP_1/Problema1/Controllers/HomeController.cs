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
                return $"ERROR DE ENTRADA: {ex.Message}";
            }
        }

        public IActionResult Problema2()
        {
            return View();
        }

        public string Problema2_Muestra(string numero1,string numero2)
        {
            try
            {
                int num1 = Convert.ToInt32(numero1);
                int num2 = Convert.ToInt32(numero2);
             
                return $"El cociente del numero {num1}/{num2} es {num1/num2}";
            }
            catch(DivideByZeroException)
            {
                return $"No se puede dividir en 0";
            }

            catch (Exception ex)
            {
                return $"ERROR: {ex.Message}";
            }
        }

        public IActionResult Problema3()
        {
            return View();
        }

        public IActionResult Problema4()
        {
            return View();
        }

        public string Problema4_Muestra(string numero1, string numero2)
        {
            try
            {
                int num1 = Convert.ToInt32(numero1);
                int num2 = Convert.ToInt32(numero2);

                return $"La nafta rinde {num2/num1}KM por litro";
            }
            catch (DivideByZeroException)
            {
                return $"No se puede dividir en 0";
            }

            catch (Exception ex)
            {
                return $"ERROR: {ex.Message}";
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
