using DataUsuarios;
using DataUsuarios.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioUsuario
{
    public class NegContacto
    {
        DatContacto dat = new DatContacto();
        public object Obtener()
        {
            return dat.Obtener();
        }
        public List<Contacto> ObtenerL()
        {
            return dat.ObtenerL();
        }
    }
}
