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
    
    public partial class RELATOR
    {
        public RELATOR()
        {
            this.CAPACITACION = new HashSet<CAPACITACION>();
        }
    
        public decimal ID_RELATOR { get; set; }
        public string NOMBRE_RELATOR { get; set; }
        public string APELLIDO_RELATOR { get; set; }
        public string RUT_RELATOR { get; set; }
    
        public virtual ICollection<CAPACITACION> CAPACITACION { get; set; }
    }
}