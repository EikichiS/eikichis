using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebSafe.Models
{
    public class UsuarioModel
    {
        [DisplayName("Nombre de Usuario")]
        [Required(ErrorMessage = "Nombre de Usuario Requerido", AllowEmptyStrings = false)]
        public string Username
        {
            get;
            set;
        }

        [DisplayName("Contraseña")]
        [Required(ErrorMessage = "Contraseña Requerida", AllowEmptyStrings = false)]
        public string Password
        {
            get;
            set;
        }

        [DisplayName("Recordarme?")]
        public bool RememberMe
        {
            get;
            set;
        }

    }
}