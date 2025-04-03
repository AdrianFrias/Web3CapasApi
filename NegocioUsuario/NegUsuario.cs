using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataUsuarios;
using DataUsuarios.Modelo;

namespace NegocioUsuario
{
    public class NegUsuario
    {
        DatUsuario dat = new DatUsuario();
        public List<Usuario> Obtener()
        {
            return dat.Obtener();
        }
        public List<Usuario> Buscar(string valor)
        {
            return dat.Buscar(valor);
        }
        public Usuario ObtenerPorId(int id)
        {
            return dat.ObtenerPorId(id);
        }
        
        //Como se usa solo ene le negocio, podemos hacer privado
        private void Validar(string nombre, string paterno)
        {
            Usuario usuario = dat.Validar(nombre, paterno);
            if (usuario != null)
            {
                throw new Exception($"El Usuario \"{nombre} {paterno}\" ya existe");
            }
        }
        public void Agregar(Usuario usuario)
        {
            //Validar(usuario.Nombres, usuario.Paterno);
            this.Validar(usuario.Nombres, usuario.Paterno);
            dat.Agregar(usuario);
        }
        public void Editar(Usuario usuario)
        {
            dat.Editar(usuario);
        }
        public void Borrar(int id)
        {
            dat.Borrar(id);
        }
    }
}
