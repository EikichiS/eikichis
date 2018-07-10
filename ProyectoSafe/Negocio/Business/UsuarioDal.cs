using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALC;

namespace Negocio.Vistas
{
    public class UsuarioDal
    {
        public static List<USUARIO> GetAll()
        {
            List<USUARIO> query = new List< USUARIO>();
            SafeEntities se = new SafeEntities();
            using (se)
            { 
                query = se.USUARIO.ToList();
                foreach (var obj in query)
                {
                    se.Entry(obj).Reference(x => x.TIPO_USUARIO).Load();
                }
            }

            return query;
        }

        public static USUARIO Get(string username)
        {
            return GetAll().FirstOrDefault<USUARIO>(x => x.USERNAME.ToUpper().Equals(username.ToUpper()));
        }

        public static USUARIO GetTecnico(decimal ID_TIPOUS)
        {
            return GetAll().FirstOrDefault<USUARIO>(x => x.ID_TIPOUS.Equals(4));
        }

        public string AgregarUsuario(USUARIO usuario)
        {
            try
            {
                SafeEntities context = new SafeEntities();
                using (context)
                {
                    context.USUARIO.Add(usuario);
                    context.SaveChanges();

                    return usuario.ID_USUARIO.ToString();
                }


            }
            catch (Exception e)
            {
                return "0";
            }
        }

        public List<string> ObtenerUsuariosPorUsuario(string rut)
        {
            SafeEntities context = new SafeEntities();
            using (context)
            {
                var query = (from a in context.USUARIO
                             where a.RUT_USUARIO == rut
                             select a).ToList();

                List<string> lista = new List<string>();
                List<USUARIO> _lista = query;
                int x = query.Count();
                for (int i = 0; i < x; i++)
                {
                    USUARIO obj = new USUARIO();
                    obj = _lista[i];
                    string fila = obj.ID_USUARIO + ";" + obj.ID_TIPOUS;
                    lista.Add(fila);
                }

                return lista;
            }
        }

        public int ValidarUsuario(string usuario, string clave)
        {
            try
            {
                int _rut = int.Parse(usuario);
                SafeEntities context = new SafeEntities();
                using (context)
                {
                    var q_select_usuario = from obj in context.USUARIO
                                           where obj.ID_USUARIO == _rut
                                           select obj.ID_USUARIO;

                    var q_select_clave = from obj in context.USUARIO
                                         where obj.ID_USUARIO == _rut
                                         select obj.PASS;

                    var _usuario = q_select_usuario.SingleOrDefault();

                    var _clave = q_select_clave.SingleOrDefault();

                    if (usuario == _usuario.ToString() && clave == _clave)
                    {
                        return 1;
                    }
                    else if (usuario == _usuario.ToString() && clave != _clave)
                    {
                        return 2;
                    }
                    else { return 0; }
                }
            }
            catch (Exception e)
            {
                return 5;
            }
        }

        public string RetronarUsuario(string usuario)
        {
            try
            {
                int _usuario = int.Parse(usuario);
                SafeEntities se = new SafeEntities();
                using (se)
                {
                    var _usuarioRut = from obj in se.USUARIO
                                      where obj.ID_USUARIO == _usuario
                                      select obj.RUT_USUARIO;
                    string _rut = _usuarioRut.Single().ToString();
                    var _usuarioNombre = (from obj in se.USUARIO
                                          where obj.RUT_USUARIO == _rut
                                          select obj).FirstOrDefault();
                    USUARIO usu = _usuarioNombre;
                    string nombreUsuario = usu.NOMBRE + " " + usu.APELLIDO_PATERNO + " " + usu.APELLIDO_MATERNO;
                    return nombreUsuario;
                }

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public bool ActualizarClave(string clave, int usuario)
        {
            try
            {
                SafeEntities se = new SafeEntities();
                using (se)
                {
                    var query = (from a in se.USUARIO
                                 where a.ID_USUARIO == usuario
                                 select a).FirstOrDefault();

                    if (query.ID_USUARIO != 0)
                    {
                        query.PASS = clave;
                        se.SaveChanges();
                        return true;
                    }
                    return false;

                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool EliminarUsuario(int usuario)
        {
            try
            {
                SafeEntities se = new SafeEntities();
                using (se)
                {
                    var query1 = (from a in se.USUARIO
                                  where a.ID_USUARIO == usuario
                                  select a).FirstOrDefault();
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public int RetronarPerfilUsuario(string usuario)
        {
            try
            {
                int _usuario = int.Parse(usuario);
                SafeEntities se = new SafeEntities();
                using (se)
                {
                    var _usuarioRut = (from obj in se.USUARIO
                                       where obj.ID_USUARIO == _usuario
                                       select obj.ID_TIPOUS).SingleOrDefault();

                    return int.Parse(_usuarioRut.ToString());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public string RetronarRutUsuario(string usuario)
        {
            try
            {
                int _usuario = int.Parse(usuario);
                SafeEntities se = new SafeEntities();
                using (se)
                {
                    var _usuarioRut = from obj in se.USUARIO
                                      where obj.ID_USUARIO == _usuario
                                      select obj.RUT_USUARIO;
                    string _rut = _usuarioRut.Single().ToString();

                    return _rut;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

    }
}
