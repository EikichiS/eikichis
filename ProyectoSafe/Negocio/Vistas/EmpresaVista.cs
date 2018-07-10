using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALC;

namespace Negocio.Vistas
{
    public class EmpresaVista
    {
        public class CreateEmpresaViewModel
        {
            public int ID_EMPRESA { get; set; }
            public string RAZON_SOCIAL { get; set; }
            public string RUT_EMPRESA { get; set; }
            public string DIRECCION { get; set; }
        }

        public class AutocompleteEmpresaViewModel
        {
            public string Key
            {
                get;
                set;
            }

            public string Value
            {
                get;
                set;

            }
        }
       public int ID_EMPRESA { get; set; }
       public string RAZON_SOCIAL { get; set; }
       public string RUT_EMPRESA { get; set; }
       public string DIRECCION { get; set; }
        public List<EMPRESA> Empresas { get; set; }
        public List<CreateEmpresaViewModel> TableEmpresa { get; set; }
    }
}