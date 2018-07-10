using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Negocio.Vistas;
using DALC;

namespace WebSafe.Controllers
{
    public class AdministradorController : Controller
    {
        // GET: Administrador

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult MantenedorEmpresas()
        {
            SafeEntities se = new SafeEntities();

            return View(se.EMPRESA.ToList());
        }

        public ActionResult AgregarEmpresa()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarEmpresa(EMPRESA e)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var se = new SafeEntities())
                {
                    se.EMPRESA.Add(e);
                    se.SaveChanges();
                    return RedirectToAction("MantenedorEmpresas");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al registrar Empresa " + ex.Message);
                return View();
            }
        }

        public ActionResult ListaTipoEmpresa()
        {
            using (var se = new SafeEntities())
            {
                return PartialView(se.TIPO_EMPRESA.ToList());
            }
        }
        public ActionResult EditarEmpresa(int id)
        {
            using (var se = new SafeEntities())
            {
                EMPRESA emp = se.EMPRESA.Find(id);
                return View(emp);
            }
                
        }

        [HttpPost]
        public ActionResult EditarEmpresa(EMPRESA e)
        {
            try
            {
                using (var se = new SafeEntities())
                {
                    EMPRESA emp = se.EMPRESA.Find(e.ID_EMPRESA);
                    emp.ID_TIPOEMPRESA = e.ID_TIPOEMPRESA;
                    emp.RAZON_SOCIAL = e.RAZON_SOCIAL;
                    emp.RUT_EMPRESA = e.RUT_EMPRESA;
                    emp.REPRESENTANTE_LEGAL = e.REPRESENTANTE_LEGAL;
                    emp.DIRECCION = e.DIRECCION;
                    emp.EMAIL = e.EMAIL;
                    emp.TELEFONO = e.TELEFONO;
                    emp.PAGINA_WEB = e.PAGINA_WEB;

                    se.SaveChanges();

                    return RedirectToAction("MantenedorEmpresas");
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public ActionResult DetallesEmpresa(int id)
        {
            using (var se = new SafeEntities())
            {
                EMPRESA emp = se.EMPRESA.Find(id);
                return View(emp);

            }
        }

        public ActionResult EliminarEmpresa(int id)
        {
            using (var se = new SafeEntities())
            {
                EMPRESA emp = se.EMPRESA.Find(id);
                se.EMPRESA.Remove(emp);
                se.SaveChanges();
                return RedirectToAction("MantenedorEmpresas");
            }
        }

        public ActionResult MantenedorEvaluacion()
        {
            SafeEntities se = new SafeEntities();

            return View(se.EVALUACION.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarEvaluacion(EVALUACION ev)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var se = new SafeEntities())
                {
                    se.EVALUACION.Add(ev);
                    se.SaveChanges();
                    return RedirectToAction("MantenedorEvaluacion");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al registrar Evaluacion" + ex.Message);
                return View();
            }
        }

        public ActionResult EditarEvaluacion()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarEvaluacion(EVALUACION ev)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                DateTime fechacreacion = DateTime.Now;
                using (var se = new SafeEntities())
                {
                    EVALUACION eva = se.EVALUACION.Find(ev.ID_EVALUACION);
                    eva.ID_TIPOEV = ev.ID_TIPOEV;
                    eva.NOMBRE_EV = ev.NOMBRE_EV;
                    eva.ID_TECNICO = ev.ID_TECNICO;
                    eva.ID_EMPRESA = ev.ID_EMPRESA;
                    eva.ENCARGADO_EV = ev.ENCARGADO_EV;
                    eva.DESC_EV = ev.DESC_EV;
                    eva.OBSERVACION = ev.OBSERVACION;
                    eva.FECHA_CRECION = fechacreacion;

                    se.SaveChanges();

                    return RedirectToAction("MantenedorEmpresa");
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public ActionResult DetallesEvaluacion(decimal ID_EVALUACION)
        {
            using (var se = new SafeEntities())
            {
                EVALUACION eva = se.EVALUACION.Find(ID_EVALUACION);
                return View(eva);

            }
        }

        public ActionResult MantenedorUsuario()
        {
            SafeEntities se = new SafeEntities();
            return View(se.USUARIO.ToList());
        }

        public ActionResult AgregarUsuario()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarUsuario(USUARIO u)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var se = new SafeEntities())
                {
                    se.USUARIO.Add(u);
                    se.SaveChanges();
                    return RedirectToAction("MantenedorEmpresas");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al registrar Usuario " + ex.Message);
                return View();
            }
        }

        public ActionResult ListaTipoUsuario()
        {
            using (var se = new SafeEntities())
            {
                return PartialView(se.TIPO_USUARIO.ToList());
            }
        }


        public ActionResult EditarUsuario(int id)
        {
            using (var se = new SafeEntities())
            {
                USUARIO usu = se.USUARIO.Find(id);
                return View();
            }

        }

        [HttpPost]
        public ActionResult EditarUsuario(USUARIO u)
        {
            try
            {
                
                using (var se = new SafeEntities())
                {
                    u.FECHA_CREACION = DateTime.Now;
                    USUARIO usu = se.USUARIO.Find(u.ID_USUARIO);
                    usu.USERNAME = u.USERNAME;
                    usu.PASS = u.PASS;
                    usu.RUT_USUARIO = u.RUT_USUARIO;
                    usu.NOMBRE = u.NOMBRE;
                    usu.APELLIDO_PATERNO = u.APELLIDO_PATERNO;
                    usu.APELLIDO_MATERNO = u.APELLIDO_MATERNO;
                    usu.FECHA_NACIMIENTO = u.FECHA_NACIMIENTO;
                    usu.EMAIL = u.EMAIL;
                    usu.TELEFONO = u.TELEFONO;
                    usu.FECHA_CREACION = u.FECHA_CREACION;
                    usu.ID_EMPRESA = u.ID_EMPRESA;
                    usu.ID_TIPOUS = u.ID_TIPOUS;

 
                    se.SaveChanges();

                    return RedirectToAction("MantenedorEmpresas");
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public ActionResult DetallesUsuario(int id)
        {
            using (var se = new SafeEntities())
            {
                USUARIO emp = se.USUARIO.Find(id);
                return View(emp);

            }
        }

        public ActionResult EliminarUsuario(int id)
        {
            using (var se = new SafeEntities())
            {
                USUARIO usu = se.USUARIO.Find(id);
                se.USUARIO.Remove(usu);
                se.SaveChanges();
                return RedirectToAction("MantenedorEmpresas");
            }
        }
    }
}