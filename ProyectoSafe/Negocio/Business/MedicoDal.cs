using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALC;
using System.Web.Mvc;

namespace Negocio.Business
{
    public class MedicoDal
    {
        public static IEnumerable<SelectListItem> Medicos
        {
            get
            {
                IEnumerable<SelectListItem> defaultItem = Enumerable.Repeat(new SelectListItem
                {
                    Value = "",
                    Text = "[Seleccione]"
                }, count: 1);

                SelectList lista = new SelectList(GetAll(), "ID_MEDICO", "NOMBRE_COMPLETO");

                return defaultItem.Concat(lista);
            }
        }

        public static IEnumerable<SelectListItem> MedicosMail
        {
            get
            {
                IEnumerable<SelectListItem> defaultItem = Enumerable.Repeat(new SelectListItem
                {
                    Value = "",
                    Text = "[Seleccione]"
                }, count: 1);

                SelectList lista = new SelectList(GetAll(), "EMAIL", "NOMBRE_COMPLETO");

                return defaultItem.Concat(lista);
            }
        }
        public static List<MEDICO> GetAll()
        {
            List<MEDICO> query = new List<MEDICO>();
            SafeEntities se = new SafeEntities();
            using (se)
            {
                query = se.MEDICO.ToList();
                foreach (var obj in query)
                {
                    se.Entry(obj).Collection(x => x.VISITA_MEDICA).Load();
                }
                return query;
            }

        }

        public static string GetFullName(int id_medico)
        {
            DALC.MEDICO medico = GetAll().FirstOrDefault(x => x.ID_MEDICO.Equals(id_medico));

            return medico.NOMBRE_COMPLETO;
        }

        public static string GetMail(int id_medico)
        {
            DALC.MEDICO medico = GetAll().FirstOrDefault(x => x.ID_MEDICO.Equals(id_medico));

            return medico.EMAIL;
        }
    }
}
