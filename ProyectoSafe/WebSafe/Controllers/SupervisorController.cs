using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DALC;
using Negocio;
using System.Net.Mail;
using System.Net;
using WebSafe.Models;
using System.IO;
using Helpers;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Configuration;

namespace WebSafe.Controllers
{
    public class SupervisorController : Controller
    {
        // GET: Supervisor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listar()
        {
            SafeEntities es = new SafeEntities();
            return View(es.EVALUACION.ToList());
        }
        public ActionResult Editar(int id)
        {
            using (var se = new SafeEntities())
            {
                EVALUACION ev = se.EVALUACION.Find(id);
                return View(ev);
            }
        }

        [HttpPost]
        public ActionResult Editar(EVALUACION e)
        {
            try
            {
                using (var se = new SafeEntities())
                {
                    e.FECHA_CRECION = DateTime.Now;

                    EVALUACION ev = se.EVALUACION.Find(e.ID_EVALUACION);
                    ev.ID_TIPOEV = e.ID_TIPOEV;
                    ev.NOMBRE_EV = e.NOMBRE_EV;
                    ev.ID_TECNICO = e.ID_TECNICO;
                    ev.ID_EMPRESA = e.ID_EMPRESA;
                    ev.ENCARGADO_EV = e.ENCARGADO_EV;
                    ev.DESC_EV = e.DESC_EV;
                    ev.OBSERVACION = e.OBSERVACION;
                    ev.FECHA_CRECION = e.FECHA_CRECION;

                    se.SaveChanges();
                    return RedirectToAction("Listar");
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ActionResult Eliminar(int id)
        {
            using (var se = new SafeEntities())
            {
                EVALUACION ev = se.EVALUACION.Find(id);
                se.EVALUACION.Remove(ev);
                se.SaveChanges();
                return RedirectToAction("Listar");
            }
        }



        /*--------------------------------------------------------------------------*/
        public ActionResult Visitas()
        {
            SafeEntities es = new SafeEntities();
            return View(es.VISITA_MEDICA.ToList());
        }

        public ActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Crear(VISITA_MEDICA vi)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var context = new SafeEntities())
                {
                    vi.FECHA_CREACION = DateTime.Now;
                    vi.CONFIRMA = "P";

                    context.VISITA_MEDICA.Add(vi);
                    context.SaveChanges();
                    return RedirectToAction("Visitas");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al registrar Visita Medica" + ex.Message);
                return View();
            }
        }


        public ActionResult BorrarVisita(int id)
        {
            using (var se = new SafeEntities())
            {
                VISITA_MEDICA vi = se.VISITA_MEDICA.Find(id);
                se.VISITA_MEDICA.Remove(vi);
                se.SaveChanges();
                return RedirectToAction("Visitas");
            }
        }

        public ActionResult EditarVisita(int id)
        {
            using (var se = new SafeEntities())
            {
                VISITA_MEDICA vi = se.VISITA_MEDICA.Find(id);
                return View(vi);
            }
        }

        [HttpPost]
        public ActionResult EditarVisita(VISITA_MEDICA v)
        {
            try
            {
                using (var se = new SafeEntities())
                {
                    v.FECHA_CREACION = DateTime.Now;

                    VISITA_MEDICA vi = se.VISITA_MEDICA.Find(v.ID_VISITA);
                    vi.FECHA_VISITA = v.FECHA_VISITA;
                    vi.PACIENTE = v.PACIENTE;
                    vi.HORA_VISITA = v.HORA_VISITA;
                    vi.CONFIRMA = v.CONFIRMA;
                    vi.DESCRIPCION = v.DESCRIPCION;
                    vi.FECHA_CREACION = v.FECHA_CREACION;

                    se.SaveChanges();
                    return RedirectToAction("Visitas");
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ActionResult ListaMedicos()
        {
            SafeEntities se = new SafeEntities();
            return View(se.MEDICO.ToList());
        }

        public ActionResult ObtenerMedico(int id)
        {    
           using (var se = new SafeEntities())
            {              
                MEDICO me = se.MEDICO.Find(id);
                if (me.ID_MEDICO == 1 || me.ID_MEDICO == 3)
                { 
                    
                }
                else if(me.ID_MEDICO == 2)
                {
                    
                }
                else
                {
                    
                }
            }
            return View("Visitas");
        }
       
        public ActionResult EnviarCorreo(int id)
        {

            using (var se = new SafeEntities())
            {
                VISITA_MEDICA vi = se.VISITA_MEDICA.Find(id);
                MailDefinition md = new MailDefinition();
                md.From = "notificaciones.safe@gmail.com";
                md.IsBodyHtml = true;
                md.Subject = "Tienes una Visita Medica!";
                md.BodyFileName = "~/ConfirmaHoraTemplate.html";

                ListDictionary replacements = new ListDictionary();
                replacements.Add("{nombre}", vi.MEDICO.NOMBRE_COMPLETO);
                replacements.Add("{paciente}", vi.PACIENTE);
                replacements.Add("{fecha}", vi.FECHA_VISITA);
                replacements.Add("{hora}", vi.HORA_VISITA);
                replacements.Add("{lugar}", vi.EMPRESA.RAZON_SOCIAL);
                replacements.Add("{direccion}", vi.EMPRESA.DIRECCION);


                //string body = "<div><p>Estimado(a) Medico(a) {nombre}, </p> <p>Le informamos que tiene una agendada una visita medica con el paciente {paciente} el dia {fecha} a las {hora}</p> <p> La visita debe realizarse en la empresa {lugar} cuya direccion es {direccion}</p> <p> saludos coordiales,</p> <p> Empresa Safe</p> </div>";

                MailMessage msg = md.CreateMailMessage(vi.MEDICO.EMAIL, replacements,new System.Web.UI.Control());
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 25;
                smtp.EnableSsl = true;
                String sCuentaCorreo = ("notificaciones.safe@gmail.com");
                String sPasswordCorreo = "safe12345";
                smtp.Credentials =
                    new System.Net.NetworkCredential(sCuentaCorreo, sPasswordCorreo);
                smtp.Send(msg);
                ViewBag.Send = "Mensaje enviado OK!!";
                return RedirectToAction("Visitas");
            }
            /*
            try
            {
                string nombre = vi.MEDICO.NOMBRE_COMPLETO;
                string paciente = vi.PACIENTE;
                string fecha = vi.FECHA_VISITA;
                string hora = vi.HORA_VISITA;
                string lugar = vi.EMPRESA.RAZON_SOCIAL;
                string direccion = vi.EMPRESA.DIRECCION;
                string mail = fillConfirmacionTemplate(nombre, paciente, fecha, hora, lugar, direccion);


                MailMessage correo = new MailMessage();
                correo.From = new MailAddress("notificaciones.safe@gmail.com");
                correo.To.Add(vi.MEDICO.EMAIL);
                correo.Subject = "Tienes una visita medica!";
                correo.SubjectEncoding = System.Text.Encoding.UTF8;
                correo.Body = mail;
                correo.IsBodyHtml = true;
                correo.Priority = MailPriority.Normal;
                //Path.GetTempPath() sustituye a Mappath
                //Path.GetTempPath()

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 25;
                smtp.EnableSsl = true;
                String sCuentaCorreo = ("notificaciones.safe@gmail.com");
                String sPasswordCorreo = "safe12345";
                smtp.Credentials =
                    new System.Net.NetworkCredential(sCuentaCorreo, sPasswordCorreo);
                smtp.Send(correo);
                ViewBag.Send = "Mensaje enviado OK!!";              
            }
            catch (Exception ex)
            {
                ViewBag.Mensaje = ex.Message;
            }
            return RedirectToAction("Visitas");
        }

        public static string fillConfirmacionTemplate(string nombre, string paciente, string fecha, string hora, string lugar, string direccion)
        {
            try
            {
                string directoryPath = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName);
                string filePath = string.Format("{0}\\Helpers\\ConfirmaHoraTemplate.html", directoryPath);

                string filledTemplate = string.Empty;
                using (StreamReader reader = new StreamReader(filePath))
                {
                    filledTemplate = reader.ReadToEnd();
                }

                filledTemplate = filledTemplate.Replace("{nombre}", nombre);
                filledTemplate = filledTemplate.Replace("{paciente}", paciente);
                filledTemplate = filledTemplate.Replace("{fecha}", fecha);
                filledTemplate = filledTemplate.Replace("{hora}", hora);
                filledTemplate = filledTemplate.Replace("{lugar}", lugar);
                filledTemplate = filledTemplate.Replace("{direccion}", direccion);

                return filledTemplate;
            }
            catch (Exception ex)
            {
                throw;
            }
            */
        }
        public ActionResult ListaTipoEvaluacion()
        {
            using (var se = new SafeEntities())
            {
                return PartialView(se.TIPO_EVALUACION.ToList());
            }
        }
        /*------------------------------------------------------*/
        public ActionResult ListaCap()
        {
            SafeEntities es = new SafeEntities();
            return View(es.CAPACITACION.ToList());
        }

        public ActionResult CrearCapa()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CrearCapa(CAPACITACION c)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var context = new SafeEntities())
                {
                    c.FECHA_CREACION = DateTime.Now;

                    context.CAPACITACION.Add(c);
                    context.SaveChanges();
                    return RedirectToAction("ListaCap");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al registrar Capacitación" + ex.Message);
                return View();
            }

        }
        public ActionResult ListaTipoCap()
        {
            using (var se = new SafeEntities())
            {
                return PartialView(se.TIPO_CAPACITACION.ToList());
            }
        }


        /*__________________*/

        public ActionResult GenerarInformeEmpresa(int EMPRESA_ID)
        {
            DALC.EVALUACION evaluacion = Negocio.Business.EvaluacionDal.Get(EMPRESA_ID);
            Negocio.Vistas.SupervisorVista.DetallesEvaluacionEmpresa model = new Negocio.Vistas.SupervisorVista.DetallesEvaluacionEmpresa();

            model.Nombre = evaluacion.NOMBRE_EV;
            model.Tecnico = "Juan Magan";
            model.Encargado = evaluacion.ENCARGADO_EV;
            model.DESC_EV = evaluacion.DESC_EV;
            model.OBSERVACION = evaluacion.OBSERVACION;

            return this.View(model);
        }

        /*
        [HttpGet]
        public ActionResult EnviarMail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EnviarMail(Negocio.Vistas.VisitaVista.CorreoView model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }
            try
            {
                string nombreTemplate = default(string);
                string pacienteTemplate = default(string);
                string fechaTemplate = default(string);
                string horaTemplate = default(string);
                string lugarTemplate = default(string);
                string direccionTemplate = default(string);
                string email = model.EmailMedico;


                
                DALC.MEDICO medico = new DALC.MEDICO();
                DALC.VISITA_MEDICA visita = new DALC.VISITA_MEDICA();
                DALC.EMPRESA empresa = new DALC.EMPRESA();
                
                using (SafeEntities se = new SafeEntities())
                {
                    DALC.VISITA_MEDICA visitamedica = new DALC.VISITA_MEDICA()
                    {
                        ID_VISITA = model.visita_id,
                        FECHA_CREACION = DateTime.Now,
                        FECHA_VISITA = model.Fecha,
                        PACIENTE = model.Paciente,
                        HORA_VISITA = model.Hora,
                        CONFIRMA = model.confirma,
                        DESCRIPCION = model.Descripcion,
                        ID_EMPRESA = model.id_empresa,
                        ID_MEDICO = model.id_medico
                    };

                    se.VISITA_MEDICA.Add(visitamedica);
                    se.SaveChanges();

                    nombreTemplate = Negocio.Business.MedicoDal.GetFullName((int)visitamedica.ID_MEDICO);
                    pacienteTemplate = Negocio.Business.VisitaMedicaDal.GetNombrePaciente((int)visitamedica.ID_VISITA);
                    fechaTemplate = model.Fecha;
                    horaTemplate = model.Hora;
                    lugarTemplate = model.Lugar;
                    direccionTemplate = Negocio.Business.EmpresaDal.GetDireccion((int)visitamedica.ID_EMPRESA);

                    model.EmailMedico = Negocio.Business.MedicoDal.GetMail((int)visitamedica.ID_MEDICO);
                }

                string EmailTemplate = Helpers.Email.fillConfirmacionTemplate(nombreTemplate, pacienteTemplate, fechaTemplate, horaTemplate, lugarTemplate, direccionTemplate);

                Helpers.Email.ConfirmacionMedicoMail(EmailTemplate, model.EmailMedico);

                return this.View();
            }
            catch (Exception)
            {
                throw;
            }
            
            [HttpGet]
            public ActionResult EnviarCorreo()
            {
                return View();
            }
            [HttpPost]
            public ActionResult EnviarCorreo(String para, String asunto, String mensaje)
            {
                try
                {
                    MailMessage correo = new MailMessage();
                    correo.From = new MailAddress("notificaciones.safe@gmail.com");
                    correo.To.Add(para);
                    correo.Subject = asunto;
                    correo.Body = mensaje;
                    correo.IsBodyHtml = true;
                    correo.Priority = MailPriority.Normal;
                    String ruta = Server.MapPath("../Temporal");
                    //Path.GetTempPath() sustituye a Mappath
                    //Path.GetTempPath()

                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 25;
                    smtp.EnableSsl = true;
                    String sCuentaCorreo = ("notificaciones.safe@gmail.com");
                    String sPasswordCorreo = "safe12345";
                    smtp.Credentials =
                        new System.Net.NetworkCredential(sCuentaCorreo, sPasswordCorreo);
                    smtp.Send(correo);
                    ViewBag.Send = "Mensaje enviado OK!!";

                }
                catch (Exception ex)
                {
                    ViewBag.Mensaje = ex.Message;
                }
                return View();
            }
            */
        }

    }
