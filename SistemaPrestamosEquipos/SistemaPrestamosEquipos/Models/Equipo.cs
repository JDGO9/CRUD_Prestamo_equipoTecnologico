using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrestamosEquipos.Models
{
    public class Equipo
    {
        public int EquipoID { get; set; }
        public string Nombre { get; set; }
        public string NumeroSerie { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }
    }
}
