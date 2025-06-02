using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPrestamosEquipos.Models
{
    public class UsuarioRol
    {
        public int UsuarioRolID { get; set; }
        public int UsuarioID { get; set; }
        public int RolID { get; set; }
        // Opcional: Propiedades para mostrar nombres en UI
        public string NombreUsuario { get; set; }
        public string NombreRol { get; set; }
    }
}
