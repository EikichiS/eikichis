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
    
    public partial class USUARIO_CAPACITACION
    {
        public decimal ID_USUCAP { get; set; }
        public decimal ID_USUARIO { get; set; }
        public decimal ID_CAPACITACION { get; set; }
    
        public virtual CAPACITACION CAPACITACION { get; set; }
        public virtual USUARIO USUARIO { get; set; }
    }
}
