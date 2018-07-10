using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DALC;
using Negocio.Vistas;
using WebSafe.Models;
using System.Web.Security;

namespace WebSafe.Controllers
{
    
    public class InicioController : Controller
    {
        public ActionResult Login()
        {
            return this.View();
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsuarioModel l, string ReturnUrl = "")
        {         
            if (ModelState.IsValid)
            {
                bool isValidUser = Membership.ValidateUser(l.Username, l.Password);
                if (isValidUser)
                {
                    FormsAuthentication.SetAuthCookie(l.Username,l.RememberMe);
                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        List<string> Rol = Negocio.Vistas.TipoUsuarioDal.GetAll(l.Username);

                        if (Rol[0].Equals(TipoUsuarioDal.Administrador.ROL))
                        {
                            return RedirectToAction("Index", "Administrador");
                        }
                        else if (Rol[0].Equals(TipoUsuarioDal.Supervisor.ROL))
                        {
                            return RedirectToAction("Index", "Supervisor");
                        }
                        else if (Rol[0].Equals(TipoUsuarioDal.Tecnico.ROL))
                        {
                            return RedirectToAction("Index", "Tecnico");
                        }
                        else if (Rol[0].Equals(TipoUsuarioDal.Medico.ROL))
                        {
                            return RedirectToAction("Index", "Medico");
                        }
                        else if (Rol[0].Equals(TipoUsuarioDal.Trabajador.ROL))
                        {
                            return RedirectToAction("Index", "Trabajador");
                        }
                        else if (Rol[0].Equals(TipoUsuarioDal.Cliente.ROL))
                        {
                            return RedirectToAction("Index", "Cliente");
                        }
                        return RedirectToAction("Error", "Shared");

                    }
                }
            }
            ModelState.AddModelError(string.Empty, "Usuario o Contraseña incorrectos");
            ModelState.Remove("Password");
            return this.View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Inicio");
        }

        public ActionResult Unauthorized()
        {
            return this.View();
        }

        /*
              [HttpPost]
              public ActionResult Index(UsuarioModel usu)
              {
                  SafeEntities se = new SafeEntities();
                  var output = se.USUARIO.FirstOrDefault(m => (m.USERNAME == usu.USERNAME) && (m.PASS == usu.PASS));
                  if (output != null)
                  {
                      return RedirectToAction("Index", "Administrador");
                  }
                  else
                  {
                      return RedirectToAction("Error", "Shared");
                  }
                  return this.View();
              }

              [Authorize]
              public ActionResult Profile()
              {
                  return View();
              }

              [HttpPost]
              [AllowAnonymous]
              public ActionResult Index(UsuarioModel user)
              {
                  SafeEntities se = new SafeEntities();
                  se.USUARIO.Add(user);
                  se.SaveChanges();
                  string message = string.Empty;
                  switch (userId.Value)
                  {
                      case -1:
                          message = "Username and/or password is incorrect.";
                          break;
                      case -2:
                          message = "Account has not been activated.";
                          break;
                      default:
                          FormsAuthentication.SetAuthCookie(user.Username, user.RememberMe);
                          return RedirectToAction("Index", "Administrador");
                  }

                  ViewBag.Message = message;
                  return View(user);
              }

              [HttpPost]
              [Authorize]
              public ActionResult Logout()
              {
                  FormsAuthentication.SignOut();
                  return RedirectToAction("Index");
              }
              */
    }
}