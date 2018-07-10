using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALC;
using System.Web.Mvc;

namespace Negocio.Business
{
    public class VisitaMedicaDal
    {
        public static List<VISITA_MEDICA> GetAll()
        {
            List<VISITA_MEDICA> query = new List<VISITA_MEDICA>();
            SafeEntities se = new SafeEntities();
            using (se)
            {
                query = se.VISITA_MEDICA.ToList();
                foreach (var obj in query)
                {
                    se.Entry(obj).Reference(x => x.EMPRESA).Load();
                    se.Entry(obj).Reference(x => x.MEDICO).Load();
                    se.Entry(obj).Collection(x => x.DIAGNOSTICO).Load();
                    se.Entry(obj).Collection(x => x.USUARIO_VISITA).Load();
                }
                return query;
            }
        }

        public static List<VISITA_MEDICA> GetAll(int id_Medico)
        {
            return GetAll().Where(x => x.MEDICO.ID_MEDICO.Equals(id_Medico)).ToList();
        }

        public static List<VISITA_MEDICA> GetbyEmpresa(int id_Empresa)
        {
            return GetAll().Where(x => x.EMPRESA.ID_EMPRESA.Equals(id_Empresa)).ToList();
        }

        public static string GetNombrePaciente(int id_visita)
        {
            DALC.VISITA_MEDICA visita = GetAll().FirstOrDefault(x => x.ID_VISITA.Equals(id_visita));

            return visita.PACIENTE;
        }
    }
}
