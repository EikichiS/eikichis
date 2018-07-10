using DALC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSafe.Models;
using WebSafe.Reporte;

namespace WebSafe.Controllers
{
    public class TrabajadorController : Controller
    {
        // GET: Trabajador
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult ReporteCD(UsuarioTrabajador usutrabajador)
        {
            try
            {
                using (var se = new SafeEntities())
                {
                    TRABAJADOR tr = new TRABAJADOR();
                    var usuario = se.TRABAJADOR.ToList().FirstOrDefault();


                    //var aaa = lista.Where(p => p.ID_TRABAJADOR == id).FirstOrDefault();


                    usutrabajador.Nombre = usuario.NOMBRE_COMPLETO;
                    usutrabajador.Rut = usuario.RUT_TRABAJADOR;
                    usutrabajador.Empresa = usuario.EMPRESA.RAZON_SOCIAL;
                    usutrabajador.Email = usuario.EMAIL;
                    usutrabajador.Telefono = usuario.TELEFONO;
                    usutrabajador.DatosCapacitacion = GetCapacitacionesD();

                    ReporteCapacitacionD reporteCapacitacionD = new ReporteCapacitacionD();
                    byte[] cbytes = reporteCapacitacionD.PrepareReport(usutrabajador);
                    return File(cbytes, "application/pdf");

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ActionResult ReporteV(UsuarioTrabajador usutrabajador)
        {
            try
            {
                using (var se = new SafeEntities())
                {
                    TRABAJADOR tr = new TRABAJADOR();
                    var usuario = se.TRABAJADOR.ToList().FirstOrDefault();


                    //var aaa = lista.Where(p => p.ID_TRABAJADOR == id).FirstOrDefault();


                    usutrabajador.Nombre = usuario.NOMBRE_COMPLETO;
                    usutrabajador.Rut = usuario.RUT_TRABAJADOR;
                    usutrabajador.Empresa = usuario.EMPRESA.RAZON_SOCIAL;
                    usutrabajador.Email = usuario.EMAIL;
                    usutrabajador.Telefono = usuario.TELEFONO;
                    usutrabajador.DatosVisitas = GetVisitasMedicas();

                    ReporteVisitas reporteVisitaD = new ReporteVisitas();
                    byte[] cbytes = reporteVisitaD.PrepareReport(usutrabajador);
                    return File(cbytes, "application/pdf");

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public List<VisitasMedicas> GetVisitasMedicas()
        {
            List<VisitasMedicas> visitas = new List<VisitasMedicas>();
            VisitasMedicas vis = new VisitasMedicas();

            vis = new VisitasMedicas();
            vis.Fecha = "30 Julio del 2018";
            vis.Medico = "Simon Garcia";
            vis.Descripcion = "Tipo visita médica";
            vis.Estado = "Aprobada";
            visitas.Add(vis);

            vis = new VisitasMedicas();
            vis.Fecha = "01 Agosto del 2018";
            vis.Medico = "Sebastian Luna";
            vis.Descripcion = "Tipo visita médica";
            vis.Estado = "Aprobada";
            visitas.Add(vis);

            vis = new VisitasMedicas();
            vis.Fecha = "15 Agosto del 2018";
            vis.Medico = "Simon Garcia";
            vis.Descripcion = "Tipo visita médica";
            vis.Estado = "Aprobada";
            visitas.Add(vis);


            return visitas;
        }

        public List<CapacitacionR> GetCapacitacionesD()
        {
            List<CapacitacionR> usutraba = new List<CapacitacionR>();
            CapacitacionR vis = new CapacitacionR();
            CapacitacionR vis1 = new CapacitacionR();
            CapacitacionR vis2 = new CapacitacionR();

            vis = new CapacitacionR();

            vis.Id = 1;
            vis.Tipo = "Manejo de ácidos";
            vis.FechaInicio = "23 Julio 2018";
            usutraba.Add(vis);

            vis1 = new CapacitacionR();
            vis1.Id = 2;
            vis1.Tipo = "Seguridad Laboral";
            vis1.FechaInicio = "03 Julio 2017";
            usutraba.Add(vis1);

            vis2 = new CapacitacionR();
            vis2.Id = 3;
            vis2.Tipo = "Manejo de cargas";
            vis2.FechaInicio = "25 Julio 2017";
            usutraba.Add(vis2);

            return usutraba;
        }
    }
}
