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
    
    public partial class Oferta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Oferta()
        {
            this.Confirmacion_Envio = new HashSet<Confirmacion_Envio>();
        }
    
        public int IdOferta { get; set; }
        public int IdEnvio { get; set; }
        public int IdVehiculo { get; set; }
        public int IdTipo_Pago { get; set; }
        public System.DateTime Fecha_Disponibilidad { get; set; }
        public decimal Precio { get; set; }
        public bool Confirmacion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Confirmacion_Envio> Confirmacion_Envio { get; set; }
        public virtual Envio Envio { get; set; }
        public virtual Tipo_Pago Tipo_Pago { get; set; }
        public virtual Vehiculo Vehiculo { get; set; }
    }
}
