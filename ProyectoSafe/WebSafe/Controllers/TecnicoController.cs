using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DALC;

namespace WebSafe.Controllers
{
    public class TecnicoController : Controller
    {
        // GET: Tecnico
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Formulario2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Formulario2(EVALUACION ev)
        {

            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var context = new SafeEntities())
                {
                    ev.FECHA_CRECION = DateTime.Now;

                    context.EVALUACION.Add(ev);
                    context.SaveChanges();
                    return RedirectToAction("Formulario2");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Eror al registrar Formulario" + ex.Message);
                return View();
            }

        }
        public ActionResult ListaTipoEvaluacion()
        {
            using (var se = new SafeEntities())
            {
                return PartialView(se.TIPO_EVALUACION.ToList());
            }
        }
    }
}