using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Problema1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using TP1_2021.Entities;

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
        public string Problema1_Mostrar(string numero)
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

        public string Problema2_Mostrar(string numero1,string numero2)
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

     
        public string Problema3()
        {
            string listadoProvincias = "";
            try
            {
                listadoProvincias += getProvincias();
                return listadoProvincias;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return $"Error: {ex.Message}";
            }
        }

        public static string getProvincias()
        {
            var url = $"https://apis.datos.gob.ar/georef/api/provincias?campos=id,nombre";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            string cadena = "";
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader != null)
                        {
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                string responseBody = objReader.ReadToEnd();
                                provinciasArgentina ListProvincias = JsonSerializer.Deserialize<provinciasArgentina>(responseBody);
                                foreach (provincia prov in ListProvincias.Provincias)
                                {
                                    cadena += $"\t id : {prov.Id}, nombre : {prov.Nombre} \n ";
                                }
                            }
                        }
                    }
                }
                return cadena;

            }
            catch (Exception ex)
            {
                return $"Error {ex.Message}";
            }

        }
        public IActionResult Problema4()
        {
            return View();
        }

        public string Problema4_Mostrar(string numero1, string numero2)
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
