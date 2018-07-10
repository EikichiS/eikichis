using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALC;

namespace Negocio.Business
{
    public class InstalacionesDal
    {
        public static List<INSTALACION> GetAll()
        {
            List<INSTALACION> query = new List<INSTALACION>();

            using (var context = new SafeEntities())
            {
                query = context.INSTALACION.ToList();

                foreach (INSTALACION val in query)
                {
                    context.Entry(val).Reference(x => x.EMPRESA).Load();
                }
            }
            return query;
        }


        public static INSTALACION Get(int idEvaluacion)
        {
            return GetAll().FirstOrDefault<INSTALACION>(x => x.SECTOR.Equals(idEvaluacion));
        }

        public static INSTALACION Get(string ID_EMPRESA)
        {
            return GetAll().FirstOrDefault<INSTALACION>(x => x.ID_EMPRESA.Equals(ID_EMPRESA));
        }

    }
}
