using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Vistas
{
    public class SupervisorVista
    {
        public class DetallesEvaluacionEmpresa
        {
            public int IdEvaluacion { get; set; }
            public int Tipoevaluacion { get; set; }
            public string Nombre { get; set; }
            public string Tecnico { get; set; }
            public int Empresa { get; set; }
            public string Encargado { get; set; }
            public string DESC_EV { get; set; } 
            public string OBSERVACION { get; set; }
        }
    }
}
