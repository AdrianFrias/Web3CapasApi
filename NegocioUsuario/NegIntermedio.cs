using DataUsuarios;
using DataUsuarios.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioUsuario
{
    public class NegIntermedio
    {
        DatIntermedio datos = new DatIntermedio();
        public List<Intermedio> Obtener()
        {
            return datos.Obtener();
        }
    }
}
