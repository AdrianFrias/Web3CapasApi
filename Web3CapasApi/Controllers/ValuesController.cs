using DataUsuarios.Modelo;
using NegocioUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Web3CapasApi.Controllers
{
    //No nos lleva a vista, maneja datos
    public class ValuesController : ApiController
    {
        NegUsuario neg = new NegUsuario();
        // GET api/values
        [HttpGet]
        public List<Usuario> Obtener()
        {
            return neg.Obtener();
        }

        [HttpGet]
        [Route("Buscar")]
        public List<Usuario> Buscar(string valor)
        {
            return neg.Buscar("");
        }

        // GET api/values/5
        [HttpGet]
        public Usuario ObtenerPorID(int id)
        {
            return neg.ObtenerPorId(id);
        }

        // POST api/values
        [HttpPost]
        //IHttpActionResult arece que permite devolver respuestas http con estado y contenido.
        public IHttpActionResult Agregar(Usuario usuario)
        {
            try
            {
                neg.Agregar(usuario);
                //El archivo jason es basicamente un diccionario de python con una llave y valor
                //aqui la lave es mensaje y su valor es el texto
                Dictionary<string, string> mensaje = new Dictionary<string, string> { { "mensaje", $"Usuario {usuario.Nombres} {usuario.Paterno} agregado con éxito" } };
                //El ok manda que todo salio bein como si fuera un 200 junto con un json que contiene un mensaje
                return Ok(mensaje);
            }
            catch (Exception ex)
            {
                Dictionary<string, string> mensajeerror = new Dictionary<string, string> { { "error", $"{ex.Message}" } };
                //Content envia emsajes personali<asdos indicando el estatus y el mensaje
                //HttpStatusCode.BadRequest inidca un error de 400 
                return Content(HttpStatusCode.BadRequest, mensajeerror);
            }
        }

        // PUT api/values/5
        [HttpPut]
        public void Editar(Usuario usuario)
        {
            neg.Editar(usuario);
        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete(int id)
        {
            neg.Borrar(id);
        }
    }
}
