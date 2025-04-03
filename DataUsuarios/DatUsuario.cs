using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataUsuarios.Modelo;

namespace DataUsuarios
{
    public class DatUsuario
    {
        generacion31Entities db = new generacion31Entities();
        public List<Usuario> Obtener()
        {
            return db.Usuario.ToList();
        }
        public List<Usuario> Buscar(string valor)
        {
            return db.Usuario.Where(x => x.Nombres.Contains(valor)).ToList();
        }
        public Usuario ObtenerPorId(int id)
        {
            return db.Usuario.Find(id);
        }
        public Usuario Validar(string nombre, string paterno)
        {
            return db.Usuario.Where(x => x.Nombres == nombre && x.Paterno == paterno).FirstOrDefault();
        }
        public void Agregar(Usuario usuario)
        {
            db.Usuario.Add(usuario);
            db.SaveChanges();
            db.Dispose();
        }
        public void Editar(Usuario usuario)
        {
            db.Usuario.AddOrUpdate(usuario);
            db.SaveChanges();
            db.Dispose();
        }
        public void Borrar(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
            db.SaveChanges();
            db.Dispose();
        }
    }
}
