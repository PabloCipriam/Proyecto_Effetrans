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
    
    public partial class Vehiculo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehiculo()
        {
            this.Oferta = new HashSet<Oferta>();
        }
    
        public int IdVehiculo { get; set; }
        public int IdUsuario { get; set; }
        public int IdMarca { get; set; }
        public int IdTipo_Vehiculo { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Licensia { get; set; }
        public bool Estado { get; set; }
    
        public virtual Marca Marca { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Oferta> Oferta { get; set; }
        public virtual Tipo_Vehiculo Tipo_Vehiculo { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}