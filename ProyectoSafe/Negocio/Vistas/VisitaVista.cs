using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Vistas
{
    public class VisitaVista
    {

        public class NuevaVista
        {

        }
         public class CorreoView
        {
            public int visita_id
            {
                get;
                set;
            }
            public string Descripcion
            {
                get;
                set;
            }

            public int id_empresa
            {
                get;
                set;
            }

            public int id_medico
            {
                get;
                set;
            }

            public string confirma
            {
                get;
                set;
            }
            public string NombreMedico
            {
                get;
                set;
            }

            public string Paciente
            {
                get;
                set;
            }

            public string Fecha
            {
                get;
                set;
            }

            public string Hora
            {
                get;
                set;
            }

            public string Lugar
            {
                get;
                set;
            }

            public string Direccion
            {
                get;
                set;
            }

            public string EmailMedico
            {
                get;
                set;
            }
        }
    }
}
