using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DALC;
using Negocio.Vistas;
using Negocio.Business;

namespace WebSafe.Controllers
{
    public class AjaxController : BaseController
    {
        public JsonResult GetEmpresas()
        {
            List<EmpresaVista.AutocompleteEmpresaViewModel> listaEmpresa = new List<EmpresaVista.AutocompleteEmpresaViewModel>();

            foreach (EMPRESA empresa in EmpresaDal.GetAll())
            {
                INSTALACION instalacion = InstalacionesDal.Get((int)empresa.ID_EMPRESA);    

                listaEmpresa.Add(new EmpresaVista.AutocompleteEmpresaViewModel()
                {
                    Key = instalacion.SECTOR + "de la empresa " + empresa.RAZON_SOCIAL,
                    Value = null
                });
            }

            return this.Json(listaEmpresa, JsonRequestBehavior.AllowGet);
        }
    }
}