using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DALC;
using Negocio.Vistas;

namespace WebSafe.Controllers
{
    public class BaseController : Controller
    {
        protected DateTime TiempoCero = new DateTime(1, 1, 1);
        protected TipoUsuarioDal rol = new TipoUsuarioDal();

        protected USUARIO usuario
        {
            get
            {
                USUARIO currentUsuario = UsuarioDal.Get(this.User.Identity.Name);

                return currentUsuario;
            }
        }
    }
}