using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALC;
using System.Web.Mvc;

namespace Negocio.Business  
{
    public class EmpresaDal
    {

        public static IEnumerable<SelectListItem> Empresas
        {
            get
            {
                IEnumerable<SelectListItem> defaultItem = Enumerable.Repeat(new SelectListItem
                {
                    Value = "",
                    Text = "[Seleccione]"
                }, count: 1);

                SelectList lista = new SelectList(GetAll(), "ID_EMPRESA", "RAZON_SOCIAL");

                return defaultItem.Concat(lista);
            }
        }
        public static List<EMPRESA> GetAll()
        {
            List<EMPRESA> query = new List<EMPRESA>();

            using (var context = new SafeEntities())
            {
                query = context.EMPRESA.ToList();

                foreach (EMPRESA val in query)
                {
                    context.Entry(val).Reference(x => x.TIPO_EMPRESA).Load();
                    context.Entry(val).Collection(x => x.USUARIO).Load();
                    context.Entry(val).Collection(x => x.INSTALACION).Load();
                    context.Entry(val).Collection(x => x.EVALUACION).Load();
                    context.Entry(val).Collection(x => x.VISITA_MEDICA).Load();
                }
            }
            return query;
        }

        public static EMPRESA Get(string RazonSocial)
        {
            return GetAll().FirstOrDefault<EMPRESA>(x => x.RAZON_SOCIAL.ToUpper().Equals(RazonSocial.ToUpper()));
        }

        public static EMPRESA Get(int idEmpresa)
        {
            return GetAll().FirstOrDefault<EMPRESA>(x => x.ID_EMPRESA.Equals(idEmpresa));
        }

        public static string GetDireccion(int idempresa)
        {
            DALC.EMPRESA empresa = GetAll().FirstOrDefault(x => x.ID_EMPRESA.Equals(idempresa));

            return empresa.DIRECCION;
        }
    }
}
