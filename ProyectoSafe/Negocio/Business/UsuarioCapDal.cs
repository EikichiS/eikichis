using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALC;
namespace Negocio.Business
{
    public class UsuarioCapDal
    {
        public static List<USUARIO_CAPACITACION> GetAll()
        {
            List<USUARIO_CAPACITACION> query = new List<USUARIO_CAPACITACION>();
            SafeEntities se = new SafeEntities();
            using (se)
            {
                query = se.USUARIO_CAPACITACION.ToList();
                foreach (var obj in query)
                {
                    se.Entry(obj).Reference(x => x.USUARIO).Load();
                    se.Entry(obj).Reference(x => x.CAPACITACION).Load(); 
                }
                return query;
            }

        }

        public static List<USUARIO_CAPACITACION> GetCapacitacionforid(int id_Capacitacion)
        {
            return GetAll().Where(x => x.CAPACITACION.ID_CAPACITACION.Equals(id_Capacitacion)).ToList();
        }
    }
}
