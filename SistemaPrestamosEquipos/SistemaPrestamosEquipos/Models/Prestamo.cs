using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrestamosEquipos.Models
{
    public class Prestamo
    {
        public int PrestamoID { get; set; }
        public int EquipoID { get; set; }
        public int UsuarioID { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucionEsperada { get; set; }
        public DateTime? FechaDevolucionReal { get; set; } 
        public string EstadoPrestamo { get; set; }
      
        public string NombreEquipo { get; set; }
        public string NombreUsuario { get; set; }
    }
}
