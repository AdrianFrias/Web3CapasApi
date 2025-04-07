using DataUsuarios.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataUsuarios
{
    public class DatContacto
    {
        generacion31Entities db = new generacion31Entities();
        public object Obtener()
        {
            //return db.Contacto.Include("Usuario").ToList();
            //return db.Contacto.ToList();
            var lista = db.Contacto.Select(c => new
            {
                c.Id,
                c.Nombre,
                c.ApPaterno,
                c.ApMaterno,
                c.UsuarioId,
                c.Edad,
                c.Foto
            }).ToList();

            return lista;
        }
        public List<Contacto> ObtenerL()
        {
            return db.Contacto.Include("Usuario").ToList();
        }
    }
}
