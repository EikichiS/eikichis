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
    
    public partial class TRABAJADOR
    {
        public decimal ID_TRABAJADOR { get; set; }
        public string NOMBRE_COMPLETO { get; set; }
        public string RUT_TRABAJADOR { get; set; }
        public string EMAIL { get; set; }
        public string TELEFONO { get; set; }
        public Nullable<decimal> ID_EMPRESA { get; set; }
        public Nullable<decimal> ID_VISITA { get; set; }
        public Nullable<decimal> ID_CAPACITACION { get; set; }
    
        public virtual CAPACITACION CAPACITACION { get; set; }
        public virtual EMPRESA EMPRESA { get; set; }
        public virtual VISITA_MEDICA VISITA_MEDICA { get; set; }
    }
}
