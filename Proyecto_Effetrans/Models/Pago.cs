//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto_Effetrans.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pago
    {
        public int IdPago { get; set; }
        public int IdConfirmacion_Envio { get; set; }
        public System.DateTime Fecha_Confirmacion_Pago { get; set; }
        public string Estado_Pago { get; set; }
        public decimal Valor { get; set; }
    
        public virtual Confirmacion_Envio Confirmacion_Envio { get; set; }
    }
}
