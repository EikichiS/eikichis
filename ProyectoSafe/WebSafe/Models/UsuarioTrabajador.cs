using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSafe.Models
{
    public class UsuarioTrabajador
    {
        public int id_trabajador { get; set; }
        public string Nombre { get; set; }
        public string Apellidop { get; set; }
        public string Apellidom { get; set; }
        public string Rut { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Empresa { get; set; }

        public List<CapacitacionR>  DatosCapacitacion { get; set; }
        public List<VisitasMedicas> DatosVisitas { get; set; }
    }
}