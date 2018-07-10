using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DALC;
using System.Web.Security;

namespace WebSafe.Controllers
{
    public class MedicoController : Controller
    {
        // GET: Medico
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CalendarioMedico()
        {
            SafeEntities es = new SafeEntities();

            return View(es.VISITA_MEDICA.Where(a => a.ID_MEDICO == 1));
        }

        public ActionResult EstadoVisita(int id)
        {
            using (var se = new SafeEntities())
            {
                VISITA_MEDICA ev = se.VISITA_MEDICA.Find(id);
                return View(ev);
            }
        }

        [HttpPost]
        public ActionResult EstadoVisita(VISITA_MEDICA v)
        {
            try
            {
                using (var se = new SafeEntities())
                {
                    v.FECHA_CREACION = DateTime.Now;

                    VISITA_MEDICA vi = se.VISITA_MEDICA.Find(v.ID_VISITA);
                    vi.CONFIRMA = v.CONFIRMA;

 

                    se.SaveChanges();
                    return RedirectToAction("CalendarioMedico");
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}