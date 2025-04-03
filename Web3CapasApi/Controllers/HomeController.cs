using DataUsuarios.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Web3CapasApi.Controllers
{
    //Nos lleva siempre a vistas
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("http://localhost:59777/");
                var request = cliente.GetAsync("api/Values/").Result;

                if (request.IsSuccessStatusCode)
                {
                    string resultado = request.Content.ReadAsStringAsync().Result;
                    usuarios = JsonConvert.DeserializeObject<List<Usuario>>(resultado);
                    return View(usuarios);
                }
            }
            return View();
        }
        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(Usuario usuario)
        {
            try
            {
                using (HttpClient cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri("http://localhost:59777/");
                    var request = cliente.PostAsJsonAsync("api/Values/", usuario).Result;

                    if (request.IsSuccessStatusCode)
                    {
                        string resultado = request.Content.ReadAsStringAsync().Result;
                        Dictionary<string, string> mensaje = JsonConvert.DeserializeObject<Dictionary<string, string>>(resultado);
                        TempData["mensaje"] = mensaje["mensaje"];
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        string resultado = request.Content.ReadAsStringAsync().Result;
                        Dictionary<string, string> mensaje = JsonConvert.DeserializeObject<Dictionary<string, string>>(resultado);
                        TempData["error"] = mensaje["error"];
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
        public ActionResult Editar(int id)
        {
            Usuario usuario = new Usuario();
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("http://localhost:59777/");
                var request = cliente.GetAsync("api/Values/" + id).Result;

                if (request.IsSuccessStatusCode)
                {
                    string resultado = request.Content.ReadAsStringAsync().Result;
                    usuario = JsonConvert.DeserializeObject<Usuario>(resultado);
                    return View(usuario);
                }
                else
                {
                    TempData["error"] = $"Error con la comunicacion del serivicio API";
                    return RedirectToAction("Index");
                }
            }
        }
        [HttpPost]
        public ActionResult Editar(Usuario usuario)
        {
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("http://localhost:59777/");
                var request = cliente.PutAsJsonAsync("api/Values/", usuario).Result;

                if (request.IsSuccessStatusCode)
                {
                    TempData["mensaje"] = $"Se Edito con exito";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = $"Error con la comunicacion del serivicio API";
                    return RedirectToAction("Edit", new { id = usuario.Id });
                }
            }
        }
        public ActionResult Eliminar(int id)
        {
            using (HttpClient cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("http://localhost:59777/");
                var request = cliente.DeleteAsync("api/Values/" + id).Result;

                if (request.IsSuccessStatusCode)
                {
                    TempData["mensaje"] = $"Se Elimino con exito";
                }
                else
                {
                    TempData["error"] = $"Error con la comunicacion del servicio API";
                }
                return RedirectToAction("Index");

            }
        }
    }
}
