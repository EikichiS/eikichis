//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DALC
{
    using System;
    using System.Collections.Generic;
    
    public partial class EMPRESA
    {
        public EMPRESA()
        {
            this.INSTALACION = new HashSet<INSTALACION>();
            this.USUARIO = new HashSet<USUARIO>();
            this.EVALUACION = new HashSet<EVALUACION>();
            this.VISITA_MEDICA = new HashSet<VISITA_MEDICA>();
            this.TRABAJADOR = new HashSet<TRABAJADOR>();
        }
    
        public decimal ID_EMPRESA { get; set; }
        public string RAZON_SOCIAL { get; set; }
        public string RUT_EMPRESA { get; set; }
        public string REPRESENTANTE_LEGAL { get; set; }
        public string DIRECCION { get; set; }
        public string EMAIL { get; set; }
        public string TELEFONO { get; set; }
        public string PAGINA_WEB { get; set; }
        public decimal ID_TIPOEMPRESA { get; set; }
    
        public virtual TIPO_EMPRESA TIPO_EMPRESA { get; set; }
        public virtual ICollection<INSTALACION> INSTALACION { get; set; }
        public virtual ICollection<USUARIO> USUARIO { get; set; }
        public virtual ICollection<EVALUACION> EVALUACION { get; set; }
        public virtual ICollection<VISITA_MEDICA> VISITA_MEDICA { get; set; }
        public virtual ICollection<TRABAJADOR> TRABAJADOR { get; set; }
    }
}