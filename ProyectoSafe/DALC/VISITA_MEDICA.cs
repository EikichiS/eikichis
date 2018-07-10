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
    
    public partial class VISITA_MEDICA
    {
        public VISITA_MEDICA()
        {
            this.DIAGNOSTICO = new HashSet<DIAGNOSTICO>();
            this.TRABAJADOR = new HashSet<TRABAJADOR>();
            this.USUARIO_VISITA = new HashSet<USUARIO_VISITA>();
        }
    
        public decimal ID_VISITA { get; set; }
        public Nullable<System.DateTime> FECHA_CREACION { get; set; }
        public string FECHA_VISITA { get; set; }
        public string PACIENTE { get; set; }
        public string HORA_VISITA { get; set; }
        public string CONFIRMA { get; set; }
        public string DESCRIPCION { get; set; }
        public decimal ID_EMPRESA { get; set; }
        public decimal ID_MEDICO { get; set; }
    
        public virtual ICollection<DIAGNOSTICO> DIAGNOSTICO { get; set; }
        public virtual EMPRESA EMPRESA { get; set; }
        public virtual MEDICO MEDICO { get; set; }
        public virtual ICollection<TRABAJADOR> TRABAJADOR { get; set; }
        public virtual ICollection<USUARIO_VISITA> USUARIO_VISITA { get; set; }
    }
}