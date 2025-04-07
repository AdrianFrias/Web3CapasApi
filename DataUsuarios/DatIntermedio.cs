using DataUsuarios.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataUsuarios
{
    public class DatIntermedio
    {
        generacion31Entities db = new generacion31Entities();
        public List<Intermedio> Obtener()
        {
            return db.Intermedio.ToList();
        }
    }
}
