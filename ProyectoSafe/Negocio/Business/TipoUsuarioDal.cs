using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALC;

namespace Negocio.Vistas
{
    public class TipoUsuarioDal
    {



        public static List<TIPO_USUARIO> GetAll()
        {
            List<TIPO_USUARIO> query = new List<TIPO_USUARIO>();
            SafeEntities se = new SafeEntities();
            using (se)
            {
                query = se.TIPO_USUARIO.ToList();
                foreach(var obj in query)
                {
                    se.Entry(obj).Collection(x => x.USUARIO).Load();
                }
                return query;
            }

        }

        public static List<String> GetAll(string username)
        {
            return UsuarioDal.GetAll().Where(x => x.USERNAME.Equals(username)).Select(x => x.TIPO_USUARIO).ToList().Select(x => x.ROL).ToList();
        }

        public static TIPO_USUARIO Administrador
        {
            get
            {
                return Get(1);
            }
        }

        public static TIPO_USUARIO Supervisor
        {
            get
            {
                return Get(2);
            }
        }


        public static TIPO_USUARIO Cliente
        {
            get
            {
                return Get(3);
            }
        }


        public static TIPO_USUARIO Tecnico
        {
            get
            {
                return Get(4);
            }
        }

        public static TIPO_USUARIO Medico
        {
            get
            {
                return Get(5);
            }
        }
        public static TIPO_USUARIO Trabajador
        {
            get
            {
                return Get(6);
            }
        }

        public static TIPO_USUARIO Get(int idRol)
        {
            return GetAll().FirstOrDefault<TIPO_USUARIO>(x => x.ID_TIPOUS.Equals(idRol));
        }
    }
}
