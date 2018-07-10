using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALC;

namespace Negocio.Business
{
    public class EvaluacionDal
    {
        public static List<EVALUACION> GetAll()
        {
            List<EVALUACION> query = new List<EVALUACION>();
            using (var context = new SafeEntities())
            {
                query = context.EVALUACION.ToList();

                foreach (EVALUACION val in query)
                {
                    context.Entry(val).Reference(x => x.NOMBRE_EV).Load();
                }
            }
            return query;
        }

        public static EVALUACION Get(int ID_EMPRESA)
        {
            return GetAll().FirstOrDefault<EVALUACION>(x => x.ID_EMPRESA.Equals(ID_EMPRESA));
        }
    }
}
